using System;
using System.Collections.Generic;
using HealthcareSystemProjectCS3230.DAL;
using HealthcareSystemProjectCS3230.model;

namespace HealthcareSystemProjectCS3230.controler
{
    public class PatientController
    {
        public List<Patient> FindPatients(string? firstName, string? lastName, DateTime? dateOfBirth)
        {
            var hasFirstName = !string.IsNullOrWhiteSpace(firstName);
            var hasLastName = !string.IsNullOrWhiteSpace(lastName);

            if (!hasFirstName && !hasLastName && !dateOfBirth.HasValue)
            {
                throw new ArgumentException("Enter both a first and last name, or select a birthdate to search.");
            }

            if (hasFirstName != hasLastName)
            {
                throw new ArgumentException("Enter both a first and last name to search by name.");
            }

            if (dateOfBirth.HasValue)
            {
                if (hasFirstName || hasLastName)
                {
                    return PatientsDAL.GetPatientsByNameAndDateOfBirth(firstName, lastName, dateOfBirth.Value);
                }

                return PatientsDAL.GetPatientsByDateOfBirth(dateOfBirth.Value);
            }

            return PatientsDAL.GetPatientsByName(firstName, lastName);
        }

        public List<Patient> GetAllPatients()
        {
            return PatientsDAL.GetAllPatients();
        }

        public Patient? GetPatientById(int id)
        {
            return PatientsDAL.GetPatientByPatientId(id);
        }

        public void AddPatient(Patient p)
        {
            ValidatePatient(p);
            var ok = PatientsDAL.AddPatient(p);
            if (!ok) throw new InvalidOperationException("An error occurred while saving the patient.");
        }

        public void UpdatePatient(Patient p)
        {
            ValidatePatient(p);
            var ok = PatientsDAL.UpdatePatient(p);
            if (!ok) throw new InvalidOperationException("An error occurred while updating the patient.");
        }

        private static void ValidatePatient(Patient p)
        {
            if (p == null) throw new ArgumentNullException(nameof(p));
            if (string.IsNullOrWhiteSpace(p.FirstName) || string.IsNullOrWhiteSpace(p.LastName))
                throw new ArgumentException("First and last name are required.");

            if (!System.Text.RegularExpressions.Regex.IsMatch(p.PhoneNumber ?? string.Empty, "^[0-9]{10}$"))
                throw new ArgumentException("Phone number must be 10 digits (numbers only).");

            if (p.Address == null || !System.Text.RegularExpressions.Regex.IsMatch(p.Address.Zipcode ?? string.Empty, "^[0-9]{5}$"))
                throw new ArgumentException("ZIP code must be 5 digits.");

            if (p.Birthdate >= DateTime.Now.Date)
                throw new ArgumentException("Birthdate must be in the past.");
        }
    }
}
