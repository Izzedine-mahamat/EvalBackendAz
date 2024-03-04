using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvalBackendAz.DAL
{
    public class EvalBackendAzDbContextFactory
    {
        public EvalBackendAzDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EvalBackendAzDbContext>();
            optionsBuilder.UseSqlServer("EvalBackendAZ");

            return new EvalBackendAzDbContext(optionsBuilder.Options);
        }
    }
}
