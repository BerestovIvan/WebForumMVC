using AutoMapper;
using BLL.Models;
using BLL.ServiceInterfaces;
using WebForumMVC.Models.AuthenticationModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace WebForumMVC.Controllers
{
    [Route("[controller]")]
    public class AuthenticateController : Controller
    {
        readonly IUserService userService;
        readonly IMapper mapper;
        public AuthenticateController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterPostModel registerPostModel)
        {
            var result = await userService.Register(mapper.Map<RegisterModel>(registerPostModel));
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response { Status = "Error", Message = "User already exists!" });
            }
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
            }
            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        [Authorize(Roles ="Admin")]
        [HttpPost("Register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterPostModel registerPostModel)
        {
            var result = await userService.RegisterAdmin(mapper.Map<RegisterModel>(registerPostModel));
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response { Status = "Error", Message = "Admin already exists!" });
            }

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response { Status = "Error", Message = "Admin creation failed! Please check user details and try again." });
            }

            return Ok(new Response { Status = "Success", Message = "Admin created successfully!" });
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginPostModel model)
        {
            var token = await userService.Login(mapper.Map<LoginModel>(model));

            if (token != null)
            {
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();

        }
    }
}
