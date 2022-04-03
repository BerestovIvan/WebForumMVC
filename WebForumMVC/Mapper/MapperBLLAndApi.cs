using AutoMapper;
using BLL.Models;
using WebForumMVC.Models.AuthenticationModels;
using WebForumMVC.Models.PostModels;
using WebForumMVC.Models.PutModels;
using WebForumMVC.Models.QueryParam;
using WebForumMVC.Models.ViewModels;

namespace WebForumMVC.Mapper
{
    public class MapperBLLAndApi : Profile
    {
        public MapperBLLAndApi()
        {
            CreateMap<RegisterPostModel, RegisterModel>().ReverseMap();
            CreateMap<LoginModel, LoginPostModel>().ReverseMap();

            CreateMap<TopicViewModel, TopicModel>().ReverseMap();
            CreateMap<TopicPostModel, TopicModel>().ReverseMap();
            CreateMap<TopicPutModel, TopicModel>().ReverseMap();

            CreateMap<ArticleViewModel, ArticleModel>().ReverseMap();
            CreateMap<ArticlePostModel, ArticleModel>().ReverseMap();
            CreateMap<ArticlePutModel, ArticleModel>().ReverseMap();
            CreateMap<UserModel, UserViewModel>().ReverseMap();

            CreateMap<CommentViewModel, CommentModel>().ReverseMap();
            CreateMap<CommentPostModel, CommentModel>().ReverseMap();
            CreateMap<CommentPutModel, CommentModel>().ReverseMap();

            CreateMap<ArticleViewModel, ArticlePutModel>().ReverseMap();

            CreateMap<LoginResultModel, LoginResultPostModel>().ReverseMap();

            CreateMap<ArticlePutModel, ArticleViewModel>().ReverseMap();
            CreateMap<TopicPutModel, TopicViewModel>().ReverseMap();

            CreateMap<QueryParamsModel, QueryParamsViewModel>().ReverseMap();

            CreateMap<UserPutModel, UserModel>().ReverseMap();
        }
    }
}
