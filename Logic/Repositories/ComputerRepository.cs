using Logic.Context;
using Logic.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Repositories
{
    class ComputerRepository : IRepository<Computer>
    {
        public Computer Create(Computer t)
        {
            using (var db = new SandboxContext())
            {
                db.Computer.Add(t);
                db.SaveChanges();
                return t;
            }
        }

        public bool Delete(string macAddress)
        {
            using (var db = new SandboxContext())
            {
                db.Entry(db.Computer.FirstOrDefault(x => x.MacAddress == macAddress)).State = EntityState.Deleted;
                db.SaveChanges();
                return db.Computer.FirstOrDefault(x => x.MacAddress == macAddress) == null;
            }
        }

        public List<Computer> Read()
        {
            using (var db = new SandboxContext())
            {
                return db.Computer.ToList();
            }
        }

        public Computer Read(string macAddress)
        {
            using (var db = new SandboxContext())
            {
                return db.Computer.FirstOrDefault(x => x.MacAddress == macAddress);
            }
        }

        public Computer Update(Computer t)
        {
            using (var db = new SandboxContext())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return t;
            }
        }
    }
}
