using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrustPower_Item_Booking_Web_App.Models;

namespace TrustPower_Item_Booking_Web_App.Controllers
{
    public class AdminProcessController : Controller
    {
        private readonly BookingDBContext _context;

        public AdminProcessController(BookingDBContext context)
        {
            _context = context;
        }

        // GET: AdminProcess
        public async Task<IActionResult> Index()
        {
            var bookingDBContext = _context.Bookings.Include(b => b.Address).Include(b => b.Applicants).Include(b => b.Staff);
            return View(await bookingDBContext.ToListAsync());
        }

        // GET: AdminProcess/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookings = await _context.Bookings
                .Include(b => b.Address)
                .Include(b => b.Applicants)
                .Include(b => b.Staff)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (bookings == null)
            {
                return NotFound();
            }

            return View(bookings);
        }

        // GET: AdminProcess/Create
        public IActionResult Create()
        {
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "PostCode");
            ViewData["ApplicantsId"] = new SelectList(_context.Applicants, "ApplicantId", "Email");
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "FirstName");
            return View();
        }

        // POST: AdminProcess/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingId,Fees,DateReceived,DateOfApproval,EventDescription,ApprovedByStaffId,DisapprovedDescription,PickUpDate,ReturnDate,EvenStatus,EventName,SetUpRequested,StaffId,ApplicantsId,AddressId,RequestedItem")] Bookings bookings)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookings);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "PostCode", bookings.AddressId);
            ViewData["ApplicantsId"] = new SelectList(_context.Applicants, "ApplicantId", "Email", bookings.ApplicantsId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "FirstName", bookings.StaffId);
            return View(bookings);
        }

        // GET: AdminProcess/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookings = await _context.Bookings.FindAsync(id);
            if (bookings == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "PostCode", bookings.AddressId);
            ViewData["ApplicantsId"] = new SelectList(_context.Applicants, "ApplicantId", "Email", bookings.ApplicantsId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "FirstName", bookings.StaffId);
            return View(bookings);
        }

        // POST: AdminProcess/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingId,Fees,DateReceived,DateOfApproval,EventDescription,ApprovedByStaffId,DisapprovedDescription,PickUpDate,ReturnDate,EvenStatus,EventName,SetUpRequested,StaffId,ApplicantsId,AddressId,RequestedItem")] Bookings bookings)
        {
            if (id != bookings.BookingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingsExists(bookings.BookingId))
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
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "PostCode", bookings.AddressId);
            ViewData["ApplicantsId"] = new SelectList(_context.Applicants, "ApplicantId", "Email", bookings.ApplicantsId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "FirstName", bookings.StaffId);
            return View(bookings);
        }

        // GET: AdminProcess/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookings = await _context.Bookings
                .Include(b => b.Address)
                .Include(b => b.Applicants)
                .Include(b => b.Staff)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (bookings == null)
            {
                return NotFound();
            }

            return View(bookings);
        }

        // POST: AdminProcess/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookings = await _context.Bookings.FindAsync(id);
            _context.Bookings.Remove(bookings);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingsExists(int id)
        {
            return _context.Bookings.Any(e => e.BookingId == id);
        }
    }
}
