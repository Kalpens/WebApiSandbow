using Logic.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Context
{
    public class SandboxContext : DbContext
    {
        public SandboxContext() : base()
        {
            Database.SetInitializer(new SandboxDbInitializer());
        }
        public DbSet<Computer> Computer { get; set; }
    }
}
