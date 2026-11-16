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
        /// <summary>
        /// Finds patients based on the provided search criteria (first and last name, the date, or both must be provided).
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if the search criteria are invalid.</exception>"
        /// <param name="firstName">The first name of the patient (optional).</param>
        /// <param name="lastName">The last name of the patient (optional).</param>
        /// <param name="dateOfBirth">The date of birth of the patient (optional).</param>
        /// <returns>A list of patients matching the search criteria.</returns>
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

        /// <summary>
        /// Retrieves a list of all patients from the database.
        /// </summary>
        /// <returns>A list of all patients.</returns>
        public List<Patient> GetAllPatients()
        {
            return patientsDAL.GetAllPatients();
        }
        /// <summary>
        /// Retrieves a patient by their id.
        /// </summary>
        /// <param name="id">The unique identifier of the patient.</param>
        /// <returns>The patient with the specified ID, or null if not found.</returns>
        public Patient? GetPatientById(int id)
        {
            return patientsDAL.GetPatientByPatientId(id);
        }

        /// <summary>
        /// Adds a new patient to the database.
        /// </summary>
        /// <param name="p">The Patient object to be added.</param>
        /// <exception cref="ArgumentException">Thrown if validation fails.</exception>
        /// <exception cref="InvalidOperationException">Thrown if an error occurs while saving the patient.</exception>
        public void AddPatient(Patient p)
        {
            ValidatePatient(p);
            var ok = patientsDAL.AddPatient(p);
            if (!ok) throw new InvalidOperationException("An error occurred while saving the patient.");
        }

        /// <summary>
        /// Updates an existing patient in the database.
        /// </summary>
        /// <param name="p">The Patient object to be updated.</param>
        /// <exception cref="ArgumentException">Thrown if validation fails.</exception>
        /// <exception cref="InvalidOperationException">Thrown if an error occurs while updating the patient.</exception>
        /// <exception cref="ArgumentException">Thrown if validation fails.</exception>
        /// <param name="p">The Patient object to be updated.</param>
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
