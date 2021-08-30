using GabrielAreiaAPI.Models;
using GabrielAreiaAPI.ResumeDb;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GabrielAreiaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebsitesController : ItemBaseController<Website, Website>
    {
        public WebsitesController(IRepository<Website> itensRepo) : base(itensRepo)
        {
        }

        public override Website[] SelectItems(int matchId)
        {
            return _itemsRepo.All.Where(i => i.ContactInfoId == matchId).ToArray();
        }
        public override Website[] SelectFullItems(int matchId)
        {
            return SelectItems(matchId);
        }

    }
}
