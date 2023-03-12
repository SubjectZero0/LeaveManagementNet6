using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagement.Web.Data;

namespace LeaveManagement.Web.Controllers
{
    public class LeaveAllocationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeaveAllocationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LeaveAllocations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LeaveAllocations.Include(l => l.LeaveType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: LeaveAllocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LeaveAllocations == null)
            {
                return NotFound();
            }

            var leaveAllocation = await _context.LeaveAllocations
                .Include(l => l.LeaveType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveAllocation == null)
            {
                return NotFound();
            }

            return View(leaveAllocation);
        }

        // GET: LeaveAllocations/Create
        public IActionResult Create()
        {
            ViewData["LeaveTypeId"] = new SelectList(_context.LeaveTypes, "Id", "Id");
            return View();
        }

        // POST: LeaveAllocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LeaveTypeId,EmployeeId,Id,DateCreated,DateModified")] LeaveAllocation leaveAllocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leaveAllocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LeaveTypeId"] = new SelectList(_context.LeaveTypes, "Id", "Id", leaveAllocation.LeaveTypeId);
            return View(leaveAllocation);
        }

        // GET: LeaveAllocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LeaveAllocations == null)
            {
                return NotFound();
            }

            var leaveAllocation = await _context.LeaveAllocations.FindAsync(id);
            if (leaveAllocation == null)
            {
                return NotFound();
            }
            ViewData["LeaveTypeId"] = new SelectList(_context.LeaveTypes, "Id", "Id", leaveAllocation.LeaveTypeId);
            return View(leaveAllocation);
        }

        // POST: LeaveAllocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LeaveTypeId,EmployeeId,Id,DateCreated,DateModified")] LeaveAllocation leaveAllocation)
        {
            if (id != leaveAllocation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaveAllocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveAllocationExists(leaveAllocation.Id))
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
            ViewData["LeaveTypeId"] = new SelectList(_context.LeaveTypes, "Id", "Id", leaveAllocation.LeaveTypeId);
            return View(leaveAllocation);
        }

        // GET: LeaveAllocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LeaveAllocations == null)
            {
                return NotFound();
            }

            var leaveAllocation = await _context.LeaveAllocations
                .Include(l => l.LeaveType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveAllocation == null)
            {
                return NotFound();
            }

            return View(leaveAllocation);
        }

        // POST: LeaveAllocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LeaveAllocations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LeaveAllocations'  is null.");
            }
            var leaveAllocation = await _context.LeaveAllocations.FindAsync(id);
            if (leaveAllocation != null)
            {
                _context.LeaveAllocations.Remove(leaveAllocation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveAllocationExists(int id)
        {
          return _context.LeaveAllocations.Any(e => e.Id == id);
        }
    }
}
