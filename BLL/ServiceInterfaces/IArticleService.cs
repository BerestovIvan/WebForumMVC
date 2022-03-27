using BLL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.ServiceInterfaces
{
    interface IArticleService
    {
        Task<IEnumerable<ArticleModel>> Get();
        Task<ArticleModel> Get(Guid id);
        Task<ArticleModel> Create(ArticleModel articleModel);
        Task<ArticleModel> Update(ArticleModel articleModel);
        Task Delete(Guid id);
    }
}