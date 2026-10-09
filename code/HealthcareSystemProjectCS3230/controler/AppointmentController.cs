using HealthcareSystemProjectCS3230.DAL;
using HealthcareSystemProjectCS3230.model;
using System;
using System.Collections.Generic;
using System.Text; 

namespace HealthcareSystemProjectCS3230.controler
{
    public class AppointmentController
    {
        public List<Doctor> GetDoctors()    
        {
            return DoctorDAL.GetAllDoctors();
        }

        public void BookAppointment(int patientId, int doctorId, DateTime dateTime, string reason)
        {
            if (string.IsNullOrWhiteSpace(reason))
            {
                throw new ArgumentException("Please enter a reason for the visit.");
            }

            if (dateTime < DateTime.Now)
            {
                throw new ArgumentException("Appointments can't be booked in the past.");
            }

            if (DoctorDAL.IsDoctorBooked(doctorId, dateTime))
            {
                throw new ArgumentException("That doctor already has an appointment at that time.");
            }

            bool saved = AppointmentsDAL.AddAppointment(patientId, dateTime, doctorId, reason.Trim());
            if (!saved)
            {
                throw new InvalidOperationException("The appointment could not be saved.");
            }
        }
    }
}
