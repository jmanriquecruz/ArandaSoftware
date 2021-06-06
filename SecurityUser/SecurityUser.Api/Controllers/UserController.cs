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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper  _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsers();
            var usersDTO = _mapper.Map<IEnumerable<UserDTO>>(users);
            
            return Ok(usersDTO);
        }


        [HttpPost]
        [Route("InsertUser")]
        public async Task<IActionResult>InsertUser(UserDTO userDTO)
        {
     
            var user = _mapper.Map<User>(userDTO);
            await _userService.InsertUser(user);
            userDTO = _mapper.Map<UserDTO>(user);
            var response = new ApiResponse<UserDTO>(userDTO);

            return Ok(response);

        }


        [HttpPut]
        public async Task<IActionResult> Put(int id, UserDTO userDTO)
        {

            var user = _mapper.Map<User>(userDTO);
            user.IdUser = id;
            var result = await _userService.UpdateUser(user);
            var response = new ApiResponse<bool>(result);

            return Ok(response);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.DeleteUser(id);
            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }
    }
}
