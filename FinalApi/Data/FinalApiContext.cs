using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinalApi.Models;

namespace FinalApi.Data
{
    public class FinalApiContext : DbContext
    {
        public FinalApiContext (DbContextOptions<FinalApiContext> options)
            : base(options)
        {
        }

        public DbSet<FinalApi.Models.Catedratico> Catedratico { get; set; }
    }
}
