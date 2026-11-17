using HealthcareSystemProjectCS3230.DAL;
using HealthcareSystemProjectCS3230.model;
using System.Runtime.CompilerServices;


namespace HealthcareSystemProjectCS3230.controler
{
    
    public class NurseController
    {
        private NurseDAL nurseDAL = new NurseDAL();
        private PersonDAL personDAL = new PersonDAL();

        /// <summary>
        /// Adds a new nurse to the database after validating the input.
        /// </summary>
        /// <param name="nurse">The Nurse object to be added.</param>
        /// <param name="password">The password for the nurse's account.</param>
        /// <exception cref="ArgumentException">Thrown when the input data is invalid.</exception>
        /// <exception cref="Exception">Thrown when the nurse could not be added to the database.</exception>
        public void AddNurse(Nurse nurse, string password)
        {
            if (password.Length > 50 || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password must be 50 or less characters and cannot be empty.");
            }
            validateNurse(nurse);
            if (!nurseDAL.AddNurse(nurse, password))
            {
                throw new Exception("Nurse could not be added");
            }
        }
        
        /// <summary>
        /// Retrieves a Person object by their ID.
        /// </summary>
        /// <param name="personId">The ID of the person to retrieve.</param>
        /// <returns>The Person object corresponding to the given ID.</returns>
        public Person GetPersonByID(int personId)
        {
            return personDAL.GetPersonByID(personId);
        }
        /// <summary>
        /// Validates the properties of a Nurse object
        /// </summary>
        /// <param name="nurse">The Nurse object to validate.</param>
        /// <exception cref="ArgumentException">Thrown when the input data is invalid.</exception>
        /// <returns>true if validation passes; otherwise, throws an exception.</returns>
        private bool validateNurse(Nurse nurse)
        {
            if (nurse.Username.Length > 50) throw new ArgumentException("Username must be 50 or less characters");
            if (nurse.Gender == '\0') throw new ArgumentException("Gender is required.");
            if (string.IsNullOrWhiteSpace(nurse.FirstName) || string.IsNullOrWhiteSpace(nurse.LastName))
                throw new ArgumentException("First and last name are required.");
            if (!System.Text.RegularExpressions.Regex.IsMatch(nurse.PhoneNumber ?? string.Empty, "^[0-9]{10}$"))
                throw new ArgumentException("Phone number must be 10 digits (numbers only).");
            if (nurse.Address == null || !System.Text.RegularExpressions.Regex.IsMatch(nurse.Address.Zipcode ?? string.Empty, "^[0-9]{5}$"))
                throw new ArgumentException("ZIP code must be 5 digits.");
            if (nurse.Birthdate >= DateTime.Now.Date)
                throw new ArgumentException("Birthdate must be in the past.");
            return true;
        }

        /// <summary>
        /// Retrieves a list of all nurses from the database.
        /// </summary>
        /// <returns>A list of Nurse objects representing all nurses in the database.</returns>
        public List<Nurse> GetAllNurses()
        {
            return nurseDAL.GetAllNurses();
        }

        /// <summary>
        /// Retrieves a nurse from the database by their ID.
        /// </summary>
        /// <param name="id">The ID of the nurse to retrieve.</param>
        /// <returns>The Nurse object corresponding to the given ID.</returns>
        public Nurse GetNurseByID(int id)
        {
            return nurseDAL.GetNurseByID(id);
        }

        /// <summary>
        /// Updates an existing nurse in the database.
        /// </summary>
        /// <param name="nurse">The Nurse object containing updated information.</param>
        public void UpdateNurse(Nurse nurse)
        {
            validateNurse(nurse);

            if (!nurseDAL.UpdateNurse(nurse))
            {
                throw new Exception("Nurse could not be updated");
            }
        }
    }
}