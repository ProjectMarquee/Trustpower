using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TrustPower_Item_Booking_Web_App.Controllers
{
    public class ApplicantBookingProcessController : Controller
    {
        public IActionResult ItemCalandar()
        {
            return View();
        }
        public IActionResult Form()
        {
            return View();
        }
        public IActionResult TermsOfService()
        {
            return View();
        }
        public IActionResult Confirmation()
        {
            return View();
        }
        public IActionResult Bookings()
        {
            return View();
        }
    }
}
