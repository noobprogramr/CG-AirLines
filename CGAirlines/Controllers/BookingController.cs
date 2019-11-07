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
    public class BookingController : ApiController
    {
        private DB_OARSEntities db = new DB_OARSEntities();

        // GET: api/Booking
        public IQueryable<tblBooking> GettblBookings()
        {
            return db.tblBookings;
        }

        // GET: api/Booking/5
        [ResponseType(typeof(tblBooking))]
        public IHttpActionResult GettblBooking(int id)
        {
            tblBooking tblBooking = db.tblBookings.Find(id);
            if (tblBooking == null)
            {
                return NotFound();
            }

            return Ok(tblBooking);
        }

        // PUT: api/Booking/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblBooking(int id, tblBooking tblBooking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblBooking.BookingID)
            {
                return BadRequest();
            }

            db.Entry(tblBooking).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblBookingExists(id))
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

        // POST: api/Booking
        [ResponseType(typeof(tblBooking))]
        public IHttpActionResult PosttblBooking(tblBooking tblBooking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblBookings.Add(tblBooking);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblBooking.BookingID }, tblBooking);
        }

        // DELETE: api/Booking/5
        [ResponseType(typeof(tblBooking))]
        public IHttpActionResult DeletetblBooking(int id)
        {
            tblBooking tblBooking = db.tblBookings.Find(id);
            if (tblBooking == null)
            {
                return NotFound();
            }

            db.tblBookings.Remove(tblBooking);
            db.SaveChanges();

            return Ok(tblBooking);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblBookingExists(int id)
        {
            return db.tblBookings.Count(e => e.BookingID == id) > 0;
        }
    }
}