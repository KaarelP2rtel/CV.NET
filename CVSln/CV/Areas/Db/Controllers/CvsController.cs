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
    public class CvsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CvsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Db/Cvs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cvs.ToListAsync());
        }

        // GET: Db/Cvs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cv = await _context.Cvs
                .SingleOrDefaultAsync(m => m.CvId == id);
            if (cv == null)
            {
                return NotFound();
            }

            return View(cv);
        }

        // GET: Db/Cvs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Db/Cvs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CvId,FirstName,LastName,BirthDay,Address,Email,Phone,ImageLink")] Cv cv)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cv);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cv);
        }

        // GET: Db/Cvs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cv = await _context.Cvs.SingleOrDefaultAsync(m => m.CvId == id);
            if (cv == null)
            {
                return NotFound();
            }
            return View(cv);
        }

        // POST: Db/Cvs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CvId,FirstName,LastName,BirthDay,Address,Email,Phone,ImageLink")] Cv cv)
        {
            if (id != cv.CvId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cv);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CvExists(cv.CvId))
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
            return View(cv);
        }

        // GET: Db/Cvs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cv = await _context.Cvs
                .SingleOrDefaultAsync(m => m.CvId == id);
            if (cv == null)
            {
                return NotFound();
            }

            return View(cv);
        }

        // POST: Db/Cvs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cv = await _context.Cvs.SingleOrDefaultAsync(m => m.CvId == id);
            _context.Cvs.Remove(cv);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CvExists(int id)
        {
            return _context.Cvs.Any(e => e.CvId == id);
        }
    }
}
