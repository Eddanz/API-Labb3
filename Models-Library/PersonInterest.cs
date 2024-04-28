using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_Library
{
    public class PersonInterest
    {
        public int PersonInterestId { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int InterestId { get; set; }
        public Interest Interest { get; set; }
        public ICollection<InterestLink> InterestLinks { get; set; } = new List<InterestLink>();
    }
}
