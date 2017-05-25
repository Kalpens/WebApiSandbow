using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Context
{
    class SandboxDbInitializer : DropCreateDatabaseIfModelChanges<SandboxContext>
    {
        protected override void Seed(SandboxContext context)
        {
            base.Seed(context);
        }
    }
}
