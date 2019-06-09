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
    public class QuizDetailController : ControllerBase
    {
        private readonly QuizContext _context;

        public QuizDetailController(QuizContext context)
        {
            _context = context;
        }

        // GET: api/WorkflowDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuizDetail>>> GetQuizDetails()
        {
            return await _context.QuizDetails.ToListAsync();
        }
        

        // PUT: api/WorkflowDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuizDetail(int id, QuizDetail QuizDetail)
        {
            if(id!= QuizDetail.QId)
            {
                return BadRequest();
            }
            _context.Entry(QuizDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuizDetailExists(id))
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

        // GET: api/WorkflowDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuizDetail>> GetQuizDetail(int id)
        {
            var QuizDetail = await _context.QuizDetails.FindAsync(id);

            if (QuizDetail == null)
            {
                return NotFound();
            }

            return QuizDetail;
        }

        // POST: api/WorkflowDetail
        [HttpPost]
        public async Task<ActionResult<QuizDetail>> PostQuizDetail(QuizDetail QuizDetail)
        {
            _context.QuizDetails.Add(QuizDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuizDetail", new { id = QuizDetail.QId }, QuizDetail);
        }

        // DELETE: api/WorkflowDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<QuizDetail>> DeleteQuizDetail(int id)
        {
            var QuizDetail = await _context.QuizDetails.FindAsync(id);
            if (QuizDetail == null)
            {
                return NotFound();
            }

            _context.QuizDetails.Remove(QuizDetail);
            await _context.SaveChangesAsync();

            return QuizDetail;
        }

        private bool QuizDetailExists(int id)
        {
            return _context.QuizDetails.Any(e => e.QId == id);
        }
    }
}
