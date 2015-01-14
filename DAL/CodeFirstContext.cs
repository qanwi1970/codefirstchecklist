using System.Data.Entity;
using CodeFirstChecklist.Models;

namespace CodeFirstChecklist.DAL
{
    class CodeFirstContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
    }
}
