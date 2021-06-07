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
    public class PermissionController : ControllerBase
    {

        private readonly IPermissionService _permissionService;
        private readonly IMapper _mapper;

        public PermissionController(IPermissionService permissionService, IMapper mapper)
        {
            _permissionService = permissionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPermissions()
        {
            var roles = await _permissionService.GetPermissions();
            var rolesDTO = _mapper.Map<IEnumerable<PermissionDTO>>(roles);

            return Ok(rolesDTO);
        }


        [HttpGet("idRole")]
        public async Task<IActionResult> Get(int idRole)
        {

            var permissions = await _permissionService.GetPermissionByRoleId(idRole);
            var permissionsDTO = _mapper.Map<IEnumerable<PermissionDTO>>(permissions);
          
            return Ok(permissionsDTO);

        }

    }
}
