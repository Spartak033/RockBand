using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RockBand.Data;
using RockBand.Entities;

namespace RockBand.Controllers
{
    public class SugestionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public SugestionsController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Sugestions
        public async Task<IActionResult> Index()
        {
            ViewBag.userId = _userManager.GetUserId(HttpContext.User);
            return View(await _context.Sugestions.ToListAsync());
        }

        // GET: Sugestions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sugestions = await _context.Sugestions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sugestions == null)
            {
                return NotFound();
            }

            return View(sugestions);
        }

        // GET: Sugestions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sugestions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Suggestion,UserId")] Sugestions sugestions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sugestions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sugestions);
        }

        // GET: Sugestions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sugestions = await _context.Sugestions.FindAsync(id);
            if (sugestions == null)
            {
                return NotFound();
            }
            return View(sugestions);
        }

        // POST: Sugestions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Suggestion,UserId")] Sugestions sugestions)
        {
            if (id != sugestions.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sugestions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SugestionsExists(sugestions.Id))
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
            return View(sugestions);
        }

        // GET: Sugestions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sugestions = await _context.Sugestions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sugestions == null)
            {
                return NotFound();
            }

            return View(sugestions);
        }

        // POST: Sugestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sugestions = await _context.Sugestions.FindAsync(id);
            _context.Sugestions.Remove(sugestions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SugestionsExists(int id)
        {
            return _context.Sugestions.Any(e => e.Id == id);
        }
    }
}
