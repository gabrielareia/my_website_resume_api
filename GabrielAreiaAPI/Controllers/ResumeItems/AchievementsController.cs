using GabrielAreiaAPI.Models;
using GabrielAreiaAPI.ResumeDb;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GabrielAreiaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AchievementsController : ItemBaseController<Achievement, Achievement>
    {
        public AchievementsController(IRepository<Achievement> itensRepo) : base(itensRepo)
        {
        }

        public override Achievement[] SelectItems(int matchId)
        {
            return _itemsRepo.All.Where(i => i.ResumeId == matchId).ToArray();
        }

        public override Achievement[] SelectFullItems(int matchId)
        {
            return SelectItems(matchId);
        }

    }
}
