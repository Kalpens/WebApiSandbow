using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Logic.Context;
using Logic.Entities;
using Logic;

namespace WebApiSandbox.Controllers
{
    public class ComputersController : ApiController
    {
        private IRepository<Computer> db = new DllFacade().getComputerRepository();

        // GET: api/Computers
        public List<Computer> GetComputer()
        {
            return db.Read();
        }

        // GET: api/Computers/5
        [ResponseType(typeof(Computer))]
        public IHttpActionResult GetComputer(string id)
        {
            Computer computer = db.Read(id);
            if (computer == null)
            {
                var pc = new Computer() {
                    browserAmmount = 0,
                    BrowserUrl = "",
                    MacAddress = id,
                    OpenBrowser = false
                };
                db.Create(pc);
                computer = db.Read(id);
                if (computer == null)
                {
                    return NotFound();
                }
            }

            return Ok(computer);
        }

        // PUT: api/Computers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutComputer(string id, Computer computer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != computer.MacAddress)
            {
                return BadRequest();
            }

            db.Update(computer);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Computers
        [ResponseType(typeof(Computer))]
        public IHttpActionResult PostComputer(Computer computer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Create(computer);

            return CreatedAtRoute("DefaultApi", new { id = computer.MacAddress }, computer);
        }

        // DELETE: api/Computers/5
        [ResponseType(typeof(Computer))]
        public IHttpActionResult DeleteComputer(string id)
        {
            Computer computer = db.Read(id);
            if (computer == null)
            {
                return NotFound();
            }

            db.Delete(id);

            return Ok(computer);
        }
    }
}