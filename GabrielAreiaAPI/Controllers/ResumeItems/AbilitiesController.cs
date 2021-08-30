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
    public class AbilitiesController : ItemBaseController<Ability, AbilityApi>
    {
        public AbilitiesController(IRepository<Ability> itensRepo) : base(itensRepo)
        {
        }

        public override AbilityApi[] SelectItems(int matchId)
        {
            return _itemsRepo.All.Where(i => i.ResumeId == matchId).ToArray().ToApiArray();
        }
        public override Ability[] SelectFullItems(int matchId)
        {
            return _itemsRepo.All.Where(i => i.ResumeId == matchId).ToArray();
        }

        [HttpGet("{id}/logo")]
        public IActionResult GetImage(int id)
        {
            byte[] img = _itemsRepo.All
                .Where(i => i.Id == id)
                .Select(i => i.Logo)
                .FirstOrDefault();
            if (img != null)
            {
                return File(img, "image/png");
            }
            return NotFound("The image was not found.");
        }
    }
}
