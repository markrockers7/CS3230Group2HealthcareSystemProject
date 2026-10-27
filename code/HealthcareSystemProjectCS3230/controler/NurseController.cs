using HealthcareSystemProjectCS3230.DAL;
using HealthcareSystemProjectCS3230.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HealthcareSystemProjectCS3230.controler
{
    public class NurseController
    {
        public void AddNurse(Nurse nurse, string password)
        {
            if (password.Length > 50)
            {
                throw new ArgumentException("Password must be 50 or less characters");
            }
            validateNurse(nurse);
            if (!NurseDAL.AddNurse(nurse, password))
            {
                throw new Exception("Nurse could not be added");
            }
        }

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

        public List<Nurse> GetAllNurses()
        {
            return NurseDAL.GetAllNurses();
        }

        public Nurse GetNurseByID(int id)
        {
            return NurseDAL.GetNurseByID(id);
        }

        public void UpdateNurse(Nurse nurse)
        {
            validateNurse(nurse);

            if (!NurseDAL.UpdateNurse(nurse))
            {
                throw new Exception("Nurse could not be updated");
            }
        }
    }
}