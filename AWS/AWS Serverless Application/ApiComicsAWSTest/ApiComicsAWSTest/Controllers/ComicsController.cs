﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiComicsMySql.Data;
using ApiComicsMySql.Models;

namespace ApiComicsAWSTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComicsController : ControllerBase
    {
        private readonly ComicsContext _context;

        public ComicsController(ComicsContext context)
        {
            _context = context;
        }

        // GET: api/Comics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comic>>> GetComics()
        {
            if (_context.Comics == null)
            {
                return NotFound();
            }
            return await _context.Comics.ToListAsync();
        }

        // GET: api/Comics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comic>> GetComic(int id)
        {
            if (_context.Comics == null)
            {
                return NotFound();
            }
            var comic = await _context.Comics.FindAsync(id);

            if (comic == null)
            {
                return NotFound();
            }

            return comic;
        }

        // PUT: api/Comics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComic(int id, Comic comic)
        {
            if (id != comic.Id)
            {
                return BadRequest();
            }

            _context.Entry(comic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComicExists(id))
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

        private async Task<int> GetMaxComicAsync()
        {
            if (!await _context.Comics.AnyAsync())
            {
                return 1;
            }
            return await this._context.Comics.MaxAsync(x => x.Id) + 1;
        }

        // POST: api/Comics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Comic>> PostComic(Comic comic)
        {
            if (_context.Comics == null)
            {
                return Problem("Entity set 'ComicsContext.Comics'  is null.");
            }
            comic.Id = await GetMaxComicAsync();
            _context.Comics.Add(comic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComic", new { id = comic.Id }, comic);
        }

        // DELETE: api/Comics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComic(int id)
        {
            if (_context.Comics == null)
            {
                return NotFound();
            }
            var comic = await _context.Comics.FindAsync(id);
            if (comic == null)
            {
                return NotFound();
            }

            _context.Comics.Remove(comic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComicExists(int id)
        {
            return (_context.Comics?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
