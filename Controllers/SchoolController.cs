using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentAPI.Models;
using StudentAPI.Repositories;
namespace StudentAPI.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IReportCardRepository _reportCardRepository;
        public SchoolController(IStudentRepository studentRepository,
            IReportCardRepository reportCardRepository)
        {
            _studentRepository = studentRepository;
            _reportCardRepository = reportCardRepository;

        }

        [Route("GetStudents")]
        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _studentRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudents(int id)
        {
            return await _studentRepository.Get(id);
        }

        [Route("AddStudent")]
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudents([FromBody] Student Student)
        {
            var newStudent = await _studentRepository.Create(Student);
            return CreatedAtAction(nameof(GetStudents), new { id = newStudent.Roll_Number }, newStudent);
        }

        [HttpPut]
        public async Task<ActionResult> PutStudents(int id, [FromBody] Student Student)
        {
            if (id != Student.Roll_Number)
            {
                return BadRequest();
            }

            await _studentRepository.Update(Student);

            return NoContent();
        }


        [Route("DeleteStudent")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var StudentToDelete = await _studentRepository.Get(id);
            if (StudentToDelete == null)
                return NotFound();

            await _studentRepository.Delete(StudentToDelete.Roll_Number);
            return NoContent();
        }


        [Route("GetReportCards")]
        public async Task<IEnumerable<ReportCard>> GetReportCard()
        {
            return await _reportCardRepository.Get();
        }


        [Route("GetReportCard")]
        [HttpGet("{id}")]
        public async Task<ActionResult<ReportCard>> GetReportCard(int id)
        {
            return await _reportCardRepository.Get(id);
        }
        [Route("AddReportCard")]
        [HttpPost]
        public async Task<ActionResult<ReportCard>> PostReportCard([FromBody] ReportCard ReportCard)
        {
            var newReportCard = await _reportCardRepository.Create(ReportCard);
            return CreatedAtAction(nameof(GetReportCard), new { id = newReportCard.Id }, newReportCard);
        }

        [Route("UpdateReportCard")]
        [HttpPut]
        public async Task<ActionResult> PutReportCard(int id, [FromBody] ReportCard ReportCard)
        {
            if (id != ReportCard.Id)
            {
                return BadRequest();
            }

            await _reportCardRepository.Update(ReportCard);

            return NoContent();
        }

        [Route("DeleteReportCard")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReport(int id)
        {
            var ReportCardToDelete = await _reportCardRepository.Get(id);
            if (ReportCardToDelete == null)
                return NotFound();

            await _reportCardRepository.Delete(ReportCardToDelete.Id);
            return NoContent();
        }

        [Route("GetAllStudents")]
        public Task<IEnumerable<StudentName>> GetAllStudents(string fieldname , int sortOrder)
        {
            return _studentRepository.GetAllStudents(fieldname, sortOrder);
        }

    }
}
