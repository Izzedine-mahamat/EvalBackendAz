using EvalBackendAz.Entities;
using Microsoft.EntityFrameworkCore;

namespace EvalBackendAz.DAL
{
    public class EvalBackendAzDbContext : DbContext 
    {
        public EvalBackendAzDbContext()
        {
        }
        public EvalBackendAzDbContext(DbContextOptions<EvalBackendAzDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("EvalBackendAZ");
            }
        }

       public  DbSet<Events> events { get; set; }




    }


}
