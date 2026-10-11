using System;

namespace HealthcareSystemProjectCS3230.model
{
    public class Patient
    {

        public int Id { get; set; }
        public bool IsActive { get; set; } = true;

        public int PersonId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
        public string PhoneNumber { get; set; } = string.Empty; // 10 digits expected

        public int AddressId { get; set; }
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Zipcode { get; set; } = string.Empty; // 5 digits expected
        public string State { get; set; } = string.Empty; // 2 letter code
    }
}
