using System;
using System.Collections.Generic;
using System.Text;

namespace HealthcareSystemProjectCS3230.model
{
    public class Nurse : Person
    {
        /// <summary>
        /// Represents a nurse in the healthcare system.
        /// Inherits from the Person class and adds additional properties specific to nurses.
        /// </summary>
        public int PersonID { get; set; }

        /// <summary>
        /// The username associated with the nurse's account.
        /// This is used for authentication and identification within the system.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The unique identifier for the nurse.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Initializes a new instance of the Nurse class with the specified ID, person ID, and username.
        /// </summary>
        /// <param name="id">The unique identifier for the nurse.</param>
        /// <param name="personID">The unique identifier for the associated person.</param>
        /// <param name="username">The username associated with the nurse's account.</param>
        public Nurse(int id, int personID, string username)
        {
            this.ID = id;
            this.PersonID = personID;
            this.Username = username;

        }
    }
}