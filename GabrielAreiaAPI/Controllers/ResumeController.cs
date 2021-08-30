using GabrielAreiaAPI.ResumeDb;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using GabrielAreiaAPI.Models;

namespace GabrielAreiaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResumeController : ControllerBase
    {
        public readonly IRepository<Resume> _resumeRepo;

        private readonly IResumeItemsController<Goal, Goal> _goals;
        private readonly IResumeItemsController<Ability, AbilityApi> _abilities;
        private readonly IResumeItemsController<Achievement, Achievement> _achievements;
        private readonly IResumeItemsController<Course, CourseApi> _courses;
        private readonly IResumeItemsController<Experience, Experience> _experiences;
        private readonly ContactInfoController _contactInfos;


        public ResumeController(IRepository<Resume> resumeRepo, IResumeItemsController<Goal, Goal> goals, IResumeItemsController<Ability, AbilityApi> abilities, IResumeItemsController<Achievement, Achievement> achievements, IResumeItemsController<Course, CourseApi> course,
            IResumeItemsController<Experience, Experience> experiences, ContactInfoController contactInfos)
        {
            _resumeRepo = resumeRepo;
            _goals = goals;
            _contactInfos = contactInfos;
            _abilities = abilities;
            _achievements = achievements;
            _courses = course;
            _experiences = experiences;
        }

        [HttpGet("{id}")]
        public IActionResult GetResume(int id)
        {
            ResumeApi resumeApi = SelectResumeApi(id);

            if (resumeApi == null)
            {
                return NotFound("The id was not found.");
            }

            return Ok(resumeApi);
        }

        [HttpGet("all")]
        public IActionResult GetAllResumes()
        {
            ResumeApi[] resumeApi = SelectAllResumesApi();

            if (resumeApi == null || resumeApi.Length == 0)
            {
                return NotFound("No resume was found.");
            }

            return Ok(resumeApi);
        }


        [HttpGet("full/{id}")]
        public IActionResult GetFullResume(int id)
        {
            Resume resume = SelectResume(id);

            if (resume == null)
            {
                return NotFound("The id was not found.");
            }

            return Ok(resume);
        }

        [HttpGet("{id}/image")]
        [HttpGet("full/{id}/image")]
        public IActionResult GetImage(int id)
        {
            byte[] img = _resumeRepo.All
                .Where(r => r.Id == id)
                .Select(r => r.Picture)
                .FirstOrDefault();
            if (img != null)
            {
                return File(img, "image/png");
            }
            return NotFound("The image was not found.");
        }

        [Authorize]
        [HttpPost]
        public IActionResult PostResume([FromBody] Resume resume)
        {
            if (ModelState.IsValid)
            {
                ResumeApi resumeApi = InsertResume(resume);
                return Ok(resumeApi);
            }

            return BadRequest("Somethig was wrong in the request.");
        }

        [Authorize]
        [HttpPut]
        public IActionResult PutResume([FromBody] Resume resume)
        {
            if (ModelState.IsValid)
            {
                _resumeRepo.Update(resume);
                return Ok(resume);
            }

            return BadRequest("Somethig was wrong in the request.");
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteResume(int id)
        {
            Resume res = SelectResume(id);

            if (res == null)
            {
                return NotFound("The id was not found.");
            }

            _resumeRepo.Delete(res);

            return Ok(res);
        }

        [Authorize]
        [HttpDelete("full/{id}")]
        public IActionResult DeleteFullResume(int id)
        {
            Resume res = SelectResume(id);

            if (res == null)
            {
                return NotFound("The resume id was not found.");
            }

            _resumeRepo.Delete(res);

            ContactInfo cont = _contactInfos.SelectContactInfo(res.ContactId.Value);

            if (cont != null)
            {
                _contactInfos.DeleteContactInfo(cont.Id);
            }

            return Ok(res);
        }


        [NonAction]
        public Resume SelectResume(int id)
        {
            Resume resume = _resumeRepo.Find(id);

            if (resume == null)
            {
                return null;
            }

            resume.Goals = _goals.SelectFullItems(id);

            if (resume.ContactId != null)
                resume.Contact = _contactInfos.SelectContactInfo(resume.ContactId.Value);

            resume.Abilities = _abilities.SelectFullItems(id);
            resume.Achievements = _achievements.SelectFullItems(id);
            resume.Courses = _courses.SelectFullItems(id);
            resume.Experiences = _experiences.SelectFullItems(id);

            return resume;
        }

        [NonAction]
        public ResumeApi SelectResumeApi(int id)
        {
            Resume resume = _resumeRepo.Find(id);
            ResumeApi resumeApi = resume.ToApi();

            if (resumeApi == null)
            {
                return null;
            }

            resumeApi.Goals = _goals.SelectFullItems(id).ToStringArray();

            if (resume.ContactId != null)
                resumeApi.Contact = _contactInfos.SelectContactInfoApi(resume.ContactId.Value);

            resumeApi.Abilities = _abilities.SelectFullItems(id).ToApiArray();
            resumeApi.Achievements = _achievements.SelectFullItems(id);
            resumeApi.Courses = _courses.SelectFullItems(id).ToApiArray();
            resumeApi.Experiences = _experiences.SelectFullItems(id);

            return resumeApi;
        }

        [NonAction]
        public ResumeApi[] SelectAllResumesApi()
        {
            IQueryable<Resume> repoResumes = _resumeRepo.All;

            if (repoResumes == null || repoResumes.Count() == 0)
                return null;

            Resume[] resumes = repoResumes.ToArray();

            ResumeApi[] result = new ResumeApi[resumes.Length];

            for (int i = 0; i < resumes.Length; i++)
            {
                result[i] = SelectResumeApi(resumes[i].Id);
            }

            return result;
        }

        [NonAction]
        public ResumeApi InsertResumeModel(Resume resume)
        {
            if (resume == null)
                return null;

            _resumeRepo.Insert(resume);

            return SelectResumeApi(resume.Id);
        }

        [NonAction]
        public ResumeApi InsertResume(Resume resume)
        {
            if (resume.Contact != null)
            {
                ContactInfoApi contactAdded = _contactInfos.InsertContactInfo(resume.Contact);
                resume.Contact.Id = contactAdded.Id;
            }

            _resumeRepo.Insert(resume);

            return SelectResumeApi(resume.Id);
        }

    }
}
