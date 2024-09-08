using HRMApp.Data;
using HRMApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedDataController : ControllerBase
    {
        private IRepository<Branch> _branchRepository;
        private IRepository<Department> _departmentRepository;

        public SeedDataController(IRepository<Branch> branchRepository, IRepository<Department> departmentRepository)
        {
            _branchRepository = branchRepository;
            _departmentRepository = departmentRepository;
        }

        [HttpPost]
        [Route("AddSeedData")]
        public async Task<IActionResult> AddSeedData()
        {
            SeedData _SeedData = new();
            int totalBranchAdded = 0;
            int totalDepartmentAdded = 0;

            var allBranch = await _branchRepository.GetAllAsync();
            if (allBranch.Count() < 1)
            {
                var _GetBranchList = _SeedData.GetBranchList();
                foreach (var item in _GetBranchList)
                {
                    _branchRepository.Add(item);
                    await _branchRepository.SaveChangesAsync();
                    totalBranchAdded = totalBranchAdded + 1;
                }
            }

            var allDepartment = await _departmentRepository.GetAllAsync();
            if (allDepartment.Count() < 1)
            {
                var _GetDepartmentList = _SeedData.GetDepartmentList();
                foreach (var item in _GetDepartmentList)
                {
                    _departmentRepository.Add(item);
                    await _departmentRepository.SaveChangesAsync();
                    totalDepartmentAdded = totalDepartmentAdded + 1;
                }
            }

            return Ok("Branch Added:" + totalBranchAdded + "\nDepartment Added:" + totalDepartmentAdded);
        }
    }
}
