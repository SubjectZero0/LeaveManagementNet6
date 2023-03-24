using LeaveManagement.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using LeaveManagement.Web.Views;
using System.Collections;
using LeaveManagement.Web.Contracts;
using Microsoft.AspNetCore.Authorization;
using LeaveManagement.Web.Configurations.Entities;

namespace LeaveManagement.Web.Controllers
{
    [Authorize(Roles = UserRoleConstants.Administrator)]
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeRepository leaveTypeRepo; //inject ILeaveTypeRepository
        private readonly IMapper _mapper; //inject AutoMapperConfig
        private readonly ILeaveAllocationsRepository leaveAllocationsRepository;

        public LeaveTypesController(ILeaveTypeRepository leaveTypeRepo, IMapper mapper, ILeaveAllocationsRepository leaveAllocationsRepository)
        {
            this.leaveTypeRepo = leaveTypeRepo; //inject ILeaveTypeRepository
            this._mapper = mapper; //inject AutoMapperConfig
            this.leaveAllocationsRepository = leaveAllocationsRepository;
        }

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
            // Let Automapper map the typeof LeaveType to typeof LeavetypeViewModel
            var leaveTypesViewModel = _mapper.Map<List<LeaveTypeViewModel>>(await leaveTypeRepo.GetAllAsync());

            return View(leaveTypesViewModel);
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var leaveType = await leaveTypeRepo.GetAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }
            var leaveTypeViewModel = _mapper.Map<LeaveTypeViewModel>(leaveType);
            return View(leaveTypeViewModel);
        }

        // GET: LeaveTypes/Create
        // brings the create view to screen
        public IActionResult Create()
        {
            return View();
        }

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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveTypeViewModel leaveTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                var leaveTypeDb = _mapper.Map<LeaveType>(leaveTypeViewModel);

                //dates are not part of the data shown, so we set them up in the background.
                leaveTypeDb.DateCreated = DateTime.Now;
                leaveTypeDb.DateModified = DateTime.Now;

                // add the leaveTypeDb to the database
                await leaveTypeRepo.AddAsync(leaveTypeDb);

                // after submition, redirect to LeaveType Index
                return RedirectToAction(nameof(Index));
            }
            // if modelstate is not valid rerender form with errors
            return View(leaveTypeViewModel);
        }

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var leaveType = await leaveTypeRepo.GetAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }

            var leaveTypeViewModel = _mapper.Map<LeaveTypeViewModel>(leaveType);
            return View(leaveTypeViewModel);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, LeaveTypeViewModel leaveTypeViewModel)
        {
            if (id != leaveTypeViewModel.Id)
            {
                return NotFound();
            }

            var leaveType = await leaveTypeRepo.GetAsync(id);

            if (leaveType == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _mapper.Map(leaveTypeViewModel, leaveType);
                    leaveType.DateModified = DateTime.Now;
                    await leaveTypeRepo.UpdateAsync(leaveType);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await LeaveTypeExists(leaveTypeViewModel.Id))
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
            return View(leaveTypeViewModel);
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            await leaveTypeRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Allocate Leave to all employees
        /// </summary>
        /// <param name="LeaveType.Id"></param>
        /// <returns>void</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AllocateLeave(int id)
        {
            await leaveAllocationsRepository.AddLeaveAllocation(id);
            return RedirectToAction(nameof(Index));
        }


        //----------------------------------Methods---------------------------------------
        private async Task<bool> LeaveTypeExists(int id) => await leaveTypeRepo.Exists(id);
    }
}