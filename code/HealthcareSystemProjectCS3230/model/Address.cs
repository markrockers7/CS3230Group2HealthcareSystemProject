namespace HealthcareSystemProjectCS3230.model
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Zipcode { get; set; } = string.Empty; // 5 digits expected
        public string State { get; set; } = string.Empty; // 2-letter code
    }
}
