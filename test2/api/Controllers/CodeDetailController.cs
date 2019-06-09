using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeDetailController : ControllerBase
    {
        private readonly CodeContext _context;

        public CodeDetailController(CodeContext context)
        {
            _context = context;
        }

        // GET: api/CodeDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CodeDetail>>> GetCodeDetails()
        {
            return await _context.CodeDetails.ToListAsync();
        }
        

        // PUT: api/CodeDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCodeDetail(int id, CodeDetail CodeDetail)
        {
            if(id!=CodeDetail.CId)
            {
                return BadRequest();
            }
            _context.Entry(CodeDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CodeDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // GET: api/CodeDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CodeDetail>> GetCodeDetail(int id)
        {
            var CodeDetail = await _context.CodeDetails.FindAsync(id);

            if (CodeDetail == null)
            {
                return NotFound();
            }

            return CodeDetail;
        }

        // POST: api/CodeDetail
        [HttpPost]
        public async Task<ActionResult<CodeDetail>> PostCodeDetail(CodeDetail CodeDetail)
        {
            _context.CodeDetails.Add(CodeDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCodeDetail", new { id = CodeDetail.CId }, CodeDetail);
        }

        // DELETE: api/CodeDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CodeDetail>> DeleteCodeDetail(int id)
        {
            var CodeDetail = await _context.CodeDetails.FindAsync(id);
            if (CodeDetail == null)
            {
                return NotFound();
            }

            _context.CodeDetails.Remove(CodeDetail);
            await _context.SaveChangesAsync();

            return CodeDetail;
        }

        private bool CodeDetailExists(int id)
        {
            return _context.CodeDetails.Any(e => e.CId == id);
        }
    }
}
