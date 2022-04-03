using DAL.Entity;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.RepositoriesInterfaces
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> Get(QueryParams queryParams);
        Task<Article> Get(Guid id);
        Task<Article> Create(Article article);
        Task<Article> Update(Article article);
        Task Delete(Article article);
    }
}
