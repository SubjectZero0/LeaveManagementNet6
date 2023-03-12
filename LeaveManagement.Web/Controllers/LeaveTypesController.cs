using LeaveManagement.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using LeaveManagement.Web.Views;
using System.Collections;

namespace LeaveManagement.Web.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper; //inject AutoMapperConfig

        public LeaveTypesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper; //inject AutoMapperConfig
        }

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
            // Let Automapper map the typeof LeaveType to typeof LeavetypeViewModel
            var leaveTypes = _mapper.Map<List<LeaveTypeViewModel>>(await _context.LeaveTypes.ToListAsync());

            return View(leaveTypes);
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LeaveTypes == null)
            {
                return NotFound();
            }

            var leaveType = await _context.LeaveTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
        }

        // GET: LeaveTypes/Create
        // brings the create view to screen
        public IActionResult Create()
        {
            return View();
        }


        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveTypeViewModel leaveTypeViewModel)
        /// <summary>
        /// 
        /// POST task: LeaveTypes/Create
        /// handles the POST request to create a Leave Type
        /// 
        /// </summary>
        /// 
        /// <param name="leaveTypeViewModel"></param>
        /// 
        /// <returns>HTTPResponse - Index OR Create</returns>
        {

            if (ModelState.IsValid)
            {
                var leaveTypeDb = _mapper.Map<LeaveType>(leaveTypeViewModel);

                //dates are not part of the data shown, so we set them up in the background.
                leaveTypeDb.DateCreated = DateTime.Now;
                leaveTypeDb.DateModified = DateTime.Now;

                // add the leaveTypeDb to the database
                _context.Add(leaveTypeDb);

                // save the data to a new table instance on Submit
                await _context.SaveChangesAsync();

                // after submition, redirect to LeaveType Index
                return RedirectToAction(nameof(Index));
            }
            // if modelstate is not valid rerender form with errors
            return View(leaveTypeViewModel);
        }

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LeaveTypes == null)
            {
                return NotFound();
            }

            var leaveType = await _context.LeaveTypes.FindAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }
            return View(leaveType);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,DefaultDays,Id,DateCreated,DateModified")] LeaveType leaveType)
        {
            if (id != leaveType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaveType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveTypeExists(leaveType.Id))
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
            return View(leaveType);
        }

        // GET: LeaveTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LeaveTypes == null)
            {
                return NotFound();
            }

            var leaveType = await _context.LeaveTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LeaveTypes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LeaveTypes'  is null.");
            }
            var leaveType = await _context.LeaveTypes.FindAsync(id);
            if (leaveType != null)
            {
                _context.LeaveTypes.Remove(leaveType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // -----------------------METHODS---------------------------------------
        private bool LeaveTypeExists(int id)
        {
            return _context.LeaveTypes.Any(e => e.Id == id);
        }
    }
}