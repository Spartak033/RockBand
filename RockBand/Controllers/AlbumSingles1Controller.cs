using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RockBand.Data;
using RockBand.Entities;

namespace RockBand.Controllers
{
    public class AlbumSingles1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlbumSingles1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AlbumSingles1
        public async Task<IActionResult> Index()
        {
            return View(await _context.AlbumSingle.ToListAsync());
        }

        // GET: AlbumSingles1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var albumSingle = await _context.AlbumSingle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (albumSingle == null)
            {
                return NotFound();
            }

            return View(albumSingle);
        }

        // GET: AlbumSingles1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AlbumSingles1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descrption,Video,DataZDateRegister")] AlbumSingle albumSingle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(albumSingle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(albumSingle);
        }

        // GET: AlbumSingles1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var albumSingle = await _context.AlbumSingle.FindAsync(id);
            if (albumSingle == null)
            {
                return NotFound();
            }
            return View(albumSingle);
        }

        // POST: AlbumSingles1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descrption,Video,DataZDateRegister")] AlbumSingle albumSingle)
        {
            if (id != albumSingle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(albumSingle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumSingleExists(albumSingle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(albumSingle);
        }

        // GET: AlbumSingles1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var albumSingle = await _context.AlbumSingle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (albumSingle == null)
            {
                return NotFound();
            }

            return View(albumSingle);
        }

        // POST: AlbumSingles1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var albumSingle = await _context.AlbumSingle.FindAsync(id);
            _context.AlbumSingle.Remove(albumSingle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlbumSingleExists(int id)
        {
            return _context.AlbumSingle.Any(e => e.Id == id);
        }
    }
}
