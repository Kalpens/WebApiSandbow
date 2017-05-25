using Logic.Entities;
using Logic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class DllFacade
    {
        public IRepository<Computer> getComputerRepository()
        {
            return new ComputerRepository();
        }
    }
}
