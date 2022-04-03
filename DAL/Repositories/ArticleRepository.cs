using DAL.DbContext;
using DAL.Entity;
using DAL.Models;
using DAL.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        readonly ApplicationDbContext context;

        public ArticleRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Article>> Get(QueryParams queryParams)
        {
            IQueryable<Article> articles = context.Articles;

            foreach (var predicate in queryParams.Predicates)
                articles = articles.Where(predicate);

            return await articles.
                Include(x => x.Comments).
                Include(x => x.Creator).
                Include(x => x.Topic).
                AsNoTracking().ToListAsync();
        }

        public async Task<Article> Get(Guid id)
        {
            return await context.Articles.
                Include(x => x.Comments).
                Include(x => x.Creator).
                Include(x => x.Topic).
                AsNoTracking().
                FirstOrDefaultAsync(article => article.Id == id);
        }

        public async Task<Article> Create(Article article)
        {
            context.Articles.Add(article);
            await context.SaveChangesAsync();
            return article;
        }

        public async Task<Article> Update(Article article)
        {
            context.Articles.Update(article);
            await context.SaveChangesAsync();
            return article;
        }

        public async Task Delete(Article article)
        {
            context.Articles.Remove(article);
            await context.SaveChangesAsync();
        }
    }
}
