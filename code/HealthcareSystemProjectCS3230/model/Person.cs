using System;

namespace HealthcareSystemProjectCS3230.model
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public Address Address { get; set; } = new Address();

        public char Gender { get; set; } = 'U'; // U for unspecified, M for male, F for female
    }
}
