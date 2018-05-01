using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CV.Data;
using Domain;

namespace CV.Areas.Db.Controllers
{
    [Area("Db")]
    public class ExtrasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExtrasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Db/Extras
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Extras.Include(e => e.Cv);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Db/Extras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extra = await _context.Extras
                .Include(e => e.Cv)
                .SingleOrDefaultAsync(m => m.SkillId == id);
            if (extra == null)
            {
                return NotFound();
            }

            return View(extra);
        }

        // GET: Db/Extras/Create
        public IActionResult Create()
        {
            ViewData["CvId"] = new SelectList(_context.Cvs, "CvId", "CvId");
            return View();
        }

        // POST: Db/Extras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SkillId,Name,Content,CvId")] Extra extra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(extra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CvId"] = new SelectList(_context.Cvs, "CvId", "CvId", extra.CvId);
            return View(extra);
        }

        // GET: Db/Extras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extra = await _context.Extras.SingleOrDefaultAsync(m => m.SkillId == id);
            if (extra == null)
            {
                return NotFound();
            }
            ViewData["CvId"] = new SelectList(_context.Cvs, "CvId", "CvId", extra.CvId);
            return View(extra);
        }

        // POST: Db/Extras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SkillId,Name,Content,CvId")] Extra extra)
        {
            if (id != extra.SkillId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(extra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExtraExists(extra.SkillId))
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
            ViewData["CvId"] = new SelectList(_context.Cvs, "CvId", "CvId", extra.CvId);
            return View(extra);
        }

        // GET: Db/Extras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extra = await _context.Extras
                .Include(e => e.Cv)
                .SingleOrDefaultAsync(m => m.SkillId == id);
            if (extra == null)
            {
                return NotFound();
            }

            return View(extra);
        }

        // POST: Db/Extras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var extra = await _context.Extras.SingleOrDefaultAsync(m => m.SkillId == id);
            _context.Extras.Remove(extra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExtraExists(int id)
        {
            return _context.Extras.Any(e => e.SkillId == id);
        }
    }
}
