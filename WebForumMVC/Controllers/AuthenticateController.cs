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

        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterPostModel registerPostModel)
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

        [Authorize(Roles = "Admin")]
        [HttpGet("Register-admin")]
        public IActionResult RegisterAdmin()
        {
            return View();
        }

        [Authorize(Roles ="Admin")]
        [HttpPost("Register-admin")]
        public async Task<IActionResult> RegisterAdmin(RegisterPostModel registerPostModel)
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


        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginPostModel model)
        {
            var loginResultModel = await userService.Login(mapper.Map<LoginModel>(model));

            var loginResultPostModel = mapper.Map<LoginResultPostModel>(loginResultModel);

            if (loginResultPostModel.Token != null)
            {
                HttpContext.Session.SetString("UserId", loginResultPostModel.UserId);
                HttpContext.Session.SetString("token", new JwtSecurityTokenHandler().WriteToken(loginResultPostModel.Token));
                Request.Headers.Add("Authorization", "Bearer" + new JwtSecurityTokenHandler().WriteToken(loginResultPostModel.Token));
                return RedirectToAction("Index", "Articles");
            }
            return Unauthorized();
        }

        [HttpGet("Logout")]
        public void Logout()
        {
            HttpContext.Session.SetString("UserId", "");
            HttpContext.Session.SetString("Token", "");
        }
    }
}