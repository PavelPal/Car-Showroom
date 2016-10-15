using CarShowroom.Domain.Entities;

namespace CarShowroom.Domain
{
    public class CartLine
    {
        public Car Car { get; set; }
        public int Quantity { get; set; }
    }
}