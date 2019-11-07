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
using CGAirlines;

namespace CGAirlines.Controllers
{
    public class FlightController : ApiController
    {
        private DB_OARSEntities db = new DB_OARSEntities();

        // GET: api/Flight
        public IQueryable<tblFlight> GettblFlights()
        {
            return db.tblFlights;
        }

        // GET: api/Flight/5
        [ResponseType(typeof(tblFlight))]
        public IHttpActionResult GettblFlight(int id)
        {
            tblFlight tblFlight = db.tblFlights.Find(id);
            if (tblFlight == null)
            {
                return NotFound();
            }

            return Ok(tblFlight);
        }

        // PUT: api/Flight/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblFlight(int id, tblFlight tblFlight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblFlight.FlightID)
            {
                return BadRequest();
            }

            db.Entry(tblFlight).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblFlightExists(id))
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

        // POST: api/Flight
        [ResponseType(typeof(tblFlight))]
        public IHttpActionResult PosttblFlight(tblFlight tblFlight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblFlights.Add(tblFlight);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblFlight.FlightID }, tblFlight);
        }

        // DELETE: api/Flight/5
        [ResponseType(typeof(tblFlight))]
        public IHttpActionResult DeletetblFlight(int id)
        {
            tblFlight tblFlight = db.tblFlights.Find(id);
            if (tblFlight == null)
            {
                return NotFound();
            }

            db.tblFlights.Remove(tblFlight);
            db.SaveChanges();

            return Ok(tblFlight);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblFlightExists(int id)
        {
            return db.tblFlights.Count(e => e.FlightID == id) > 0;
        }
    }
}