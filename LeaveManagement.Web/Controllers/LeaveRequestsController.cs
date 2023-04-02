using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Contracts;
using AutoMapper;
using LeaveManagement.Web.Views;
using LeaveManagement.Web.Repositories;

namespace LeaveManagement.Web.Controllers
{
    public class LeaveRequestsController : Controller
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LeaveRequestsController(ILeaveRequestRepository leaveRequestRepository,
                                       IMapper mapper,
                                       ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        // GET: LeaveRequests

        // GET: LeaveRequests/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.LeaveRequests == null)
        //    {
        //        return NotFound();
        //    }

        //    var leaveRequest = await _context.LeaveRequests
        //        .Include(l => l.LeaveType)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (leaveRequest == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(leaveRequest);
        //}

        // GET: LeaveRequests/Create
        public async Task<IActionResult> Create()
        {
            var leaveRequestVM = new LeaveRequestCreateViewModel();
            ViewData["LeaveTypeId"] = new SelectList(await _leaveTypeRepository.GetAllAsync(), "Id", "Name");
            return View(leaveRequestVM);
        }

        // POST: LeaveRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveRequestCreateViewModel leaveRequestVM)
        {
            var user = await _leaveRequestRepository.GetCurrentUser();

            if (ModelState.IsValid)
            {
                var leaveRequest = _mapper.Map<LeaveRequest>(leaveRequestVM);
                await _leaveRequestRepository.CreateWithCurrentUser(leaveRequest, user);

                return RedirectToAction(nameof(Index));
            }

            ViewData["LeaveTypeId"] = new SelectList(await _leaveTypeRepository.GetAllAsync(), "Id", "Name", leaveRequestVM.LeaveTypeId);
            return View(leaveRequestVM);
        }

        // GET: LeaveRequests/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.LeaveRequests == null)
        //    {
        //        return NotFound();
        //    }

        //    var leaveRequest = await _context.LeaveRequests.FindAsync(id);
        //    if (leaveRequest == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["LeaveTypeId"] = new SelectList(_context.LeaveTypes, "Id", "Id", leaveRequest.LeaveTypeId);
        //    return View(leaveRequest);
        //}

        // POST: LeaveRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("DateStarted,DateEnded,LeaveTypeId,IsApproved,IsCancelled,Comment,RequestingEmployeeId,Id,DateCreated,DateModified")] LeaveRequest leaveRequest)
        //{
        //    if (id != leaveRequest.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(leaveRequest);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!LeaveRequestExists(leaveRequest.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["LeaveTypeId"] = new SelectList(_context.LeaveTypes, "Id", "Id", leaveRequest.LeaveTypeId);
        //    return View(leaveRequest);
        //}

        // GET: LeaveRequests/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.LeaveRequests == null)
        //    {
        //        return NotFound();
        //    }

        //    var leaveRequest = await _context.LeaveRequests
        //        .Include(l => l.LeaveType)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (leaveRequest == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(leaveRequest);
        //}

        // POST: LeaveRequests/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.LeaveRequests == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.LeaveRequests'  is null.");
        //    }
        //    var leaveRequest = await _context.LeaveRequests.FindAsync(id);
        //    if (leaveRequest != null)
        //    {
        //        _context.LeaveRequests.Remove(leaveRequest);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool LeaveRequestExists(int id)
        //{
        //  return (_context.LeaveRequests?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}