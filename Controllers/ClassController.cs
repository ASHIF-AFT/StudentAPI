using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentAPI.Repositories;
using StudentAPI.Models;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassRepository _classRepository;
        public ClassController(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }
 
        public async Task<IEnumerable<Class>> GetClass()
        {
            return await _classRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Class>> GetClass(int id)
        {
            return await _classRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Class>> PostClass([FromBody] Class Class)
        {
            var newClass = await _classRepository.Create(Class);
            return CreatedAtAction(nameof(GetClass), new { id = newClass.Id }, newClass);
        }

        [HttpPut]
        public async Task<ActionResult> PutClass(int id, [FromBody] Class Class)
        {
            if (id != Class.Id)
            {
                return BadRequest();
            }

            await _classRepository.Update(Class);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var classToDelete = await _classRepository.Get(id);
            if (classToDelete == null)
                return NotFound();

            await _classRepository.Delete(classToDelete.Id);
            return NoContent();
        }
    }
}

