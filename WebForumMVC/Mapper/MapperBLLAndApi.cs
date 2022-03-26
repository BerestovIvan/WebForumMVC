using AutoMapper;
using BLL.Models;
using WebForumMVC.Models.AuthenticationModels;

namespace WebForumMVC.Mapper
{
    public class MapperBLLAndApi : Profile
    {
        public MapperBLLAndApi()
        {
            CreateMap<RegisterPostModel, RegisterModel>().ReverseMap();
            CreateMap<LoginModel, LoginPostModel>().ReverseMap();

        }
    }
}
