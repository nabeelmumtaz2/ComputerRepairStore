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
using ComputerRepair;

namespace ComputerRepairAPI.Controllers
{
    public class SystemsController : ApiController
    {
        private CrContainer db = new CrContainer();

        // GET: api/Systems
        public IQueryable<Systems> GetSystems1()
        {
            return db.Systems1;
        }

        // GET: api/Systems/5
        [ResponseType(typeof(Systems))]
        public IHttpActionResult GetSystems(int id)
        {
            Systems systems = db.Systems1.Find(id);
            if (systems == null)
            {
                return NotFound();
            }

            return Ok(systems);
        }

        // PUT: api/Systems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSystems(int id, Systems systems)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != systems.System_Id)
            {
                return BadRequest();
            }

            db.Entry(systems).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SystemsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Systems
        [ResponseType(typeof(Systems))]
        public IHttpActionResult PostSystems(Systems systems)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Systems1.Add(systems);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = systems.System_Id }, systems);
        }

        // DELETE: api/Systems/5
        [ResponseType(typeof(Systems))]
        public IHttpActionResult DeleteSystems(int id)
        {
            Systems systems = db.Systems1.Find(id);
            if (systems == null)
            {
                return NotFound();
            }

            db.Systems1.Remove(systems);
            db.SaveChanges();

            return Ok(systems);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SystemsExists(int id)
        {
            return db.Systems1.Count(e => e.System_Id == id) > 0;
        }
    }
}