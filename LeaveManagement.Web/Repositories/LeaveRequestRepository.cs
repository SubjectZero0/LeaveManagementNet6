using AutoMapper;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Views;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;

namespace LeaveManagement.Web.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILeaveAllocationsRepository _leaveAllocationsRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public LeaveRequestRepository(ApplicationDbContext context,
                                      IHttpContextAccessor httpContextAccessor,
                                      ILeaveAllocationsRepository leaveAllocationsRepository,
                                      ILeaveTypeRepository leaveTypeRepository,
                                      IMapper mapper) : base(context)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _leaveAllocationsRepository = leaveAllocationsRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task CancelLeaveRequest(int id)
        {
            var request = await _context.LeaveRequests.FindAsync(id);
            if (request is null)
            {
                throw new Exception("No record found");
            }
            else
            {
                request.IsCancelled = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreateWithCurrentUser(LeaveRequest leaveRequest)
        {
            var user = await GetCurrentUser();

            if (user is not null)
            {
                leaveRequest.IsCancelled = false;
                leaveRequest.DateCreated = DateTime.Now;
                leaveRequest.DateModified = DateTime.Now;
                leaveRequest.RequestingEmployeeId = user.FindFirstValue(ClaimTypes.NameIdentifier);

                await _context.LeaveRequests.AddAsync(leaveRequest);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("You are not an authenticated user");
            }
        }

        public async Task<List<LeaveRequest>> GetAllEmployeeRequestsAsync(string employeeId)
        {
            var requests = await _context.LeaveRequests.Where(x => x.RequestingEmployeeId == employeeId).ToListAsync();

            return requests;
        }

        public async Task<ClaimsPrincipal> GetCurrentUser()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            if (user is not null)
            {
                return await Task.FromResult(user);
            }
            throw new Exception("You are not an authenticated user");
        }
    }
}