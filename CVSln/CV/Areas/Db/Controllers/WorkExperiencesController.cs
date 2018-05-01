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
    public class WorkExperiencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkExperiencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Db/WorkExperiences
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.WorkExperiences.Include(w => w.Cv);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Db/WorkExperiences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workExperience = await _context.WorkExperiences
                .Include(w => w.Cv)
                .SingleOrDefaultAsync(m => m.WorkExperienceId == id);
            if (workExperience == null)
            {
                return NotFound();
            }

            return View(workExperience);
        }

        // GET: Db/WorkExperiences/Create
        public IActionResult Create()
        {
            ViewData["CvId"] = new SelectList(_context.Cvs, "CvId", "CvId");
            return View();
        }

        // POST: Db/WorkExperiences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkExperienceId,CompanyName,JobTitle,WorkYears,CvId")] WorkExperience workExperience)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workExperience);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CvId"] = new SelectList(_context.Cvs, "CvId", "CvId", workExperience.CvId);
            return View(workExperience);
        }

        // GET: Db/WorkExperiences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workExperience = await _context.WorkExperiences.SingleOrDefaultAsync(m => m.WorkExperienceId == id);
            if (workExperience == null)
            {
                return NotFound();
            }
            ViewData["CvId"] = new SelectList(_context.Cvs, "CvId", "CvId", workExperience.CvId);
            return View(workExperience);
        }

        // POST: Db/WorkExperiences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkExperienceId,CompanyName,JobTitle,WorkYears,CvId")] WorkExperience workExperience)
        {
            if (id != workExperience.WorkExperienceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workExperience);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkExperienceExists(workExperience.WorkExperienceId))
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
            ViewData["CvId"] = new SelectList(_context.Cvs, "CvId", "CvId", workExperience.CvId);
            return View(workExperience);
        }

        // GET: Db/WorkExperiences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workExperience = await _context.WorkExperiences
                .Include(w => w.Cv)
                .SingleOrDefaultAsync(m => m.WorkExperienceId == id);
            if (workExperience == null)
            {
                return NotFound();
            }

            return View(workExperience);
        }

        // POST: Db/WorkExperiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workExperience = await _context.WorkExperiences.SingleOrDefaultAsync(m => m.WorkExperienceId == id);
            _context.WorkExperiences.Remove(workExperience);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkExperienceExists(int id)
        {
            return _context.WorkExperiences.Any(e => e.WorkExperienceId == id);
        }
    }
}
