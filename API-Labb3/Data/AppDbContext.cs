using Microsoft.EntityFrameworkCore;
using Models_Library;

namespace API_Labb3.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<InterestLink> Interestlinks { get; set; }
        public DbSet<PersonInterest> PersonInterests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Person configuration
            modelBuilder.Entity<Person>()
                .HasKey(p => p.PersonId);

            modelBuilder.Entity<Person>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Person>()
                .Property(p => p.PhoneNumber)
                .HasMaxLength(15);

            modelBuilder.Entity<Person>()
                .HasMany(p => p.PersonInterests)
                .WithOne(pi => pi.Person)
                .HasForeignKey(pi => pi.PersonId);

            // Interest configuration
            modelBuilder.Entity<Interest>()
                .HasKey(i => i.InterestId);

            modelBuilder.Entity<Interest>()
                .Property(i => i.Title)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Interest>()
                .Property(i => i.Description)
                .HasColumnType("nvarchar(max)");

            modelBuilder.Entity<Interest>()
                .HasMany(i => i.PersonInterests)
                .WithOne(pi => pi.Interest)
                .HasForeignKey(pi => pi.InterestId);

            // InterestLink configuration
            modelBuilder.Entity<InterestLink>()
                .HasKey(il => il.InterestLinkId);

            modelBuilder.Entity<InterestLink>()
                .HasOne(il => il.PersonInterest)
                .WithMany(pi => pi.InterestLinks)
                .HasForeignKey(il => il.PersonInterestId);

            modelBuilder.Entity<InterestLink>()
                .Property(il => il.Url)
                .HasMaxLength(200);

            // PersonInterest configuration
            modelBuilder.Entity<PersonInterest>()
                .HasKey(pi => pi.PersonInterestId);

            modelBuilder.Entity<PersonInterest>()
                .HasOne(pi => pi.Person)
                .WithMany(p => p.PersonInterests)
                .HasForeignKey(pi => pi.PersonId);

            modelBuilder.Entity<PersonInterest>()
                .HasOne(pi => pi.Interest)
                .WithMany(i => i.PersonInterests)
                .HasForeignKey(pi => pi.InterestId);

            //Test data Person
            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = 1,
                Name = "Eddie Halling",
                PhoneNumber = "0704862648"
            });

            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = 2,
                Name = "Sara Liljedahl",
                PhoneNumber = "0704126534"
            });

            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = 3,
                Name = "Vincent Johansson",
                PhoneNumber = "0704734977"
            });

            //Test data Interest
            modelBuilder.Entity<Interest>().HasData(new Interest
            {
                InterestId = 1,
                Title = "Fotografering",
                Description = "Fotografering är en kreativ hobby och konstform där man fångar bilder med en kamera. " +
                "Det ger möjlighet att uttrycka sig, dokumentera ögonblick och utforska olika perspektiv. " +
                "Fotografer kan fokusera på områden som natur, porträtt eller evenemang. " +
                "Hobbyn kombinerar teknisk kunskap om kameror och bildkomposition med ett öga för estetik, " +
                "vilket gör det till en uppskattad sysselsättning både professionellt och som fritidsintresse."
            });

            modelBuilder.Entity<Interest>().HasData(new Interest
            {
                InterestId = 2,
                Title = "Gaming",
                Description = "Gaming är en populär hobby där spelare interagerar med digitala spel på olika plattformar som datorer, " +
                "konsoler och mobila enheter. Det erbjuder en bred variation av genrer, från strategi och äventyr till sport och action, " +
                "vilket möjliggör både underhållning och mental utmaning. Spelare kan utforska virtuella världar, tävla mot andra, eller samarbeta i team. " +
                "Gaming förbättrar problemlösningsförmåga, hand-ögon-koordination och sociala färdigheter, och kan även vara en väg till professionell e-sport."
            });

            modelBuilder.Entity<Interest>().HasData(new Interest
            {
                InterestId = 3,
                Title = "Hästar",
                Description = "Hästar är fascinerande och ädla djur som engagerar människor världen över, både som husdjur och inom olika ridsporter. " +
                "De används inom ridskola, dressyr, hoppning och westernridning. " +
                "Att arbeta med hästar främjar fysisk aktivitet, ansvarskänsla och en djupare förståelse för djur. " +
                "Många upplever ridning som terapeutiskt och avkopplande. " +
                "Intresset för hästar kan även leda till yrken som stallskötare, tränare eller veterinär, " +
                "vilket gör det till ett berikande och mångsidigt intresse."
            });

            modelBuilder.Entity<Interest>().HasData(new Interest
            {
                InterestId = 4,
                Title = "Läsning",
                Description = "Läsning är en berikande hobby som öppnar dörrar till olika världar och perspektiv genom böcker. " +
                "Den erbjuder både underhållning och kunskap, från historiska berättelser till framtida spekulationer. " +
                "Läsare kan dyka in i skönlitteratur för att fly verkligheten eller utforska facklitteratur för att lära sig nya fakta och färdigheter. " +
                "Läsning stärker ordförrådet, förbättrar minnet och analytiska förmågor, och ger en lugn stund i en annars hektisk vardag. " +
                "Det är ett intresse som enkelt kan anpassas till varje livsstil."
            });

            modelBuilder.Entity<Interest>().HasData(new Interest
            {
                InterestId = 5,
                Title = "Vandring och friluftsliv",
                Description = "Vandring och friluftsliv är populära aktiviteter som ger människor möjlighet att komma närmare naturen och främja fysisk hälsa. " +
                "Dessa aktiviteter inkluderar allt från lätta promenader i lokala parker till utmanande bergsbestigningar. " +
                "Vandring erbjuder en unik kombination av motion, äventyr och avkoppling. Många uppskattar möjligheten att andas frisk luft, " +
                "uppleva vilda landskap och observera djur i deras naturliga miljö. Friluftsliv kan även innebära camping, paddling och fågelskådning, " +
                "vilket gör det till ett mångsidigt och berikande intresse."
            });

            //Test data PersonInterest
            modelBuilder.Entity<PersonInterest>().HasData(new PersonInterest
            {
                PersonInterestId = 1,
                PersonId = 1,
                InterestId = 1
            });

            modelBuilder.Entity<PersonInterest>().HasData(new PersonInterest
            {
                PersonInterestId = 2,
                PersonId = 1,
                InterestId = 2
            });

            modelBuilder.Entity<PersonInterest>().HasData(new PersonInterest
            {
                PersonInterestId = 3,
                PersonId = 1,
                InterestId = 5
            });

            modelBuilder.Entity<PersonInterest>().HasData(new PersonInterest
            {
                PersonInterestId = 4,
                PersonId = 2,
                InterestId = 3
            });

            modelBuilder.Entity<PersonInterest>().HasData(new PersonInterest
            {
                PersonInterestId = 5,
                PersonId = 2,
                InterestId = 4
            });

            modelBuilder.Entity<PersonInterest>().HasData(new PersonInterest
            {
                PersonInterestId = 6,
                PersonId = 3,
                InterestId = 2
            });

            modelBuilder.Entity<PersonInterest>().HasData(new PersonInterest
            {
                PersonInterestId = 7,
                PersonId = 3,
                InterestId = 5
            });

            //Test data InterestLink
            modelBuilder.Entity<InterestLink>().HasData(new InterestLink
            {
                InterestLinkId = 1,
                PersonInterestId = 1,
                Url = "https://digitalfotoforalla.se/fotografering"
            });

            modelBuilder.Entity<InterestLink>().HasData(new InterestLink
            {
                InterestLinkId = 2,
                PersonInterestId = 2,
                Url = "https://gamerant.com/gaming/"
            });

            modelBuilder.Entity<InterestLink>().HasData(new InterestLink
            {
                InterestLinkId = 3,
                PersonInterestId = 3,
                Url = "https://www.friluftsframjandet.se/lat-aventyret-borja/hitta-aventyr/vandring/"
            });

            modelBuilder.Entity<InterestLink>().HasData(new InterestLink
            {
                InterestLinkId = 4,
                PersonInterestId = 4,
                Url = "https://hastsverige.se/om-hasten/"
            });

            modelBuilder.Entity<InterestLink>().HasData(new InterestLink
            {
                InterestLinkId = 5,
                PersonInterestId = 5,
                Url = "https://www.adlibris.com/se"
            });

            modelBuilder.Entity<InterestLink>().HasData(new InterestLink
            {
                InterestLinkId = 6,
                PersonInterestId = 6,
                Url = "https://www.pcgamer.com/news/"
            });

            modelBuilder.Entity<InterestLink>().HasData(new InterestLink
            {
                InterestLinkId = 7,
                PersonInterestId = 7,
                Url = "https://www.reldinadventures.com/tips-om-vandring-och-friluftsliv-for-nyborjaren/"
            });
        }
    }
}
