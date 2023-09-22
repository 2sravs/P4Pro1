using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project2p4.Data;
using Project2p4.Models;

namespace Project2p4.Controllers
{
    public class CustlogsController : Controller
    {
        private readonly Project2p4Context _context;

        public CustlogsController(Project2p4Context context)
        {
            _context = context;
        }

        // GET: Custlogs
        public async Task<IActionResult> Index()
        {
            var project2p4Context = _context.Custlog.Include(c => c.User);
            return View(await project2p4Context.ToListAsync());
        }

        // GET: Custlogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Custlog == null)
            {
                return NotFound();
            }

            var custlog = await _context.Custlog
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.LogId == id);
            if (custlog == null)
            {
                return NotFound();
            }

            return View(custlog);
        }

        // GET: Custlogs/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.user, "UserId", "Email");
            return View();
        }

        // POST: Custlogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LogId,CustEmail,CustName,LogStatus,UserId,Description")] Custlog custlog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(custlog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.user, "UserId", "Email", custlog.UserId);
            return View(custlog);
        }

        // GET: Custlogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Custlog == null)
            {
                return NotFound();
            }

            var custlog = await _context.Custlog.FindAsync(id);
            if (custlog == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.user, "UserId", "Email", custlog.UserId);
            return View(custlog);
        }

        // POST: Custlogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LogId,CustEmail,CustName,LogStatus,UserId,Description")] Custlog custlog)
        {
            if (id != custlog.LogId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(custlog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustlogExists(custlog.LogId))
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
            ViewData["UserId"] = new SelectList(_context.user, "UserId", "Email", custlog.UserId);
            return View(custlog);
        }

        // GET: Custlogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Custlog == null)
            {
                return NotFound();
            }

            var custlog = await _context.Custlog
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.LogId == id);
            if (custlog == null)
            {
                return NotFound();
            }

            return View(custlog);
        }

        // POST: Custlogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Custlog == null)
            {
                return Problem("Entity set 'Project2p4Context.Custlog'  is null.");
            }
            var custlog = await _context.Custlog.FindAsync(id);
            if (custlog != null)
            {
                _context.Custlog.Remove(custlog);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustlogExists(int id)
        {
          return (_context.Custlog?.Any(e => e.LogId == id)).GetValueOrDefault();
        }
    }
}
