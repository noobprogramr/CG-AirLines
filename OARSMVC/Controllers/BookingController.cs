using OARSMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace OARSMVC.Controllers
{
    public class BookingController : Controller
    {
        // GET: Flight
        public ActionResult Index()
        {
            IEnumerable<tblGuest> guests = null;
            IEnumerable<tblBooking> bookings = null;
            IEnumerable<tblFlight> flights = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:60555/api/");

                
                var guestResponseTask = client.GetAsync("guest");
                guestResponseTask.Wait();

                var bookingResponseTask = client.GetAsync("booking");
                bookingResponseTask.Wait();

                var flightResponseTask = client.GetAsync("flight");
                flightResponseTask.Wait();

                var guestResult = guestResponseTask.Result;
                var bookingResult = guestResponseTask.Result;
                var flightResult = guestResponseTask.Result;

                if (guestResult.IsSuccessStatusCode)
                {
                    var guestTask = guestResult.Content.ReadAsAsync<IList<tblGuest>>();
                    guestTask.Wait();

                    guests = guestTask.Result;

                }
                if (bookingResult.IsSuccessStatusCode)
                {
                    var bookingTask = bookingResult.Content.ReadAsAsync<IList<tblBooking>>();
                    bookingTask.Wait();

                    bookings = bookingTask.Result;

                }
                if (flightResult.IsSuccessStatusCode)
                {
                    var flightTask = flightResult.Content.ReadAsAsync<IList<tblFlight>>();
                    flightTask.Wait();

                    flights = flightTask.Result;

                }
                else //web api sent error response 
                {
                    //log response status here..

                    guests = Enumerable.Empty<tblGuest>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            int id = guests.Where(g => g.GuestID == 1).Select(g => g.GuestID).ToList()[0]; 
            //ViewBag.Booking_ID = bookings.Where(b => b.GuestID == id).Select(b => b.BookingID);
            //ViewBag.Flight_ID = bookings.First(f=>f.)

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(guests);

        }
            // GET: Booking/Details/5
            public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Booking/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Booking/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Booking/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Booking/Edit/5
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

        // GET: Booking/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Booking/Delete/5
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
    }
}
