using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecurityUser.Api.Responses;
using SecurityUser.Core.DTOs;
using SecurityUser.Core.Entities;
using SecurityUser.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityUser.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {

        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public ProfileController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _roleService.GetRoles();
            var rolesDTO = _mapper.Map<IEnumerable<RoleDTO>>(roles);

            return Ok(rolesDTO);
        }


        [HttpGet("idRole")]
        public async Task<IActionResult> Get(int idRole)
        {

            var role = await _roleService.GetRoleById(idRole);
            var roleDTO = _mapper.Map<RoleDTO>(role);
            var response = new ApiResponse<RoleDTO>(roleDTO);

            return Ok(response);

        }

    }
}
