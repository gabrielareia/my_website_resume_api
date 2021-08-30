using GabrielAreiaAPI.Models;
using GabrielAreiaAPI.ResumeDb;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GabrielAreiaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ItemBaseController<Course, CourseApi>
    {
        public CoursesController(IRepository<Course> itensRepo) : base(itensRepo)
        {
        }

        public override CourseApi[] SelectItems(int matchId)
        {
            return _itemsRepo.All.Where(i => i.ResumeId == matchId).ToArray().ToApiArray();
        }

        public override Course[] SelectFullItems(int matchId)
        {
            return _itemsRepo.All.Where(i => i.ResumeId == matchId).ToArray();
        }

        [HttpGet("{id}/logo")]
        public IActionResult GetLogo(int id)
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


        [HttpGet("{id}/certificate")]
        public IActionResult GetCertificate(int id)
        {
            byte[] img = _itemsRepo.All
                .Where(i => i.Id == id)
                .Select(i => i.CertificateImage)
                .FirstOrDefault();
            if (img != null)
            {
                return File(img, "image/png");
            }
            return NotFound("The image was not found.");
        }
    }
}
