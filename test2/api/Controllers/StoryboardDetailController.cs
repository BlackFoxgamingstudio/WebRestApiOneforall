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
    public class StoryboardDetailController : ControllerBase
    {
        private readonly StoryboardContext _context;

        public StoryboardDetailController(StoryboardContext context)
        {
            _context = context;
        }

        // GET: api/StoryboardDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoryboardDetail>>> GetStoryboardDetails()
        {
            return await _context.StoryboardDetails.ToListAsync();
        }
        

        // PUT: api/StoryboardDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStoryboardDetail(int id, StoryboardDetail StoryboardDetail)
        {
            if(id!=StoryboardDetail.SBId)
            {
                return BadRequest();
            }
            _context.Entry(StoryboardDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoryboardDetailExists(id))
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

        // GET: api/StoryboardDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StoryboardDetail>> GetStoryboardDetail(int id)
        {
            var StoryboardDetail = await _context.StoryboardDetails.FindAsync(id);

            if (StoryboardDetail == null)
            {
                return NotFound();
            }

            return StoryboardDetail;
        }

        // POST: api/StoryboardDetail
        [HttpPost]
        public async Task<ActionResult<StoryboardDetail>> PostStoryboardDetail(StoryboardDetail StoryboardDetail)
        {
            _context.StoryboardDetails.Add(StoryboardDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStoryboardDetail", new { id = StoryboardDetail.SBId }, StoryboardDetail);
        }

        // DELETE: api/StoryboardDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StoryboardDetail>> DeleteStoryboardDetail(int id)
        {
            var StoryboardDetail = await _context.StoryboardDetails.FindAsync(id);
            if (StoryboardDetail == null)
            {
                return NotFound();
            }

            _context.StoryboardDetails.Remove(StoryboardDetail);
            await _context.SaveChangesAsync();

            return StoryboardDetail;
        }

        private bool StoryboardDetailExists(int id)
        {
            return _context.StoryboardDetails.Any(e => e.SBId == id);
        }
    }
}
