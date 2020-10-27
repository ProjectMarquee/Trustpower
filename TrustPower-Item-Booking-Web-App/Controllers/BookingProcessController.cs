using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using TrustPower_Item_Booking_Web_App.Models;
using Microsoft.AspNetCore.Session;

namespace TrustPower_Item_Booking_Web_App.Controllers
{

    
    public class BookingProcessController : Controller
    {
        public class HomeController : Controller
        {
            private readonly IHttpContextAccessor _httpContextAccessor;
            public HomeController(IHttpContextAccessor httpContextAccessor)
            {
                this._httpContextAccessor = httpContextAccessor;
            }
            //Write your action methods here
        }

        private readonly BookingDBContext _context;

        public BookingProcessController(BookingDBContext context)
        {
            _context = context;
        }

        public class ViewModel
        {
            public IEnumerable<Items> Items { get; set; }
            public IEnumerable<Bookings> Bookings { get; set; }
        }

        public  ActionResult TermsOfService()
        {
           
            

            
            return View();
        }
        public async Task<ActionResult> Index()
        {

            ViewModel mymodel = new ViewModel();

            var bookingDBContext = _context.Items;



            mymodel.Items = _context.Items;
            mymodel.Bookings = _context.Bookings;



            return View(mymodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Record(string PickUpDate, string ReturnDate, string ItemName )
        {

           
            Response.Cookies.Append("PickUpDate", PickUpDate);
            Response.Cookies.Append("ReturnDate", ReturnDate);
            Response.Cookies.Append("ItemName", ItemName);

            

            return View("../BookingProcess/InputAddress");
            
            
        }

        public async Task<IActionResult> Index1()
        {
            var bookingDBContext = _context.Items.Include(i => i.Depot);
            return View(await bookingDBContext.ToListAsync());
            
        }

        public IActionResult InputAddress()
        {
            return View();
        }
        public IActionResult InputApplicant()
        {
            return View();
        }
        public IActionResult Confirmation()
        {
            return View();
        }
        public  async Task<IActionResult> BookingsList()
        {

           int applicantsId = int.Parse(Request.Cookies["ApplicantId"]);


            var bookingDBContext = _context.Bookings.Where(b => b.ApplicantsId == applicantsId).Include(b => b.Address).Include(b => b.Applicants).Include(b => b.Staff).Include(b=>b.Tracking);
           
            return View(await bookingDBContext.ToListAsync());
            
        }
        // GET: Bookings/Edit/5
        public async Task<IActionResult> EditBooking(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var bookings = await _context.Bookings.FindAsync(id);
            var bookings = await _context.Bookings.FindAsync(id);
            if (bookings == null)
            {
                return NotFound();
            }

            

            Response.Cookies.Append("EditApplicantId", bookings.ApplicantsId.ToString());
            Response.Cookies.Append("EditAddressId", bookings.ApplicantsId.ToString());
            Response.Cookies.Append("AddressId", bookings.ApplicantsId.ToString());





            return View(bookings);
        }
        

    }


}
