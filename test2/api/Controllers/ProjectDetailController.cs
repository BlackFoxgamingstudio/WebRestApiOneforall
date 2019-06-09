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
    public class ProjectDetailController : ControllerBase
    {
        private readonly ProjectContext _context;

        public ProjectDetailController(ProjectContext context)
        {
            _context = context;
        }

        // GET: api/ProjectDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDetail>>> GetProjectDetails()
        {
            return await _context.ProjectDetails.ToListAsync();
        }
        

        // PUT: api/ProjectDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectDetail(int id, ProjectDetail ProjectDetail)
        {
            if(id!=ProjectDetail.PId)
            {
                return BadRequest();
            }
            _context.Entry(ProjectDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectDetailExists(id))
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

        // GET: api/ProjectDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDetail>> GetProjectDetail(int id)
        {
            var ProjectDetail = await _context.ProjectDetails.FindAsync(id);

            if (ProjectDetail == null)
            {
                return NotFound();
            }

            return ProjectDetail;
        }

        // POST: api/ProjectDetail
        [HttpPost]
        public async Task<ActionResult<ProjectDetail>> PostProjectDetail(ProjectDetail ProjectDetail)
        {
            _context.ProjectDetails.Add(ProjectDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectDetail", new { id = ProjectDetail.PId }, ProjectDetail);
        }

        // DELETE: api/ProjectDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProjectDetail>> DeleteProjectDetail(int id)
        {
            var ProjectDetail = await _context.ProjectDetails.FindAsync(id);
            if (ProjectDetail == null)
            {
                return NotFound();
            }

            _context.ProjectDetails.Remove(ProjectDetail);
            await _context.SaveChangesAsync();

            return ProjectDetail;
        }

        private bool ProjectDetailExists(int id)
        {
            return _context.ProjectDetails.Any(e => e.PId == id);
        }
    }
}
