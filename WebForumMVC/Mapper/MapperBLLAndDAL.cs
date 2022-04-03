using AutoMapper;
using BLL.Models;
using DAL.Entity;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

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

            CreateMap<TopicModel, Topic>().ReverseMap();

            CreateMap<ArticleModel, Article>().ReverseMap();
            CreateMap<UserModel, ApplicationUser>().ReverseMap();

            CreateMap<CommentModel, Comment>().ReverseMap();

            CreateMap<LoginResultModel, LoginResult>().ReverseMap();

            CreateMap<QueryParamsModel, QueryParams>()
               .ConvertUsing((src, dest) =>
               {
                   dest = new QueryParams();
                   dest.Predicates = new List<Expression<Func<Article, bool>>>();
                   if(!string.IsNullOrEmpty(src.UserId))
                   {
                       dest.Predicates.Add(article => article.CreatorId == src.UserId);
                   }

                   if (src.TopicId.HasValue)
                   {
                       dest.Predicates.Add(article => article.TopicId == src.TopicId);
                   }
                 return dest;
               });
        }
    }
}
