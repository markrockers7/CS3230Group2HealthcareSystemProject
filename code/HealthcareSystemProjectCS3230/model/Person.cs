using System;

namespace HealthcareSystemProjectCS3230.model
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
        public string PhoneNumber { get; set; } = string.Empty; // 10 digits expected

        public Address Address { get; set; } = new Address();
    }
}
