using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JohannMovies.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }

        /*Percentage between 0 and 100% */
        public byte DiscountRate { get; set; }

    }
}