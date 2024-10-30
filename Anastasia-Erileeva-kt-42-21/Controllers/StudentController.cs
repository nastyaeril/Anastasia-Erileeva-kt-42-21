using Anastasia_Erileeva_kt_42_21.Database;
using Anastasia_Erileeva_kt_42_21.Filters.StudentFilters;
using Anastasia_Erileeva_kt_42_21.Interfaces;

using Anastasia_Erileeva_kt_42_21.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Anastasia_Erileeva_kt_42_21.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> _logger;
        private readonly IStudentService _studentService;
        private readonly StudentDbContext _context;

        public StudentsController(ILogger<StudentsController> logger, IStudentService studentService, StudentDbContext context)
        {
            _logger = logger;
            _studentService = studentService;
            _context = context;
        }

        [HttpPost("GetStudentsByGroup")]
        public async Task<IActionResult> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var students = await _studentService.GetStudentsByGroupAsync(filter, cancellationToken);

            return Ok(students);
        }

        [HttpPost("GetStudentsByFIO")]
        public async Task<IActionResult> GetStudentsByFIOAsync(StudentFIOFilter filter, CancellationToken cancellationToken = default)
        {
            var students = await _studentService.GetStudentsByFamiliaAsync(filter, cancellationToken);
            return Ok(students);
        }

        //[HttpPost("GetStudentsByFIO")]
        //public async Task<IActionResult> GetStudentsByFIOAsync(StudentFIOFilter filter, CancellationToken cancellationToken = default)
        //{
        //    var students = await _studentService.GetStudentsByFIOAsync(filter, cancellationToken);
        //    return Ok(students);
        //}

        [HttpPost("GetStudentsByDeletionStatus")]
        public async Task<IActionResult> GetStudentsByDeletionStatusAsync(StudentDeletionStatusFilter filter, CancellationToken cancellationToken = default)
        {
            var students = await _studentService.GetStudentsByDeletionStatusAsync(filter, cancellationToken);
            return Ok(students);
        }

        [HttpPost("AddNewStudent")]
        public IActionResult AddStudent([FromBody] Student student)
        {
            //проверка на корректность ввода
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Students.Add(student);//добавление в коллекцию
            _context.SaveChanges();
            return Ok(student);
        }

        [HttpPost("EditStudent")]
        public IActionResult EditStudent(string lastname, [FromBody] Student editedStudent)
        {
            var inBaseStudent = _context.Students.FirstOrDefault(w => w.LastName == lastname);//поиск студента по фамилии в бд
            if (inBaseStudent == null)
            {
                return NotFound();
            }
            //изменение данных о студенте
            inBaseStudent.FirstName = editedStudent.FirstName;
            inBaseStudent.LastName = editedStudent.LastName;
            inBaseStudent.Middlename = editedStudent.Middlename;
            inBaseStudent.GroupID = editedStudent.GroupID;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("DeleteStudent")]
        public IActionResult DeleteStudent(string lastname, [FromBody] Student editedStudent)
        {
            var inBaseStudent = _context.Students.FirstOrDefault(g => g.LastName == lastname);//поиск студента по фамилии в бд
            if (inBaseStudent == null)
            {
                return NotFound();
            }
            //удаление данных о студенте
            _context.Students.Remove(inBaseStudent);
            _context.SaveChanges();
            return Ok();
        }
    }
}