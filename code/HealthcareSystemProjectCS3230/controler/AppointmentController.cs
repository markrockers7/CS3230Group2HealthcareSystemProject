using HealthcareSystemProjectCS3230.DAL;
using HealthcareSystemProjectCS3230.model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthcareSystemProjectCS3230.controler
{
    public class AppointmentController
    {
        public List<Doctor> GetDoctors()
        {
            return DoctorDAL.GetAllDoctors();
        }

        public List<DoctorView> GetDoctorsWithNames()
        {
            var doctorViews = new List<DoctorView>();

            foreach (var doctor in GetDoctors())
            {
                var person = PersonDAL.GetPersonByID(doctor.personId);
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

        public Appointment? GetAppointmentById(int appointmentId)
        {
            return AppointmentsDAL.GetAppointmentById(appointmentId);
        }

        public bool CanEditAppointment(DateTime appointmentDateTime)
        {
            return DateTime.Today < appointmentDateTime.Date;
        }

        public List<TimeSpan> GetAvailableSlots(int doctorId, DateTime date, int? excludeAppointmentId = null)
        {
            List<TimeSpan> allSlots = AppointmentSlotRules.GetDailySlots();
            HashSet<TimeSpan> bookedSlots = AppointmentsDAL
                .GetBookedSlotsForDoctorDate(doctorId, date, excludeAppointmentId)
                .ToHashSet();

            return allSlots.Where(slot => !bookedSlots.Contains(slot)).ToList();
        }

        public void BookAppointment(int patientId, int doctorId, DateTime appointmentDateTime, string reason)
        {
            ValidateAppointment(patientId, appointmentDateTime, reason);
            EnsureSlotIsFree(doctorId, appointmentDateTime);

            bool saved = AppointmentsDAL.AddAppointment(patientId, appointmentDateTime, doctorId, reason.Trim());
            if (!saved)
            {
                throw new InvalidOperationException("The appointment could not be saved. The time may have just been booked. Please choose another time.");
            }
        }

        public void UpdateAppointment(int appointmentId, int patientId, int doctorId, DateTime appointmentDateTime, string reason)
        {
            Appointment? currentAppointment = AppointmentsDAL.GetAppointmentById(appointmentId);
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

            bool saved = AppointmentsDAL.UpdateAppointment(appointmentId, patientId, appointmentDateTime, doctorId, reason.Trim());
            if (!saved)
            {
                throw new InvalidOperationException("The appointment could not be saved. The time may have just been booked. Please choose another time.");
            }
        }

        // Re-checks the database right before saving, in case another user just booked this slot
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
                throw new ArgumentException("Appointment times must be in 15-minute slots between 8:00 AM and 4:45 PM.");
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
}