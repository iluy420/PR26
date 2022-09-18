using ModelDB.Syst;
using System.Data.Entity;

namespace ModelDB.Core
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base(Consts.CONNECTION_STRING)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}