using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_Library
{
    public class Interest
    {
        public int InterestId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public ICollection<PersonInterest> PersonInterests { get; set; } = new List<PersonInterest>();
    }
}
