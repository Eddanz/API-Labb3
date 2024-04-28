using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_Library
{
    public class InterestLink
    {
        public int InterestLinkId { get; set; }
        public int PersonInterestId { get; set; }
        public PersonInterest PersonInterest { get; set; }
        public string? Url { get; set; }
    }
}
