using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Classes
{
    public class Booking
    {
        public int BookingID { get; set; }
        public User User { get; set; }
        public Book Book { get; set; }
        public Boolean Returned { get; set; }
    }
}
