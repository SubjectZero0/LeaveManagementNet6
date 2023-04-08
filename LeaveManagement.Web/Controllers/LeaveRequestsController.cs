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
using Microsoft.AspNetCore.Authorization;
using LeaveManagement.Web.Services;
using LeaveManagement.Web.Configurations.Entities;

namespace LeaveManagement.Web.Controllers
{
    [Authorize]
    public class LeaveRequestsController : Controller
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveRequestService _leaveRequestService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public LeaveRequestsController(ILeaveRequestRepository leaveRequestRepository,
                                       ILeaveTypeRepository leaveTypeRepository,
                                       ILeaveRequestService leaveRequestService,
                                       IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _leaveRequestService = leaveRequestService;
            _mapper = mapper;
        }

        // GET: LeaveRequests/MyLeaves
        public async Task<IActionResult> MyLeaves()
        {
            var myLeavesVM = await _leaveRequestService.GetMyLeavesAsync();
            return View(myLeavesVM);
        }

        // GET: LeaveRequests/Create
        public async Task<IActionResult> Create()
        {
            var leaveRequestVM = new LeaveRequestCreateViewModel();
            ViewData["LeaveTypeId"] = new SelectList(await _leaveTypeRepository.GetAllAsync(), "Id", "Name");
            return View(leaveRequestVM);
        }

        // POST: LeaveRequests/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveRequestCreateViewModel leaveRequestVM)
        {
            if (ModelState.IsValid)
            {
                var leaveRequest = _mapper.Map<LeaveRequest>(leaveRequestVM);
                await _leaveRequestRepository.CreateWithCurrentUser(leaveRequest);

                return RedirectToAction(nameof(Index), "Home");
            }

            ViewData["LeaveTypeId"] = new SelectList(await _leaveTypeRepository.GetAllAsync(), "Id", "Name", leaveRequestVM.LeaveTypeId);
            return View(leaveRequestVM);
        }

        public async Task<IActionResult> Cancel(int id)
        {
            await _leaveRequestRepository.CancelLeaveRequest(id);
            return RedirectToAction(nameof(MyLeaves));
        }

        [Authorize(Roles = UserRoleConstants.Administrator)]
        public async Task<IActionResult> RequestStatistics()
        {
            var leaveStatistics = await _leaveRequestService.GetAdminLeaveStatisticsAsync();
            return View(leaveStatistics);
        }

        [Authorize(Roles = UserRoleConstants.Administrator)]
        public async Task<IActionResult> LeaveRequestsList()
        {
            var leaveRequestsList = await _leaveRequestService.GetAdminLeaveRequestsListAsync();
            return View(leaveRequestsList);
        }
    }
}