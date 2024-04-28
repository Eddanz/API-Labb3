using API_Labb3.Data;
using Microsoft.EntityFrameworkCore;
using Models_Library;

namespace API_Labb3.Services
{
    public class PersonRepository : IPerson
    {
        private AppDbContext _appContext;
        public PersonRepository(AppDbContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _appContext.Persons.Include(p => p.PersonInterests).ThenInclude(pi => pi.InterestLinks).ToListAsync();
        }

        public async Task<IEnumerable<Interest>> GetInterestsById(int id)
        {
            var result = await _appContext.PersonInterests.Where(p => p.PersonId == id).Select(p => p.Interest).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<string>> GetInterestLinksById(int id)
        {
            var result = await _appContext.PersonInterests.Where(p => p.PersonId == id).SelectMany(p => p.InterestLinks).Select(il => il.Url).ToListAsync();
            return result;
        }

        public async Task<PersonInterest> AddInterest(int personId, int interestId)
        {
            var personInterest = _appContext.PersonInterests.FirstOrDefault(pi => pi.PersonId == personId && pi.InterestId == interestId);

            if (personInterest == null)
            {
                personInterest = new PersonInterest
                {
                    PersonId = personId,
                    InterestId = interestId
                };
                _appContext.PersonInterests.Add(personInterest);
            }

            await _appContext.SaveChangesAsync();
            return personInterest;
        }

        public async Task<InterestLink> AddLink(int personId, int interestId, string url)
        {
            var personInterest = _appContext.PersonInterests.FirstOrDefault(pi => pi.PersonId == personId && pi.InterestId == interestId);

            if (personInterest == null)
            {
                personInterest = new PersonInterest
                {
                    PersonId = personId,
                    InterestId = interestId
                };
                _appContext.PersonInterests.Add(personInterest);
            }

            var interestLink = new InterestLink
            {
                PersonInterestId = personInterest.PersonInterestId,
                Url = url
            };
            _appContext.Interestlinks.Add(interestLink);

            await _appContext.SaveChangesAsync();
            return interestLink;
        }

    }
}
