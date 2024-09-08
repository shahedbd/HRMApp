using HRMApp.Data;
using HRMApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private IRepository<Branch> _branchRepository;

        public BranchController(IRepository<Branch> branchRepository)
        {
            _branchRepository = branchRepository;
        }
        [HttpGet]
        [Route("GetAllBranches")]
        public async Task<ActionResult<IEnumerable<Branch>>> GetAllBranches()
        {
            return Ok(await _branchRepository.GetAllAsync());
        }
        [HttpGet]
        [Route("GetBranchById/{id}")]
        public async Task<ActionResult<Branch>> GetBranchById(Int64 id)
        {
            return Ok(await _branchRepository.GetByIdAsync(id));
        }
        [HttpGet]
        [Route("GetBranchByName/{branchName}")]
        public async Task<ActionResult<Branch>> GetBranchByName(string branchName)
        {
            return Ok(await _branchRepository.FindByConditionAsync(x => x.Name == branchName));
        }


        [HttpPost]
        [Route("AddBranch")]
        public async Task<IActionResult> AddBranch([FromBody] Branch branch)
        {
            _branchRepository.Add(branch);
            return Ok(await _branchRepository.SaveChangesAsync());
        }
        [HttpPut]
        [Route("UpdateBranch")]
        public async Task<IActionResult> UpdateBranch([FromBody] Branch branch)
        {
            _branchRepository.Update(branch);
            return Ok(await _branchRepository.SaveChangesAsync());
        }
        [HttpDelete]
        [Route("DeleteBranch/{id}")]
        public async Task<IActionResult> DeleteBranch(Int64 id)
        {
            await _branchRepository.DeleteAsync(id);
            return Ok(await _branchRepository.SaveChangesAsync());
        }
    }
}
