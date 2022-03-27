using AutoMapper;
using BLL.Exceptions;
using BLL.Models;
using BLL.ServiceInterfaces;
using DAL.Entity;
using DAL.RepositoriesInterfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace BLL.Services
{
    public class ArticleService : IArticleService
    {
        readonly IArticleRepository articleRepository;
        readonly IMapper mapper;
        public ArticleService(IArticleRepository articleRepository, IMapper mapper)
        {
            this.articleRepository = articleRepository;
            this.mapper = mapper;
        }
        public async Task<ArticleModel> Create(ArticleModel articleModel)
        {
            articleModel.Id = Guid.NewGuid();
            await articleRepository.Create(mapper.Map<Article>(articleModel));
            return articleModel;

        }

        public async Task Delete(Guid id)
        {
            var model = await articleRepository.Get(id);
            if (model == null)
            {
                throw new EntityNotFoundException("This article doesn't exists");
            }
            else
            {
                await articleRepository.Delete(model);
            }
        }

        public async Task<IEnumerable<ArticleModel>> Get()
        {
            var articles = await articleRepository.Get();
            return mapper.Map<IEnumerable<ArticleModel>>(articles);
        }

        public async Task<ArticleModel> Get(Guid id)
        {
            var article = await articleRepository.Get(id);
            if (article == null)
            {
                throw new EntityNotFoundException("This article doesn't exists");
            }
            else
            {
                return mapper.Map<ArticleModel>(article);
            }
        }

        public async Task<ArticleModel> Update(ArticleModel articleModel)
        {
            var article = await articleRepository.Get(articleModel.Id);
            if (article == null)
            {
                throw new EntityNotFoundException("This article doesn't exists");
            }
            else
            {
                article = await articleRepository.Update(mapper.Map<Article>(articleModel));
                return mapper.Map<ArticleModel>(article);
            }
        }
    }
}
