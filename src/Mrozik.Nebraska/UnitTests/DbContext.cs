using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mrozik.Nebraska.Models;
using Xunit;
using System.Linq.Dynamic.Core;


namespace Mrozik.Nebraska.UnitTests
{
    public class DbContextTests
    {
        [Fact]
        public async Task ShouldBePossibleToRetrieveOrder()
        {
            using (var context = TestApplicationDbContextFactory.Create())
            {
                var order = await context.Orders.FirstAsync();
                Assert.IsType<Order>(order);
                Assert.NotNull(order);
            }
        }

        [Fact]
        public async Task ShouldBePossibleToRetrieveDepartments()
        {
            using (var context = TestApplicationDbContextFactory.Create())
            {
                var department = await context.Departments.FirstAsync();
                Assert.IsType<Department>(department);
                Assert.NotNull(department);
            }
        }

        [Fact]
        public async Task ShouldBePossibleToQueryOrderWithConditions()
        {
            using (var context = TestApplicationDbContextFactory.Create())
            {
                var order = await context.Orders.SingleOrDefaultAsync(o => o.Number == "2337/2009");
                Assert.NotNull(order);
                Assert.Equal("2337/2009", order.Number);
            }
        }

        [Fact]
        public async Task ShouldBePossibleToQueryOrderWithConditions_WithDynamicLinq()
        {
            using (var context = TestApplicationDbContextFactory.Create())
            {
                var number = "1/2008";
                var order = await context.Orders.Where($"Number=\"{number}\"").FirstOrDefaultAsync();
                Assert.Equal(number, order.Number);
            }
        }
    }
}