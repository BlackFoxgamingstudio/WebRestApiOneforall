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
    public class KeyWordDetailController : ControllerBase
    {
        private readonly KeyWordContext _context;

        public KeyWordDetailController(KeyWordContext context)
        {
            _context = context;
        }

        // GET: api/KeyWordDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KeyWordDetail>>> GetKeyWordDetails()
        {
            return await _context.KeyWordDetails.ToListAsync();
        }
        

        // PUT: api/KeyWordDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKeyWordDetail(int id, KeyWordDetail KeyWordDetail)
        {
            if(id!=KeyWordDetail.KWId)
            {
                return BadRequest();
            }
            _context.Entry(KeyWordDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KeyWordDetailExists(id))
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

        // GET: api/KeyWordDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KeyWordDetail>> GetKeyWordDetail(int id)
        {
            var KeyWordDetail = await _context.KeyWordDetails.FindAsync(id);

            if (KeyWordDetail == null)
            {
                return NotFound();
            }

            return KeyWordDetail;
        }

        // POST: api/KeyWordDetail
        [HttpPost]
        public async Task<ActionResult<KeyWordDetail>> PostKeyWordDetail(KeyWordDetail KeyWordDetail)
        {
            _context.KeyWordDetails.Add(KeyWordDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKeyWordDetail", new { id = KeyWordDetail.KWId }, KeyWordDetail);
        }

        // DELETE: api/KeyWordDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<KeyWordDetail>> DeleteKeyWordDetail(int id)
        {
            var KeyWordDetail = await _context.KeyWordDetails.FindAsync(id);
            if (KeyWordDetail == null)
            {
                return NotFound();
            }

            _context.KeyWordDetails.Remove(KeyWordDetail);
            await _context.SaveChangesAsync();

            return KeyWordDetail;
        }

        private bool KeyWordDetailExists(int id)
        {
            return _context.KeyWordDetails.Any(e => e.KWId == id);
        }
    }
}
