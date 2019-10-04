using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebDemo.Models;
using WebDemo.Models.Articles;

namespace WebDemo.Controllers
{
    public class SlotTypesController : Controller
    {
        private readonly AppDBContext _context;

        public SlotTypesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: SlotTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.SlotTypes.ToListAsync());
        }

        // GET: SlotTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slotType = await _context.SlotTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (slotType == null)
            {
                return NotFound();
            }

            return View(slotType);
        }

        // GET: SlotTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SlotTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] SlotType slotType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(slotType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(slotType);
        }

        // GET: SlotTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slotType = await _context.SlotTypes.FindAsync(id);
            if (slotType == null)
            {
                return NotFound();
            }
            return View(slotType);
        }

        // POST: SlotTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] SlotType slotType)
        {
            if (id != slotType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(slotType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlotTypeExists(slotType.Id))
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
            return View(slotType);
        }

        // GET: SlotTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slotType = await _context.SlotTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (slotType == null)
            {
                return NotFound();
            }

            return View(slotType);
        }

        // POST: SlotTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var slotType = await _context.SlotTypes.FindAsync(id);
            _context.SlotTypes.Remove(slotType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SlotTypeExists(int id)
        {
            return _context.SlotTypes.Any(e => e.Id == id);
        }
    }
}
