using HealthcareSystemProjectCS3230.DAL;
using HealthcareSystemProjectCS3230.model;
using System.Globalization;

namespace HealthcareSystemProjectCS3230.controler;

public class AppointmentController
{
        private AppointmentsDAL appointmentsDAL = new AppointmentsDAL();
        private DoctorDAL doctorDAL = new DoctorDAL();
        private PersonDAL personDAL = new PersonDAL();
        private TestDAL testDAL = new TestDAL();

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
     * Retrieves a list of all tests in the system.
     * @return List of Test objects
     */
    public List<Test> GetTests()
    {
        return testDAL.GetTests();
    }

    /*
    * Gets a patient's visits that have at least one ordered test, with the doctor's name.
    * @param patientId The ID of the patient
    * @return List of VisitSummary objects, newest first
    */
    public List<VisitSummary> GetVisitsWithTestsForPatient(int patientId)
    {
        return testDAL.GetVisitSummariesForPatient(patientId);
    }

    /*
     * Gets the tests ordered for a visit, with normal ranges and any results entered so far.
     * @param appointmentId The ID of the visit (appointment)
     * @return List of VisitTestResult objects
     */
    public List<VisitTestResult> GetVisitTestResults(int appointmentId)
    {
        return testDAL.GetVisitTestResults(appointmentId);
    }

    /*
     * Works out whether a test result is abnormal.
     * If the test has a low and/or high value, the result must be a number and is normal only if it's within [low, high].
     * If the test has no low or high value, the nurse's manual choice is used.
     * @param test The ordered test
     * @param result The result the nurse entered
     * @param manualAbnormal The nurse's choice, used only when the test has no range
     * @return true if the result is abnormal
     */
    public bool DetermineIsAbnormal(VisitTestResult test, string result, bool manualAbnormal)
    {
        if (!test.HasNormalRange)
        {
            return manualAbnormal;
        }

        if (!decimal.TryParse(result.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out decimal value))
        {
            throw new ArgumentException($"{test.TestName} has a normal range, so the result must be a number.");
        }

        bool belowRange = test.LowValue.HasValue && value < test.LowValue.Value;
        bool aboveRange = test.HighValue.HasValue && value > test.HighValue.Value;
        return belowRange || aboveRange;
    }

    /*
     * Validates and saves the result of one ordered test.
     * Throws an exception if the visit is finalized or the input is invalid.
     * @param visit The visit the test belongs to
     * @param test The ordered test
     * @param datePerformed When the test was performed
     * @param result The result the nurse entered
     * @param manualAbnormal The nurse's abnormal choice, used only when the test has no range
     */
    public void SaveTestResult(VisitSummary visit, VisitTestResult test, DateTime datePerformed, string result, bool manualAbnormal)
    {
        if (visit.IsLocked)
        {
            throw new ArgumentException("This visit has a final diagnosis, so its test results can't be changed.");
        }

        if (string.IsNullOrWhiteSpace(result))
        {
            throw new ArgumentException("Please enter the test result.");
        }

       

        if (datePerformed.Date < visit.AppointmentDateTime.Date)
        {
            throw new ArgumentException("The test can't be performed before the visit date.");
        }

        bool isAbnormal = DetermineIsAbnormal(test, result, manualAbnormal);

        bool saved = testDAL.SaveTestResult(test.AppointmentId, test.TestCode, datePerformed, result.Trim(), isAbnormal);
        if (!saved)
        {
            throw new InvalidOperationException("The result could not be saved. The visit may have just been finalized.");
        }
    }

    /*
     * Saves the visit and any selected tests. Database access remains in the DAL.
     */
    public void SaveVisitAndTests(
        int appointmentId,
        int systolic,
        int diastolic,
        int pulse,
        decimal bodyTemperature,
        decimal height,
        decimal weight,
        string symptoms,
        string? initialDiagnosis,
        IReadOnlyCollection<Test> selectedTests)
    {
        if (appointmentId <= 0) throw new ArgumentException("Please select a valid appointment.");

        if (systolic <= 0 || diastolic <= 0 || pulse <= 0)
            throw new ArgumentException("Systolic, diastolic, and pulse must be greater than zero.");

        if (bodyTemperature <= 0 || height <= 0 || weight <= 0)
            throw new ArgumentException("Body temperature, height, and weight must be greater than zero.");

        if (string.IsNullOrWhiteSpace(symptoms)) throw new ArgumentException("Please enter the patient's symptoms.");

        if (selectedTests == null) throw new ArgumentNullException(nameof(selectedTests));

        testDAL.SaveVisitAndTests(
            appointmentId,
            systolic,
            diastolic,
            pulse,
            bodyTemperature,
            height,
            weight,
            symptoms.Trim(),
            initialDiagnosis,
            selectedTests);
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
        public List<AppointmentSummary> GetAppointmentsForPatient(int patientId)
        {
            return appointmentsDAL.GetAppointmentsForPatient(patientId, DateTime.Today);
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
        var scheduledVisits = testDAL.GetVisitsByPatientId(patientId);
        foreach (var appt in appointments)
        {
                if (appt.DateTime.Date < DateTime.Now.Date)
                {
                    continue; // Skip past appointments
                }
                if (scheduledVisits.Any(v => v.AppointmentId == appt.AppointmentId))
                {
                    continue; // Skip appointments with scheduled visits
                }

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

    /*
     * Gets all the visits that either have no tests or all of the tests are completed for a specific patient.
     * @param patientId The ID of the patient
     * @return List of Visit objects that meet the criteria
     */
    public List<Visit> GetVisitsWithCompleteOrNoTestsForPatient(int patientId)
    {
        return testDAL.GetVisitsWithCompleteOrNoVisitTests(patientId);
    }

    /*
     * Gets the name of the doctor associated with a visit.
     * @param visitId the ID of the visit
     * @return the name of the doctor associated with the visit
     */
    public string GetDoctorNameFromVisit(int visitId)
    {
        var doctors = GetDoctorsWithNames();
        var appointment = GetAppointmentById(visitId);
        if (appointment == null)
        {
            throw new ArgumentException("Appointment not found.");
        }
        var scheduledDoctor = doctors.FirstOrDefault(doctor => doctor.DoctorId == appointment.DoctorId);
        return scheduledDoctor == null ? throw new ArgumentException("Doctor not found.") : scheduledDoctor.FullName;
    }

    /*
     * Updates the Final Diagnosis for a visit.
     * @param visitId The ID of the visit to update
     * @param finalDiagnosis The new final diagnosis
     * @returns true if the update was successful, false otherwise
     */
    public bool UpdateFinalDiagnosis(string finalDiagnosis, int visitId)
    {
        return appointmentsDAL.UpdateVisitFinalDiagnosis(finalDiagnosis, visitId);
    }

    /*
 * Gets all of a patient's visits, with or without ordered tests.
 * @param patientId The ID of the patient
 * @return List of VisitSummary objects, newest first
 */
    public List<VisitSummary> GetAllVisitsForPatient(int patientId)
    {
        return testDAL.GetVisitSummariesForPatient(patientId, onlyWithTests: false);
    }

    /*
     * Gets one visit's checkup details and diagnoses.
     * @param appointmentId The ID of the visit (appointment)
     * @return The Visit, or null if it doesn't exist
     */
    public Visit? GetVisitById(int appointmentId)
    {
        return testDAL.GetVisitById(appointmentId);
    }
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