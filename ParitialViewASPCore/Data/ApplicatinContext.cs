
using Microsoft.EntityFrameworkCore;
using ParitialViewASPCore.Models;

namespace ParitialViewASPCore.Data
{
    public class ApplicatinContext : DbContext
    {
        public ApplicatinContext(DbContextOptions<ApplicatinContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }


    }
}
