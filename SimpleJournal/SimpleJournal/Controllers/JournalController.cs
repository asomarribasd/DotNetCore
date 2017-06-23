using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimpleJournal.Data;
using SimpleJournal.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace SimpleJournal.Controllers
{
    [Authorize]
    public class JournalController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JournalController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Journal
        public async Task<IActionResult> Index()
        {
            Claim user = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);

            return View(await _context.Journals.Where(x => x.Author == user.Value).ToListAsync());
        }

        // GET: Journal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var journal = await _context.Journals
                .SingleOrDefaultAsync(m => m.JournalId == id);
            if (journal == null)
            {
                return NotFound();
            }

            return View(journal);
        }

        // GET: Journal/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Journal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JournalId,Name,Description")] Journal journal)
        {
            Claim user = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            journal.Author = user.Value;

            if (ModelState.IsValid)
            {
                _context.Add(journal);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(journal);
        }

        // GET: Journal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var journal = await _context.Journals.SingleOrDefaultAsync(m => m.JournalId == id);
            if (journal == null)
            {
                return NotFound();
            }
            return View(journal);
        }

        // POST: Journal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JournalId,Name,Description, Author")] Journal journal)
        {
            if (id != journal.JournalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(journal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JournalExists(journal.JournalId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(journal);
        }

        // GET: Journal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var journal = await _context.Journals
                .SingleOrDefaultAsync(m => m.JournalId == id);
            if (journal == null)
            {
                return NotFound();
            }

            return View(journal);
        }

        // POST: Journal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var journal = await _context.Journals.SingleOrDefaultAsync(m => m.JournalId == id);
            _context.Journals.Remove(journal);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool JournalExists(int id)
        {
            return _context.Journals.Any(e => e.JournalId == id);
        }
    }
}
