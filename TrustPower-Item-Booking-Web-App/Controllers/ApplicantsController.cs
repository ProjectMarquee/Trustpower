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
    public class ApplicantsController : Controller
    {
        

        private readonly BookingDBContext _context;

        public ApplicantsController(BookingDBContext context)
        {
            _context = context;
        }

        // GET: Applicants
        public async Task<IActionResult> Index()
        {
            var bookingDBContext = _context.Applicants.Include(a => a.Address);
            return View(await bookingDBContext.ToListAsync());
        }

        // GET: Applicants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicants = await _context.Applicants
                .Include(a => a.Address)
                .FirstOrDefaultAsync(m => m.ApplicantId == id);
            if (applicants == null)
            {
                return NotFound();
            }

            return View(applicants);
        }

        // GET: Applicants/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: Applicants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicantId,FirstName,Surname,Password,Email,MobileNumber,PhoneNumber,OrganisationName,AddressId")] Applicants applicants)
        {
            
            if (ModelState.IsValid)
            {
                _context.Add(applicants);
                
                await _context.SaveChangesAsync();

                Response.Cookies.Append("ApplicantId", applicants.ApplicantId.ToString());
                return View("../BookingProcess/InputBooking");
            }
          
            return View(applicants);
        }

        // GET: Applicants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicants = await _context.Applicants.FindAsync(id);
            if (applicants == null)
            {
                return NotFound();
            }
         //   ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "PostCode", applicants.AddressId);
            return View(applicants);
        }

        // POST: Applicants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApplicantId,FirstName,Surname,Password,Email,MobileNumber,PhoneNumber,OrganisationName,AddressId")] Applicants applicants)
        {
            if (id != applicants.ApplicantId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicants);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicantsExists(applicants.ApplicantId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
         //   ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "PostCode", applicants.AddressId);
            return View(applicants);
        }

        // GET: Applicants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicants = await _context.Applicants
                .Include(a => a.Address)
                .FirstOrDefaultAsync(m => m.ApplicantId == id);
            if (applicants == null)
            {
                return NotFound();
            }

            return View(applicants);
        }

        // POST: Applicants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var applicants = await _context.Applicants.FindAsync(id);
            _context.Applicants.Remove(applicants);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicantsExists(int id)
        {
            return _context.Applicants.Any(e => e.ApplicantId == id);
        }
    }
}
