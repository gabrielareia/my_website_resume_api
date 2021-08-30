using GabrielAreiaAPI.Models;
using GabrielAreiaAPI.ResumeDb;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GabrielAreiaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CellphoneNumbersController : ItemBaseController<Cellphone, Cellphone>
    {
        public CellphoneNumbersController(IRepository<Cellphone> itensRepo) : base(itensRepo)
        {
        }

        public override Cellphone[] SelectItems(int matchId)
        {
            return _itemsRepo.All.Where(i => i.ContactInfoId == matchId).ToArray();
        }
        public override Cellphone[] SelectFullItems(int matchId)
        {
            return SelectItems(matchId);
        }
    }
}
