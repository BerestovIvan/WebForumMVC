using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.DbContext;
using DAL.Entity;
using BLL.Models;
using WebForumMVC.Models.PutModels;
using BLL.ServiceInterfaces;
using AutoMapper;

namespace WebForumMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(UserPutModel userPutModel)
        {
            userPutModel.Id = Request.Headers["UserId"];
            await userService.ChangePassword(mapper.Map<UserModel>(userPutModel));
            return RedirectToAction("Index", "User");
        }      
    }
}
