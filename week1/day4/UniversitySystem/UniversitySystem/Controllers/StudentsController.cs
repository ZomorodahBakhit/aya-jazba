using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Core.Forms;
using UniversitySystem.Core.Services;

namespace UniversitySystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var students = _studentService.GetAll();

            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _studentService.GetById(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        public IActionResult Create(CreateStudentForm form)
        {
            var createdStudent = _studentService.Create(form);

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdStudent.Id },
                createdStudent);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateStudentForm form)
        {
            var updated = _studentService.Update(id, form);

            if (!updated)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _studentService.Delete(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}