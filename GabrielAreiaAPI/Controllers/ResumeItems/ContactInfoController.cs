using GabrielAreiaAPI.Models;
using GabrielAreiaAPI.ResumeDb;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GabrielAreiaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactInfoController : ControllerBase
    {
        private readonly IRepository<ContactInfo> _itensRepo;
        private readonly IResumeItemsController<Cellphone, Cellphone> _cellphones;
        private readonly IResumeItemsController<Email, Email> _emailAddresses;
        private readonly IResumeItemsController<Website, Website> _websites;

        public ContactInfoController(IRepository<ContactInfo> itensRepo,
            IResumeItemsController<Cellphone, Cellphone> cellphones,
            IResumeItemsController<Email, Email> emailAddresses, IResumeItemsController<Website, Website> websites)
        {
            _itensRepo = itensRepo;

            _cellphones = cellphones;
            _emailAddresses = emailAddresses;
            _websites = websites;
        }

        [HttpGet("{id}")]
        public IActionResult GetInfo(int id)
        {
            ContactInfoApi contactApi = SelectContactInfoApi(id);

            if (contactApi == null)
            {
                return NotFound("The id was not found.");
            }

            return Ok(contactApi);
        }


        [HttpGet("full/{id}")]
        public IActionResult GetFullInfo(int id)
        {
            ContactInfo contact = SelectContactInfo(id);

            if (contact == null)
            {
                return NotFound("The id was not found.");
            }

            return Ok(contact);

        }

        [Authorize]
        [HttpPost]
        public IActionResult PostInfo([FromBody] ContactInfo contact)
        {
            if (ModelState.IsValid)
            {
                ContactInfoApi contactApi = InsertContactInfo(contact);
                return Ok(contactApi);
            }
            return BadRequest("Somethig was wrong in the request.");
        }

        [Authorize]
        [HttpPost("full")]
        public IActionResult PostFullInfo([FromBody] ContactInfo contactModel)
        {
            if (ModelState.IsValid)
            {
                ContactInfoApi contact = InsertContactInfoModel(contactModel);
                return Ok(contact);
            }
            return BadRequest("Somethig was wrong in the request.");
        }


        [Authorize]
        [HttpPut]
        public IActionResult PutInfo([FromBody] ContactInfo contact)
        {
            if (ModelState.IsValid)
            {
                _itensRepo.Update(contact);
                return Ok(contact);
            }
            return BadRequest("Somethig was wrong in the request.");
        }


        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteContactInfo(int id)
        {
            ContactInfo cont = _itensRepo.Find(id);

            if (cont == null)
            {
                return NotFound("The id was not found.");
            }

            _itensRepo.Delete(cont);

            return Ok(cont);
        }

        [NonAction]
        public ContactInfo SelectContactInfo(int id)
        {
            ContactInfo contact = _itensRepo.Find(id);

            if (contact == null)
            {
                return null;
            }

            contact.Cellphones = _cellphones.SelectFullItems(id);
            contact.EmailAddresses = _emailAddresses.SelectFullItems(id);
            contact.Websites = _websites.SelectFullItems(id);

            return contact;
        }

        [NonAction]
        public ContactInfoApi SelectContactInfoApi(int matchId)
        {
            ContactInfoApi contactApi = _itensRepo.Find(matchId).ToApi();

            if (contactApi == null)
            {
                return null;
            }

            contactApi.Cellphones = _cellphones.SelectItems(matchId).ToStringArray();
            contactApi.EmailAddresses = _emailAddresses.SelectItems(matchId).ToStringArray();
            contactApi.Websites = _websites.SelectItems(matchId).ToStringArray();

            return contactApi;
        }

        [NonAction]
        public ContactInfoApi InsertContactInfoModel(ContactInfo contact)
        {
            if (contact == null)
                return null;

            _itensRepo.Insert(contact);

            return SelectContactInfoApi(contact.Id);
        }

        [NonAction]
        public ContactInfoApi InsertContactInfo(ContactInfo item)
        {
            if (item == null)
                return null;

            _itensRepo.Insert(item);

            return SelectContactInfoApi(item.Id);
        }

    }
}
