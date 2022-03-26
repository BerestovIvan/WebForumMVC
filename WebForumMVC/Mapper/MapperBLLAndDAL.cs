using AutoMapper;
using BLL.Models;
using DAL.Entity;
using System;

namespace WebForumMVC.Mapper
{
    public class MapperBLLAndDAL : Profile
    {
        public MapperBLLAndDAL()
        {
            CreateMap<ApplicationUser, RegisterModel>().ReverseMap().
               ForMember(applicationUser => applicationUser.SecurityStamp,
               registerModel => Guid.NewGuid().ToString()).
               ForMember(applicationUser => applicationUser.UserName,
               registerModel => registerModel.MapFrom(src => src.Email));

            CreateMap<ApplicationUser, LoginModel>().ReverseMap().
                ForMember(applicationUser => applicationUser.UserName,
                loginModel => loginModel.MapFrom(src => src.Email));

        }
    }
}
