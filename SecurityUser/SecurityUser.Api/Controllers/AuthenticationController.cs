using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SecurityUser.Core.DTOs;
using SecurityUser.Core.Entities;
using SecurityUser.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SecurityUser.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public AuthenticationController(IConfiguration configuration, IMapper mapper, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Authentication(UserLoginDTO userLoginDTO)
        {
            var userMap = _mapper.Map<User>(userLoginDTO);
            var user = await _userService.GetUserByLogin(userMap);
            if (user != null)
            { 
                var token = GenerateToken(user);
                return Ok(new { token }); 
            }

            return NotFound();
        }

      

        private string GenerateToken(User user)
        {
            #region Header
            var _symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var singinCredentials = new SigningCredentials(_symetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(singinCredentials);
            #endregion
            #region Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,user.Names),
                new Claim(ClaimTypes.Role,user.IdRoleNavigation.Name),
                new Claim(ClaimTypes.Email,user.Email)

            };
            #endregion
            #region Payload
            var payload = new JwtPayload
            (
                 _configuration["Authentication:Issuer"],
                  _configuration["Authentication:Audience"],
                  claims,
                  DateTime.Now,
                  DateTime.UtcNow.AddMinutes(2)
            );
            #endregion

            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
