using HRMApp.Data;
using HRMApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private IRepository<Department> _departmentRepository;

        public DepartmentController(IRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        [HttpGet]
        [Route("GetAllDepartmentes")]
        public async Task<ActionResult<IEnumerable<Department>>> GetAllDepartmentes()
        {
            return Ok(await _departmentRepository.GetAllAsync());
        }
        [HttpGet]
        [Route("GetDepartmentById/{id}")]
        public async Task<ActionResult<Department>> GetDepartmentById(Int64 id)
        {
            return Ok(await _departmentRepository.GetByIdAsync(id));
        }
        [HttpGet]
        [Route("GetDepartmentByName/{DepartmentName}")]
        public async Task<ActionResult<Department>> GetDepartmentByName(string DepartmentName)
        {
            return Ok(await _departmentRepository.FindByConditionAsync(x => x.Name == DepartmentName));
        }


        [HttpPost]
        [Route("AddDepartment")]
        public async Task<IActionResult> AddDepartment([FromBody] Department Department)
        {
            _departmentRepository.Add(Department);
            return Ok(await _departmentRepository.SaveChangesAsync());
        }
        [HttpPut]
        [Route("UpdateDepartment")]
        public async Task<IActionResult> UpdateDepartment([FromBody] Department Department)
        {
            _departmentRepository.Update(Department);
            return Ok(await _departmentRepository.SaveChangesAsync());
        }
        [HttpDelete]
        [Route("DeleteDepartment")]
        public async Task<IActionResult> DeleteDepartment(Int64 id)
        {
            await _departmentRepository.DeleteAsync(id);
            return Ok(await _departmentRepository.SaveChangesAsync());
        }
    }
}
