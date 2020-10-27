using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrustPower_Item_Booking_Web_App.Models;

namespace TrustPower_Item_Booking_Web_App.Controllers
{
    public class EditBookingProcessController : Controller
    {

        private readonly BookingDBContext _context;

        public EditBookingProcessController(BookingDBContext context)
        {
            _context = context;
        }

        public class ViewModel
        {
            public IEnumerable<Items> Items { get; set; }
            public IEnumerable<Bookings> Bookings { get; set; }
        }


        // GET: EditBookingProcessController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: EditBookingProcessController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EditBookingProcessController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EditBookingProcessController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EditBookingProcessController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EditBookingProcessController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EditBookingProcessController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EditBookingProcessController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> EditBooking(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewModel mymodel = new ViewModel();

            var bookingDBContext = _context.Items;



            mymodel.Items = _context.Items;
            mymodel.Bookings = _context.Bookings;



            


            //var bookings = await _context.Bookings.FindAsync(id);
            var bookings = await _context.Bookings.FindAsync(id);




            if (bookings == null)
            {
                return NotFound();
            }



            Response.Cookies.Append("EditApplicantId", bookings.ApplicantsId.ToString());
            Response.Cookies.Append("EditAddressId", bookings.AddressId.ToString());
            Response.Cookies.Append("EditBookingId", id.ToString()); ;


            ViewBag.PickUpDate = bookings.PickUpDate.ToString();

            ViewBag.ReturnDate = bookings.ReturnDate.ToString();

            ViewBag.Item = bookings.RequestedItem.ToString();

            return View("../EditBookingProcess/EditIndex", mymodel);
        }
        public ActionResult EditIndex()
        {


            return View();


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeRecord(string PickUpDate, string ReturnDate, string ItemName)
        {

            var address = await _context.Addresses.FindAsync(int.Parse(Request.Cookies["AddressId"]));


            Response.Cookies.Append("EditPickUpDate", PickUpDate);
            Response.Cookies.Append("EditReturnDate", ReturnDate);
            Response.Cookies.Append("EditItemName", ItemName);




            return View("../EditBookingProcess/EditInputAddress", address);


        }
        public ActionResult EditInputAddress()
        {
            return View();
        }
        public ActionResult EditInputApplicant()
        {
            return View();
        }
        public ActionResult EditInputBooking()
        {
            return View();
        }
        public ActionResult EditInputConfirmation()
        {
            return View();
        }
        public ActionResult EditTermsOfService()
        {
            return View();
        }
        
             public async Task<IActionResult> EditBookingsList()
        {

            int applicantsId = int.Parse(Request.Cookies["ApplicantId"]);


            var bookingDBContext = _context.Bookings.Where(b => b.ApplicantsId == applicantsId).Include(b => b.Address).Include(b => b.Applicants).Include(b => b.Staff).Include(b => b.Tracking);

            return View(await bookingDBContext.ToListAsync());

        }
    }
}
