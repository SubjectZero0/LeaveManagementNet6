using AutoMapper;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Views;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace LeaveManagement.Web.Services
{
    public interface ILeaveRequestService
    {
        Task<EmployeeLeavesListViewModel> GetMyLeavesAsync();

        Task<AdminLeaveStatisticsViewModel> GetAdminLeaveStatisticsAsync();

        Task<List<AdminLeaveRequestsListViewModel>> GetAdminLeaveRequestsListAsync();
    }

    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly IMapper _mapper;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveAllocationsRepository _leaveAllocationsRepository;
        private readonly UserManager<Employee> _userManager;

        public LeaveRequestService(IMapper mapper,
                                   ILeaveRequestRepository leaveRequestRepository,
                                   ILeaveAllocationsRepository leaveAllocationsRepository,
                                   UserManager<Employee> userManager)
        {
            _mapper = mapper;
            _leaveRequestRepository = leaveRequestRepository;
            _leaveAllocationsRepository = leaveAllocationsRepository;
            _userManager = userManager;
        }

        public async Task<List<AdminLeaveRequestsListViewModel>> GetAdminLeaveRequestsListAsync()
        {
            var leaveRequests = await _leaveRequestRepository.GetAllWithLeaveTypeAsync();
            var adminLeaveRequestsList = _mapper.Map<List<AdminLeaveRequestsListViewModel>>(leaveRequests);

            foreach (var leaveRequest in adminLeaveRequestsList)
            {
                var employee = await _userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId);
                var employeeVM = _mapper.Map<EmployeesViewModel>(employee);

                leaveRequest.RequestingEmployee = employeeVM;
            }

            return adminLeaveRequestsList;
        }

        public async Task<AdminLeaveStatisticsViewModel> GetAdminLeaveStatisticsAsync()
        {
            var leaveRequests = await _leaveRequestRepository.GetAllAsync();
            var leaveDaysApproved = 0;

            leaveRequests.ForEach(leaveRequest =>
            {
                if (leaveRequest.IsCancelled is false && leaveRequest.IsApproved is true)
                {
                    leaveDaysApproved += (int)(leaveRequest.DateEnded.Date - leaveRequest.DateStarted.Date).TotalDays + 1;
                }
            });

            var statistics = new AdminLeaveStatisticsViewModel()
            {
                Approved = leaveRequests.Count(entity => entity.IsCancelled is false && entity.IsApproved is true),
                Rejected = leaveRequests.Count(entity => entity.IsCancelled is false && entity.IsApproved is false),
                Pending = leaveRequests.Count(entity => entity.IsCancelled is false && entity.IsApproved is null),
                Cancelled = leaveRequests.Count(entity => entity.IsCancelled is true),
                Total = leaveRequests.Count(),
                LeaveDaysApproved = leaveDaysApproved
            };

            return statistics;
        }

        public async Task<EmployeeLeavesListViewModel> GetMyLeavesAsync()
        {
            var user = await _leaveRequestRepository.GetCurrentUser();

            // get the model lists
            var leaveAllocations = await _leaveAllocationsRepository.GetAllByEmployeeAsync(user.FindFirstValue(ClaimTypes.NameIdentifier));
            var leaveRequests = await _leaveRequestRepository.GetAllEmployeeRequestsAsync(user.FindFirstValue(ClaimTypes.NameIdentifier));

            // get the ViewModel lists
            var leaveAllocationsVM = _mapper.Map<List<LeaveAllocationsListViewModel>>(leaveAllocations);
            var leaveRequestsVM = _mapper.Map<List<LeaveRequestsListViewModel>>(leaveRequests);

            // create a new instance of EmployeeLeavesListViewModel
            var employeeLeavesList = new EmployeeLeavesListViewModel()
            {
                LeaveAllocations = leaveAllocationsVM,
                LeaveRequests = leaveRequestsVM
            };

            return employeeLeavesList;
        }
    }
}