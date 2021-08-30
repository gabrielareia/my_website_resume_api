using GabrielAreiaAPI.Models;
using GabrielAreiaAPI.ResumeDb;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GabrielAreiaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailAddressesController : ItemBaseController<Email, Email>
    {
        public EmailAddressesController(IRepository<Email> itensRepo) : base(itensRepo)
        {
        }

        public override Email[] SelectItems(int matchId)
        {
            return _itemsRepo.All.Where(i => i.ContactInfoId == matchId).ToArray();
        }
        public override Email[] SelectFullItems(int matchId)
        {
            return SelectItems(matchId);
        }

    }
}
