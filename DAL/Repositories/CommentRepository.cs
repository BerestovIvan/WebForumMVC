using DAL.DbContext;
using DAL.Entity;
using DAL.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        readonly ApplicationDbContext context;

        public CommentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Comment>> Get()
        {
            return await context.Comments.
                Include(x=>x.ApplicationUser).
                AsNoTracking().
                ToListAsync();
        }

        public async Task<Comment> Get(Guid id)
        {
            return await context.Comments.
                Include(x => x.ApplicationUser).
                AsNoTracking().
                FirstOrDefaultAsync(comment => comment.Id == id);
        }

        public async Task<Comment> Create(Comment comment)
        {
            context.Comments.Add(comment);
            await context.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment> Update(Comment comment)
        {
            context.Comments.Update(comment);
            await context.SaveChangesAsync();
            return comment;
        }

        public async Task Delete(Comment comment)
        {
            context.Comments.Remove(comment);
            await context.SaveChangesAsync();
        }
    }
}
