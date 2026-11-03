using HealthcareSystemProjectCS3230.DAL;
using HealthcareSystemProjectCS3230.model;

namespace HealthcareSystemProjectCS3230.controler
{
    public class AppointmentController
    {
        private AppointmentsDAL appointmentsDAL = new AppointmentsDAL();
        private DoctorDAL doctorDAL = new DoctorDAL();
        private PersonDAL personDAL = new PersonDAL();

        /*
         * Retreives a list of all doctors in the system
         * @return List of Doctor objects
         */
        public List<Doctor> GetDoctors()
        {
            return doctorDAL.GetAllDoctors();
        }

        /*
         * Retreives a list of all doctors in the system, along with their first and last names.
         * @return List of DoctorView objects, which contain the doctor's ID, first name, last name, and full name.
         */
        public List<DoctorView> GetDoctorsWithNames()
        {
            var doctorViews = new List<DoctorView>();

            foreach (var doctor in GetDoctors())
            {
                var person = personDAL.GetPersonByID(doctor.personId);
                if (person != null)
                {
                    doctorViews.Add(new DoctorView
                    {
                        DoctorId = doctor.id,
                        FirstName = person.FirstName,
                        LastName = person.LastName,
                        FullName = $"{person.FirstName} {person.LastName}"
                    });
                }
            }

            return doctorViews;
        }
        /*
         * Retreives a specific appointment by its ID
         *
         * @param appointmentId The ID of the appointment to retrieve
         * @return Appointment object if found, null otherwise
         */
        public Appointment? GetAppointmentById(int appointmentId)
        {
            return appointmentsDAL.GetAppointmentById(appointmentId);
        }

        /*
         * Checks if an appointment can be edited based on its date and time
         * @param appointmentDateTime The date and time of the appointment to check
         * @return true if the appointment can be edited, false otherwise
         */
        public bool CanEditAppointment(DateTime appointmentDateTime)
        {
            return DateTime.Today < appointmentDateTime.Date;
        }

        /*
         * Retrieves a list of available appointment slots for a specific doctor on a specific date
         * @param doctorId The ID of the doctor
         * @param date The date to check for available slots
         * @param excludeAppointmentId Optional parameter to exclude a specific appointment from the check (useful when updating an appointment)
         * @return List of available TimeSpan slots
         */
        public List<TimeSpan> GetAvailableSlots(int doctorId, DateTime date, int? excludeAppointmentId = null)
        {
            List<TimeSpan> allSlots = AppointmentSlotRules.GetDailySlots();
            HashSet<TimeSpan> bookedSlots = appointmentsDAL
                .GetBookedSlotsForDoctorDate(doctorId, date, excludeAppointmentId)
                .ToHashSet();

            return allSlots.Where(slot => !bookedSlots.Contains(slot)).ToList();
        }
        /*
         * Books a new appointment for a patient with a specific doctor at a specific date and time
         * Throws an exception if the appointment cannot be booked (e.g., if the slot is already taken or if the input data is invalid)
         * @param patientId The ID of the patient
         * @param doctorId The ID of the doctor
         * @param appointmentDateTime The date and time of the appointment
         * @param reason The reason for the appointment
         */
        public void BookAppointment(int patientId, int doctorId, DateTime appointmentDateTime, string reason)
        {
            ValidateAppointment(patientId, appointmentDateTime, reason);
            EnsureSlotIsFree(doctorId, appointmentDateTime);

            bool saved = appointmentsDAL.AddAppointment(patientId, appointmentDateTime, doctorId, reason.Trim());
            if (!saved)
            {
                throw new InvalidOperationException("The appointment could not be saved. The time may have just been booked. Please choose another time.");
            }
        }
        /*
         * Updates an existing appointment with new details
         * Throws an exception if the appointment cannot be updated (e.g., if the slot is already taken, if the appointment cannot be edited, or if the input data is invalid)
         * @param appointmentId The ID of the appointment to update
         * @param patientId The new patient ID
         * @param doctorId The new doctor ID
         * @param appointmentDateTime The new date and time of the appointment
         * @param reason The new reason for the appointment
         */
        public void UpdateAppointment(int appointmentId, int patientId, int doctorId, DateTime appointmentDateTime, string reason)
        {
            Appointment? currentAppointment = appointmentsDAL.GetAppointmentById(appointmentId);
            if (currentAppointment == null)
            {
                throw new ArgumentException("The appointment could not be found.");
            }

            if (!CanEditAppointment(currentAppointment.DateTime))
            {
                throw new ArgumentException("This appointment can no longer be edited.");
            }

            ValidateAppointment(patientId, appointmentDateTime, reason);
            EnsureSlotIsFree(doctorId, appointmentDateTime, appointmentId);

            bool saved = appointmentsDAL.UpdateAppointment(appointmentId, patientId, appointmentDateTime, doctorId, reason.Trim());
            if (!saved)
            {
                throw new InvalidOperationException("The appointment could not be saved. The time may have just been booked. Please choose another time.");
            }
        }

        /*
         * Validates the input data for booking or updating an appointment
         * Throws an exception if any of the input data is invalid
         * @param patientId The ID of the patient
         * @param appointmentDateTime The date and time of the appointment
         * @param reason The reason for the appointment
         */
        public List<AppointmentView> GetAppointmentsByPatientId(int patientId)
        {
            var appointments = appointmentsDAL.GetAppointmentsByPatientId(patientId);
            if (appointments == null || appointments.Count == 0)
            {
                throw new ArgumentException("No appointments found for the given patient ID.");
            }

            var appointmentViews = new List<AppointmentView>();
            var doctorNames = GetDoctorsWithNames();
            foreach (var appt in appointments)
            {
                var appointmentView = new AppointmentView
                {
                    AppointmentId = appt.AppointmentId,
                    PatientId = appt.PatientId,
                    DoctorId = appt.DoctorId,
                    DateTime = appt.DateTime,
                    Reason = appt.Reason,
                    DoctorName = doctorNames.FirstOrDefault(d => d.DoctorId == appt.DoctorId)?.FullName ?? "Unknown"
                };
                appointmentViews.Add(appointmentView);
            }

            return appointmentViews;
        }

        private void EnsureSlotIsFree(int doctorId, DateTime appointmentDateTime, int? excludeAppointmentId = null)
        {
            var freeSlots = GetAvailableSlots(doctorId, appointmentDateTime.Date, excludeAppointmentId);
            if (!freeSlots.Contains(appointmentDateTime.TimeOfDay))
            {
                throw new ArgumentException("That time was just booked. Please choose another time.");
            }
        }

        private static void ValidateAppointment(int patientId, DateTime appointmentDateTime, string reason)
        {
            if (patientId <= 0)
            {
                throw new ArgumentException("Please enter a valid patient ID.");
            }

            if (string.IsNullOrWhiteSpace(reason))
            {
                throw new ArgumentException("Please enter a reason for the visit.");
            }

            if (appointmentDateTime < DateTime.Now)
            {
                throw new ArgumentException("Appointments can't be booked in the past.");
            }

            if (!AppointmentSlotRules.IsValidSlotDateTime(appointmentDateTime))
            {
                throw new ArgumentException(
                    "Appointment times must be in 15-minute slots between 8:00 AM and 4:45 PM.");
            }
        }
    }

    public class DoctorView
    {
        public int DoctorId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
    }

    /*
     * Represents a view model for an appointment, including the doctor's name for display purposes
     */
    public class AppointmentView
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime DateTime { get; set; }
        public string Reason { get; set; } = string.Empty;
        public string DoctorName { get; set; } = string.Empty;
    }
}