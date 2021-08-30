using GabrielAreiaAPI.Models;
using GabrielAreiaAPI.ResumeDb;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GabrielAreiaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExperienceController : ItemBaseController<Experience, Experience>
    {
        public ExperienceController(IRepository<Experience> itensRepo) : base(itensRepo)
        {
        }

        public override Experience[] SelectItems(int matchId)
        {
            return _itemsRepo.All.Where(i => i.ResumeId == matchId).ToArray();
        }

        public override Experience[] SelectFullItems(int matchId)
        {
            return SelectItems(matchId);
        }
    }
}
