using System.Composition.Convention;

namespace Acme.WebApi.Docker.Demo.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public Guid CustomerId { get; set; }

        public System.DateTime OrderDate;

        public Decimal totalAmount;
    }
}
