using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using HealthcareSystemProjectCS3230.DAL;
using HealthcareSystemProjectCS3230.model;

namespace HealthcareSystemProjectCS3230.controler
{
    public class PatientController
    {
        private PatientsDAL patientsDAL = new PatientsDAL();
        /*
         * Finds patients based on the provided search criteria (first and last name, the date, or both must be provided).
         * Throws ArgumentException if the search criteria are invalid.
         *
         * @param firstName The first name of the patient (optional).
         * @param lastName The last name of the patient (optional).
         * @param dateOfBirth The date of birth of the patient (optional).
         * @return A list of patients matching the search criteria.
         */
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
                    return patientsDAL.GetPatientsByNameAndDateOfBirth(firstName, lastName, dateOfBirth.Value);
                }

                return patientsDAL.GetPatientsByDateOfBirth(dateOfBirth.Value);
            }

            return patientsDAL.GetPatientsByName(firstName, lastName);
        }

        /*
         * Retrieves a list of all patients from the database.
         *
         * @return A list of all patients.
         */
        public List<Patient> GetAllPatients()
        {
            return patientsDAL.GetAllPatients();
        }
        /*
         * Retrieves a patient by their id.
         *
         * @param id The unique identifier of the patient.
         * @return The patient with the specified ID, or null if not found.
         */
        public Patient? GetPatientById(int id)
        {
            return patientsDAL.GetPatientByPatientId(id);
        }

        /*
         * Adds a new patient to the database
         * Throws ArgumentException if validation fails.
         * 
         * @param p The Patient object to be added.
         */
        public void AddPatient(Patient p)
        {
            ValidatePatient(p);
            var ok = patientsDAL.AddPatient(p);
            if (!ok) throw new InvalidOperationException("An error occurred while saving the patient.");
        }

        /*
         * Updates an existing patient in the database
         * Throws ArgumentException if validation fails.
         * 
         * @param p The Patient object to be updated.
         */
        public void UpdatePatient(Patient p)
        {
            ValidatePatient(p);
            var ok = patientsDAL.UpdatePatient(p);
            if (!ok) throw new InvalidOperationException("An error occurred while updating the patient.");
        }

        private void ValidatePatient(Patient p)
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
