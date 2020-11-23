using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.DailyReport
{
    public class PaidClent
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string PaymentMethod { get; set; }

        public double Amount { get; set; }

        public override string ToString()
        {
            return $"{FirstName}\t{LastName}\t{Email}\t{Phone}";
        }
    }
}
