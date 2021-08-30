using GabrielAreiaAPI.Models;
using GabrielAreiaAPI.ResumeDb;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GabrielAreiaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GoalsController : ItemBaseController<Goal, Goal>
    {
        public GoalsController(IRepository<Goal> itensRepo) : base(itensRepo)
        {

        }

        public override Goal[] SelectItems(int matchId)
        {
            return _itemsRepo.All.Where(i => i.ResumeId == matchId).ToArray();
        }

        public override Goal[] SelectFullItems(int matchId)
        {
            return SelectItems(matchId);
        }
    }
}
