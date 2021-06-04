using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecurityUser.Core.Interfaces;
using SecurityUser.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityUser.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
           _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            
            var users = await _userRepository.GetUsers();
            return Ok(users);
        }
    }
}
