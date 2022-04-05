using AutoMapper;
using DAL.Entity;
using DAL.Models;

namespace WebForumMVC.Mapper
{
    public class MapperDal : Profile
    {
        public MapperDal()
        {
            CreateMap<Topic, TopicDalModel>().ReverseMap();
        }
    }
}
