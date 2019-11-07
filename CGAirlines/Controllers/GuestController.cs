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
    public class GuestController : ApiController
    {
        private DB_OARSEntities db = new DB_OARSEntities();

        // GET: api/Guest
        public IQueryable<tblGuest> GettblGuests()
        {
            return db.tblGuests;
        }

        // GET: api/Guest/5
        [ResponseType(typeof(tblGuest))]
        public IHttpActionResult GettblGuest(int id)
        {
            tblGuest tblGuest = db.tblGuests.Find(id);
            if (tblGuest == null)
            {
                return NotFound();
            }

            return Ok(tblGuest);
        }

        // PUT: api/Guest/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblGuest(int id, tblGuest tblGuest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblGuest.GuestID)
            {
                return BadRequest();
            }

            db.Entry(tblGuest).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblGuestExists(id))
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

        // POST: api/Guest
        [ResponseType(typeof(tblGuest))]
        public IHttpActionResult PosttblGuest(tblGuest tblGuest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblGuests.Add(tblGuest);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblGuest.GuestID }, tblGuest);
        }

        // DELETE: api/Guest/5
        [ResponseType(typeof(tblGuest))]
        public IHttpActionResult DeletetblGuest(int id)
        {
            tblGuest tblGuest = db.tblGuests.Find(id);
            if (tblGuest == null)
            {
                return NotFound();
            }

            db.tblGuests.Remove(tblGuest);
            db.SaveChanges();

            return Ok(tblGuest);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblGuestExists(int id)
        {
            return db.tblGuests.Count(e => e.GuestID == id) > 0;
        }
    }
}