using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bileti.Domain.Models;
using Bileti.Web.Data;

namespace Bileti.Web.Controllers
{
    public class BiletsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BiletsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bilets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bilets.ToListAsync());
        }

        public async Task<IActionResult> Tickets(DateTime Date)
        {
            ViewData["Filter"] = Date;
            List<Bilet> bileti = await _context.Bilets.ToListAsync();
            bileti = bileti.Where(b => b.BiletCount > 0).ToList();
            if (Date != DateTime.MinValue)
            {
                bileti = bileti.Where(b => b.BiletDate.Date == Date.Date).ToList();
            }
            return View(bileti);
        }

        // GET: Bilets/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bilet = await _context.Bilets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bilet == null)
            {
                return NotFound();
            }

            return View(bilet);
        }

        // GET: Bilets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bilets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BiletName,BiletDescription,BiletPrice,BiletCount,BiletDate,Id")] Bilet bilet)
        {
            if (ModelState.IsValid)
            {
                bilet.Id = Guid.NewGuid();
                _context.Add(bilet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bilet);
        }

        // GET: Bilets/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bilet = await _context.Bilets.FindAsync(id);
            if (bilet == null)
            {
                return NotFound();
            }
            return View(bilet);
        }

        // POST: Bilets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("BiletName,BiletDescription,BiletPrice,BiletCount,BiletDate,Id")] Bilet bilet)
        {
            if (id != bilet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bilet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BiletExists(bilet.Id))
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
            return View(bilet);
        }

        // GET: Bilets/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bilet = await _context.Bilets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bilet == null)
            {
                return NotFound();
            }

            return View(bilet);
        }

        // POST: Bilets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var bilet = await _context.Bilets.FindAsync(id);
            _context.Bilets.Remove(bilet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BiletExists(Guid id)
        {
            return _context.Bilets.Any(e => e.Id == id);
        }
    }
}
