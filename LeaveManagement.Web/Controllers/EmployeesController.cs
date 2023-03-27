using AutoMapper;
using LeaveManagement.Web.Configurations.Entities;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagement.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly UserManager<Employee> _userManager;
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationsRepository _leaveAllocationsRepository;

        public EmployeesController(
            UserManager<Employee> userManager,
            IMapper mapper,
            ILeaveAllocationsRepository leaveAllocationsRepository)
        {
            this._userManager = userManager;
            this._mapper = mapper;
            this._leaveAllocationsRepository = leaveAllocationsRepository;
        }

        /// <summary>
        /// GET all regular Users != Admin
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            List<Employee> employees = new(await _userManager.GetUsersInRoleAsync(UserRoleConstants.User));
            List<EmployeesViewModel> employeeList = _mapper.Map<List<EmployeesViewModel>>(employees);

            return View(employeeList);
        }

        /// <summary>
        /// GET details of particular user with provided Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The Profile of the User whose Id was provided</returns>
        public async Task<IActionResult> Details(string? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            Employee employee = await _userManager.FindByIdAsync(id);

            if (employee is null)
            {
                return NoContent();
            }

            EmployeesViewModel employeeViewModel = _mapper.Map<EmployeesViewModel>(employee);
            return View(employeeViewModel);
        }

        public async Task<IActionResult> ViewLeaveAllocations(string? id)
        {
            if (id is null)
            {
                return NotFound(nameof(id));
            }

            List<LeaveAllocation> employeeLeaveAllocations = await _leaveAllocationsRepository.GetAllByEmployeeAsync(id);

            if (!employeeLeaveAllocations.Any())
            {
                return RedirectToAction(nameof(Index));
            }

            var employeeLeaveAllocationsVM = _mapper.Map<List<LeaveAllocationsViewModel>>(employeeLeaveAllocations);
            return View(employeeLeaveAllocationsVM);
        }

        /// <summary>
        /// GET the leave allocation for the specific employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The view of the specific leave allocation in Editable Form</returns>
        public async Task<IActionResult> EditAllocation(int id)
        {
            LeaveAllocation? leaveAllocation = await _leaveAllocationsRepository.FindByEmployeeAsync(id);

            LeaveAllocationsViewModel leaveAllocationsVM = _mapper.Map<LeaveAllocationsViewModel>(leaveAllocation);
            return View(leaveAllocationsVM);
        }

        /// <summary>
        /// Edit The Leave Allocation of the Employee
        /// </summary>
        /// <param name="id">The Id of the leave allocation to be edited. Tracked by form.</param>
        /// <param name="leaveAllocationVM">The view model of the leave allocation.</param>
        /// <param name="employeeId">The Id of the employee. Tracked by form.</param>
        /// <returns>The edited leave allocation instance</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAllocation(int id, string employeeId, LeaveAllocationsViewModel leaveAllocationVM)
        {
            if (employeeId is null)
            {
                throw new Exception($"Employee Id {employeeId} does not exist");
            }

            var leaveAllocation = await _leaveAllocationsRepository.GetAsync(id);

            if (leaveAllocation is null)

            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _leaveAllocationsRepository.UpdateEmployeeAllocation(leaveAllocation, leaveAllocationVM);

                return RedirectToAction(nameof(ViewLeaveAllocations), new { id = employeeId });
            }
            return View(leaveAllocationVM);
        }
    }
}