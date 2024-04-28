using System.ComponentModel.DataAnnotations;

namespace Models_Library
{
    public class Person
    {
            public int PersonId { get; set; }
            public string Name { get; set; }
            public string PhoneNumber { get; set; }
            public ICollection<PersonInterest> PersonInterests { get; set; } = new List<PersonInterest>();
    }
}
