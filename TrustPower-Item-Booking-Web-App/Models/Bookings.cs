using System;
using System.Collections.Generic;

namespace TrustPower_Item_Booking_Web_App.Models
{
    public partial class Bookings
    {
        public Bookings()
        {
            Tracking = new HashSet<Tracking>();
        }

        public int BookingId { get; set; }
        public decimal Fees { get; set; }
        public DateTime DateReceived { get; set; }
        public DateTime? DateOfApproval { get; set; }
        public string EventDescription { get; set; }
        public int? ApprovedByStaffId { get; set; }
        public string DisapprovedDescription { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string EvenStatus { get; set; }
        public string EventName { get; set; }
        public bool SetUpRequested { get; set; }
        public int? StaffId { get; set; }
        public int ApplicantsId { get; set; }
        public int AddressId { get; set; }

        public string RequestedItem { get; set; }

        public virtual Addresses Address { get; set; }
        public virtual Applicants Applicants { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual ICollection<Tracking> Tracking { get; set; }
    }
}
