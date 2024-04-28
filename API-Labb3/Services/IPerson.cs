
using Models_Library;

namespace API_Labb3.Services
{
    public interface IPerson
    {
        Task<IEnumerable<Person>> GetAll();
        Task<IEnumerable<Interest>> GetInterestsById(int id);
        Task<IEnumerable<string>> GetInterestLinksById(int id);
        Task <PersonInterest>AddInterest(int personId, int interestId);
        Task <InterestLink>AddLink(int personId, int interestId, string url);
    }
}
