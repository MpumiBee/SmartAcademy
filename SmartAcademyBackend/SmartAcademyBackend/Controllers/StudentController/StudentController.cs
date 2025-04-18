using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartAcademyBackend.DTOs.StudentDTOs;
using SmartAcademyBackend.Enums;
using SmartAcademyBackend.Service.StudentService;
using System.Security.Claims;

namespace SmartAcademyBackend.Controllers.StudentController
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(IStudentService studentService) : ControllerBase

    {
        [Authorize(Roles =RoleNames.Student)]
        [HttpPost]
        public async Task<IActionResult> addNewStudent(AddStudentDTO addStudent)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            Console.WriteLine(userId);
            var student = await studentService.addNewStudent(addStudent, userId);
            if (student is null)
                return BadRequest();
            return Created();
        }
        [Authorize]

        [HttpGet]
        public async Task<ActionResult<List<GetStudentInfoDTO>>> getAllStudentsInformation()
        {
            return Ok(await studentService.getAllStudentInformation());
        }

        [HttpGet("{studentId}")]
        public async Task<ActionResult<GetStudentInfoDTO>> geStudentsInformationById(int studentId)
        {
           var student= await studentService.getStudentInformationById(studentId);

            if(student is null)
                return NotFound();
            return Ok(student);
        }

        [HttpPut]
        public async Task<IActionResult> editStudentInformation(int studentId,EditStudentDTO editStudent)
        {
            var studentUpdate = await studentService.editStudentInformation(studentId,editStudent);

            if(studentUpdate.Equals("student not found"))
                return NotFound(studentUpdate);

            return Ok(studentUpdate);
        }
        [HttpDelete]
        public async Task<IActionResult> deactivateStudentAccount(int studentId)
        {
            await studentService.deactivateStudent(studentId);

           return NoContent();
        }
        [HttpPut("activate-account{studentId}")]
        public async Task<IActionResult> eactivateStudentAccount(int studentId)
        {
            await studentService.activateStudent(studentId);

            return NoContent();
        }
    }
    public static class RoleNames
    {
        public const string Admin = nameof(UserRole.Admin);
        public const string Parent = nameof(UserRole.Parent);
        public const string Student = nameof(UserRole.Student);
        public const string Tutor = nameof(UserRole.Tutor);
    }


}
