using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TrustPower_Item_Booking_Web_App.Controllers
{
    public class quickController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
