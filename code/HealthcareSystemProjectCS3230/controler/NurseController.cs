using HealthcareSystemProjectCS3230.DAL;
using HealthcareSystemProjectCS3230.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthcareSystemProjectCS3230.controler
{
    public class NurseController
    {
        public void AddNurse(int personID, string username)
        {
            if (!PersonDAL.DoesExist(personID)) {
                throw new ArgumentException("Person ID must be valid");
            }
            if (username.Length > 50)
            {
                throw new ArgumentException("Username must be 50 or less characters");
            }
            if (!NurseDAL.AddNurse(personID, username))
            {
                throw new Exception("Nurse could not be added");
            }
        }

        public List<Nurse> GetAllNurses()
        {
            return NurseDAL.GetAllNurses();
        }

        public void UpdateNurse(string oldUsername, string newUsername)
        {
            if (newUsername.Length > 50)
            {
                throw new ArgumentException("Username must be 50 or less characters");
            }
            if (!NurseDAL.UpdateNurse(oldUsername, newUsername))
            {
                throw new Exception("Nurse could not be updated");
            }
        }
    }
}