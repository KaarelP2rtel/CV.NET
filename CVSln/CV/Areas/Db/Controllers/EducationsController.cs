using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CV.Data;
using Domain;
using Microsoft.AspNetCore.Authorization;

namespace CV.Areas.Db.Controllers
{
    [Area("Db")]
    [Authorize(Roles="Admin")]
    public class EducationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EducationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Db/Educations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Educations.Include(e => e.Cv);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Db/Educations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education = await _context.Educations
                .Include(e => e.Cv)
                .SingleOrDefaultAsync(m => m.EducationId == id);
            if (education == null)
            {
                return NotFound();
            }

            return View(education);
        }

        // GET: Db/Educations/Create
        public IActionResult Create()
        {
            ViewData["CvId"] = new SelectList(_context.Cvs, "CvId", "CvId");
            return View();
        }

        // POST: Db/Educations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EducationId,SchoolName,EducationType,StudyYears,Programme,OrderNo,CvId")] Education education)
        {
            if (ModelState.IsValid)
            {
                _context.Add(education);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CvId"] = new SelectList(_context.Cvs, "CvId", "CvId", education.CvId);
            return View(education);
        }

        // GET: Db/Educations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education = await _context.Educations.SingleOrDefaultAsync(m => m.EducationId == id);
            if (education == null)
            {
                return NotFound();
            }
            ViewData["CvId"] = new SelectList(_context.Cvs, "CvId", "CvId", education.CvId);
            return View(education);
        }

        // POST: Db/Educations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EducationId,SchoolName,EducationType,StudyYears,Programme,OrderNo,CvId")] Education education)
        {
            if (id != education.EducationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(education);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EducationExists(education.EducationId))
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
            ViewData["CvId"] = new SelectList(_context.Cvs, "CvId", "CvId", education.CvId);
            return View(education);
        }

        // GET: Db/Educations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education = await _context.Educations
                .Include(e => e.Cv)
                .SingleOrDefaultAsync(m => m.EducationId == id);
            if (education == null)
            {
                return NotFound();
            }

            return View(education);
        }

        // POST: Db/Educations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var education = await _context.Educations.SingleOrDefaultAsync(m => m.EducationId == id);
            _context.Educations.Remove(education);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EducationExists(int id)
        {
            return _context.Educations.Any(e => e.EducationId == id);
        }
    }
}
