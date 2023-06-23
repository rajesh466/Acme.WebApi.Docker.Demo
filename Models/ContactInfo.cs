namespace Acme.WebApi.Docker.Demo.Models
{
    public class ContactInfo
    {
        public Guid ContactId { get; set; }
        public Guid CustomerId { get; set; }

        public string? Address { get; set; }

        public string? PhoneNumber { get; set; } 

    }
}
