using AutoMapper;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Views;
using System.Security.Claims;

namespace LeaveManagement.Web.Services
{
    public interface ILeaveRequestService
    {
        Task<EmployeeLeavesListViewModel> GetMyLeavesAsync();
    }

    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly IMapper _mapper;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveAllocationsRepository _leaveAllocationsRepository;

        public LeaveRequestService(IMapper mapper,
                                   ILeaveRequestRepository leaveRequestRepository,
                                   ILeaveAllocationsRepository leaveAllocationsRepository)
        {
            _mapper = mapper;
            _leaveRequestRepository = leaveRequestRepository;
            _leaveAllocationsRepository = leaveAllocationsRepository;
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