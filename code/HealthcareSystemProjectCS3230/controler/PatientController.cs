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
    }
}
