using System;
using System.Collections.Generic;
using System.Linq;
using Mrozik.Nebraska.Models;

namespace Mrozik.Nebraska.Mocks
{
    public class MockDatabase
    {
        private readonly IList<OrderViewModel> _orders;

        public MockDatabase()
        {
            _orders = new OrdersFactory().Get(1000).ToList();
        }

        public IEnumerable<OrderViewModel> Orders => _orders;


        public class OrdersFactory
        {
            private Random _random = new Random();

            public IEnumerable<OrderViewModel> Get(int count)
            {
                string[] customers = new[]
                {
                    "James Bond",
                    "Apple",
                    "Microsoft",
                    "Nokia",
                    "ASUS",
                    "Feel Good Inc",
                    "Liberty Direct",
                };
                string[] priorities = new[]
                {
                    "High",
                    "Normal",
                    "Low"
                };

                int[] progress = new[]
                {
                    0, 10, 30, 50, 70, 100
                };

                for (var i = 0; i < count; i++)
                {
                    yield return new OrderViewModel
                    {
                        Id = i + 1,
                        Number = $"{i + 1 + 200}/2016",
                        CustomerName = GetValue(customers),
                        Date = DateTime.Now.ToString("yyyy-MM-dd"),
                        Priority = GetValue(priorities),
                        Remarks = "bla bla bla",
                        Quantity = _random.Next(100).ToString("N"),
                        Colors = "black, white",
                        Departments = "dep1, dep2",
                        Progress = GetValue(progress),
                        RealisationDetails = "bla bla bla 2",
                        Description = "bla bla bla 3"
                    };
                }

            }

            private T GetValue<T>(T[] values)
            {
                return values[_random.Next(values.Length)];
            }
        }
    }
}