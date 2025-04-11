using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartAcademyBackend.DTOs.TutorDTO;
using SmartAcademyBackend.Entities;
using SmartAcademyBackend.Service.TutorService;

namespace SmartAcademyBackend.Controllers.TutorController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorController(ITutorService tutorService) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Tutor?>> addNewTutor(AddTutorDTO newTutor)
        {
            var tutor = await tutorService.addNewTutor(newTutor);
            if (newTutor == null)
                return BadRequest("Tutor exists");
            return Ok();
        }

        [HttpGet("{tutorId}")]
        public async Task<ActionResult<GetTutorInfoDTO?>> addNewTutor(int tutorId)
        {
            var tutor = await tutorService.getTutorById(tutorId);
            if (tutor == null)
                return NotFound("Tutor not found");
            return Ok(tutor);
        }
    }
}
