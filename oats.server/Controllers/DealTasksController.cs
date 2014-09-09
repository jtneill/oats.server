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
using oats.server.Models;

namespace oats.server.Controllers
{
    public class DealTasksController : ApiController
    {
        private OatsServerContext db = new OatsServerContext();

        // GET: api/DealTasks
        public IQueryable<DealTask> GetDealTasks()
        {
            return db.DealTasks;
        }

        // GET: api/DealTasks/5
        [ResponseType(typeof(DealTask))]
        public IHttpActionResult GetDealTask(int id)
        {
            DealTask dealTask = db.DealTasks.Find(id);
            if (dealTask == null)
            {
                return NotFound();
            }

            return Ok(dealTask);
        }

        // PUT: api/DealTasks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDealTask(int id, DealTask dealTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dealTask.Id)
            {
                return BadRequest();
            }

            db.Entry(dealTask).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DealTaskExists(id))
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

        // POST: api/DealTasks
        [ResponseType(typeof(DealTask))]
        public IHttpActionResult PostDealTask(DealTask dealTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DealTasks.Add(dealTask);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dealTask.Id }, dealTask);
        }

        // DELETE: api/DealTasks/5
        [ResponseType(typeof(DealTask))]
        public IHttpActionResult DeleteDealTask(int id)
        {
            DealTask dealTask = db.DealTasks.Find(id);
            if (dealTask == null)
            {
                return NotFound();
            }

            db.DealTasks.Remove(dealTask);
            db.SaveChanges();

            return Ok(dealTask);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DealTaskExists(int id)
        {
            return db.DealTasks.Count(e => e.Id == id) > 0;
        }
    }
}