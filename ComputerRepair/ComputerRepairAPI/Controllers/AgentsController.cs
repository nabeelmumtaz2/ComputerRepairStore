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
    public class AgentsController : ApiController
    {
        private CrContainer db = new CrContainer();

        // GET: api/Agents
        public IQueryable<Agents> GetAgents()
        {
            return db.Agents;
        }

        // GET: api/Agents/5
        [ResponseType(typeof(Agents))]
        public IHttpActionResult GetAgents(int id)
        {
            Agents agents = db.Agents.Find(id);
            if (agents == null)
            {
                return NotFound();
            }

            return Ok(agents);
        }

        // PUT: api/Agents/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAgents(int id, Agents agents)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != agents.Agent_Id)
            {
                return BadRequest();
            }

            db.Entry(agents).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgentsExists(id))
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

        // POST: api/Agents
        [ResponseType(typeof(Agents))]
        public IHttpActionResult PostAgents(Agents agents)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Agents.Add(agents);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = agents.Agent_Id }, agents);
        }

        // DELETE: api/Agents/5
        [ResponseType(typeof(Agents))]
        public IHttpActionResult DeleteAgents(int id)
        {
            Agents agents = db.Agents.Find(id);
            if (agents == null)
            {
                return NotFound();
            }

            db.Agents.Remove(agents);
            db.SaveChanges();

            return Ok(agents);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AgentsExists(int id)
        {
            return db.Agents.Count(e => e.Agent_Id == id) > 0;
        }
    }
}