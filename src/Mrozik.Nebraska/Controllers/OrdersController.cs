using Microsoft.AspNetCore.Mvc;
using Mrozik.Nebraska.DataTablesModel;
using Mrozik.Nebraska.Models;
using System.Linq;
using System.Linq.Dynamic.Core;
namespace Mrozik.Nebraska.Controllers
{
    public class OrdersController : Controller
    {
        private readonly MockDatabase _mockDatabase;

        public OrdersController(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        [HttpPost]
        public Response<OrderViewModel> Get(Parameters arg)
        {
            var orders = _mockDatabase.Orders.AsQueryable();

            foreach (var colOrder in arg.Order)
            {
                var colName = arg.Columns[colOrder.Column].Data;
                orders = orders.OrderBy($"{colName} {colOrder.Dir}");
            }

            orders = orders.Skip(arg.Start).Take(arg.Length);

            return new Response<OrderViewModel>(arg.Draw, 1000, 100, orders.ToList());
        }
    }
}