using BlazorCrud.Library;
using BlazorCrud.Server.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet("GetStudents")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        // GET: api/Students/GetStudentById?id=1
        [HttpGet("GetStudentById")]
        public async Task<ActionResult<Student>> GetStudentById([FromQuery] int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return NotFound();
            return student;
        }

        // POST: api/Students/AddStudent
        [HttpPost("AddStudent")]
        public async Task<ActionResult> AddStudent([FromBody] Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return Ok(student);
        }

        [HttpPut("UpdateStudent")]
        public async Task<ActionResult> UpdateStudent([FromBody] Student student)
        {
            var existing = await _context.Students.FindAsync(student.Id);
            if (existing == null)
                return NotFound();

            existing.Name = student.Name;
            existing.FatherName = student.FatherName;
            existing.RegNo = student.RegNo;
            existing.Address = student.Address;
            existing.Phone = student.Phone;
            existing.Email = student.Email;

            await _context.SaveChangesAsync();
            return Ok(existing);
        }


        // DELETE: api/Students/DeleteStudent?id=1
        [HttpDelete("DeleteStudent")]
        public async Task<ActionResult> DeleteStudent([FromQuery] int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
