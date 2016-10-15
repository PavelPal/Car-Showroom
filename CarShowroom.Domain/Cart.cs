using System.Collections.Generic;
using System.Linq;
using CarShowroom.Domain.Entities;

namespace CarShowroom.Domain
{
    public class Cart
    {
        private readonly List<CartLine> _lineCollection = new List<CartLine>();

        public IEnumerable<CartLine> Lines => _lineCollection;

        public void AddItem(Car car, int quantity)
        {
            var line = _lineCollection
                .FirstOrDefault(p => p.Car.Id == car.Id);
            if (line == null)
            {
                _lineCollection.Add(new CartLine
                {
                    Car = car,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Car car)
        {
            _lineCollection.RemoveAll(l => l.Car.Id == car.Id);
        }

        public decimal ComputeTotalValue()
        {
            return _lineCollection.Sum(e => (e.Car.Cost + e.Car.Discount)*e.Quantity);
        }

        public void Clear()
        {
            _lineCollection.Clear();
        }
    }
}