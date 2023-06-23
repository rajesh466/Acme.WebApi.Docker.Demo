

using System.ComponentModel.DataAnnotations;

namespace Acme.WebApi.Docker.Demo.Models
{
    public class Customer
    {
        [Key]
        public Guid CustomerId{ get; set; }
        public string CustomerName { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

    }
}
