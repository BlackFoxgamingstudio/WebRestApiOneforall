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
    public class WorkflowDetailController : ControllerBase
    {
        private readonly WorkflowContext _context;

        public WorkflowDetailController(WorkflowContext context)
        {
            _context = context;
        }

        // GET: api/WorkflowDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkflowDetail>>> GetWorkflowDetails()
        {
            return await _context.WorkflowDetails.ToListAsync();
        }
        

        // PUT: api/WorkflowDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkflowDetail(int id, WorkflowDetail WorkflowDetail)
        {
            if(id!=WorkflowDetail.WFId)
            {
                return BadRequest();
            }
            _context.Entry(WorkflowDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkflowDetailExists(id))
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
        public async Task<ActionResult<WorkflowDetail>> GetWorkflowDetail(int id)
        {
            var WorkflowDetail = await _context.WorkflowDetails.FindAsync(id);

            if (WorkflowDetail == null)
            {
                return NotFound();
            }

            return WorkflowDetail;
        }

        // POST: api/WorkflowDetail
        [HttpPost]
        public async Task<ActionResult<WorkflowDetail>> PostWorkflowDetail(WorkflowDetail WorkflowDetail)
        {
            _context.WorkflowDetails.Add(WorkflowDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkflowDetail", new { id = WorkflowDetail.WFId }, WorkflowDetail);
        }

        // DELETE: api/WorkflowDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WorkflowDetail>> DeleteWorkflowDetail(int id)
        {
            var WorkflowDetail = await _context.WorkflowDetails.FindAsync(id);
            if (WorkflowDetail == null)
            {
                return NotFound();
            }

            _context.WorkflowDetails.Remove(WorkflowDetail);
            await _context.SaveChangesAsync();

            return WorkflowDetail;
        }

        private bool WorkflowDetailExists(int id)
        {
            return _context.WorkflowDetails.Any(e => e.WFId == id);
        }
    }
}
