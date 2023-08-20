using Microsoft.AspNetCore.Mvc;
using DataModels.Entity;
using Business_Logic_Layer.Data_Transfer_Object;
using Service_Layer;

namespace API_Account.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleService _roleService;
        private GenericService<Role, RoleDTO> _genericRole;

        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
            _genericRole = new GenericService<Role, RoleDTO>();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRole()
        {
            var listRole = _genericRole.GetAllEntities(await _roleService.GetAllRoleAsync());
            return Ok(listRole);
        }
        /*[Authorize]*/
        [HttpGet("GetId")]
        public async Task<IActionResult> GetByIdRole(string id)
        {
            var role = _genericRole.GetEntityById(await _roleService.GetRoleAsync(id));
            return Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleDTO roleModel)
        {
            var role = _genericRole.ConvertEntity(roleModel);
            var result = await _roleService.AddRoleAsync(role);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest(result.ErrorMessage);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateRole(RoleDTO roleModel)
        {
            var role = _genericRole.ConvertEntity(roleModel);
            var result = await _roleService.UpdateRoleAsync(role);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest(result.ErrorMessage);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var result = await _roleService.DeleteRoleAsync(id);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest(result.ErrorMessage);
        }
    }
}
