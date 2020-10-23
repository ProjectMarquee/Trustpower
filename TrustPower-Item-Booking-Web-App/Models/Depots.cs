using System;
using System.Collections.Generic;

namespace TrustPower_Item_Booking_Web_App.Models
{
    public partial class Depots
    {
        public Depots()
        {
            Items = new HashSet<Items>();
        }

        public int DepotId { get; set; }
        public string DepotName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string StreetName { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }

        public virtual ICollection<Items> Items { get; set; }
    }
}
