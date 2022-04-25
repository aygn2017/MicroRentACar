using MicroRentACar.Models;
using MicroRentACar.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroRentACar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepo _roleRepo;
        public RoleController(IRoleRepo roleRepo)
        {
            _roleRepo = roleRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            IEnumerable<Role> roles = await _roleRepo.GetRoles();
            return new OkObjectResult(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleByID(int id)
        {
            Role role= await _roleRepo.GetRoleByID(id);
            return new OkObjectResult(role);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole([FromBody] Role role)
        {
            await _roleRepo.AddRole(role);
            return new NoContentResult();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRole([FromBody] Role role)
        {
            if (role != null)
            {
                await _roleRepo.UpdateRole(role);
                return new OkResult();
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            await _roleRepo.DeleteRole(id);
            return new OkResult();
        }

    }
}
