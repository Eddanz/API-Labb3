using API_Labb3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models_Library;

namespace API_Labb3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPerson _person;

        public PersonController(IPerson person)
        {
            _person = person;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllPersons()
        {
            try
            {
                return Ok(await _person.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to retrive data from database..");
            }
        }

        [HttpGet("interests/id/{id:int}")]
        public async Task<ActionResult> GetPersonInterests(int id)
        {
            try
            {
                var result = await _person.GetInterestsById(id);

                if (result == null)
                {
                    return NotFound($"Person with ID {id} doesn't exist and therefor can't be retrieved");
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to retrive data from database..");
            }
        }

        [HttpGet("links/id/{id:int}")]
        public async Task<ActionResult> GetPersonLinks(int id)
        {
            try
            {
                var result = await _person.GetInterestLinksById(id);

                if (result == null)
                {
                    return NotFound($"Person with ID {id} doesn't exist and therefor can't be retrieved");
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to retrive data from database..");
            }
        }

        [HttpPost("AddInterest")]
        public async Task<ActionResult> AddInterestToPerson(int personId, int interestId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var newPersonInterest = await _person.AddInterest(personId, interestId);
                if (newPersonInterest == null)
                {
                    return NotFound("Person or interest not found.");
                }

                var locationUri = Url.Action("GetPersonInterest", new { personInterestId = newPersonInterest.PersonInterestId });
                return Created(locationUri, newPersonInterest);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to create data to database..");
            }
        }

        [HttpPost("AddLink")]
        public async Task<ActionResult> AddLinkToPerson(int personId, int interestId, string url)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var newLink = await _person.AddLink(personId, interestId, url);
                if (newLink == null)
                {
                    return NotFound("Person or interest not found.");
                }

                var locationUri = Url.Action("GetInterestLink", new { interestLinkId = newLink.InterestLinkId });
                return Created(locationUri, newLink);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to create data to database..");
            }
        }
    }
}
