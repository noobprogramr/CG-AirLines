using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OARSMVC.Controllers
{
    public class GuestController : Controller
    {
        private OARSEntities db = new OARSEntities();

       
        // GET: Guest
        public ActionResult Index()
        {
            
            var origin = (from m in db.tblFlights
                         select m.FlightOrigin).Distinct();
            ViewBag.FlightOrigin = new SelectList(origin);

            var destination = (from m in db.tblFlights
                         select m.FlightDestination

           ).Distinct();
            ViewBag.FlightDestination = new SelectList(destination);
            return View(db.tblFlights.ToList());



        }
        //public ActionResult IndexSample()
        //{
        //    var origin = (from m in db.tblFlights
        //                  select m.FlightOrigin).Distinct();
        //    ViewBag.FlightOrigin = new SelectList(origin);

        //    var destination = (from m in db.tblFlights
        //                       select m.FlightDestination

        //   ).Distinct();
        //    ViewBag.FlightDestination = new SelectList(destination);
        //    return View(db.tblFlights.ToList());
        //}

        public ActionResult Search()
        {
            return View(db.tblFlights.ToList());
        }

        // GET: Guest/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Guest/Create
        public ActionResult Create()
        {
            List<tblFlight> flights = db.tblFlights.ToList();
            List<Guest> guests = db.Guests.ToList();
            
            return View();
        }

        // POST: Guest/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "FlightNumber,FlightOrigin,Flight Destination")] Guest guest)
        {
            if (ModelState.IsValid)
            {
                db.Guests.Add(guest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(guest);
        }

        // GET: Guest/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Guest/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Guest/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Guest/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ConfirmBooking()
        {

            return View();
        }
    }
}
