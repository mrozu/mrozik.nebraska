using Microsoft.EntityFrameworkCore;
using Mrozik.Nebraska.Data;

namespace Mrozik.Nebraska.UnitTests
{
    public static class TestApplicationDbContextFactory
    {
        private const string ConnectionString = "Server=MROZUPC\\SQLEXPRESS;Database=Mrozik.Nebraska;Integrated security=true";
        public static ApplicationDbContext Create()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(ConnectionString);
            return new ApplicationDbContext(optionsBuilder.Options);

        }
    }
}