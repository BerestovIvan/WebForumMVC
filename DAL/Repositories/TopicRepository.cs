using DAL.DbContext;
using DAL.Entity;
using DAL.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        readonly ApplicationDbContext context;

        public TopicRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Topic>> Get()
        {
            return await context.Topics.AsNoTracking().ToListAsync();
        }

        public async Task<Topic> Get(Guid id)
        {
            return await context.Topics.AsNoTracking().FirstOrDefaultAsync(topic => topic.Id == id);
        }

        public async Task<Topic> Get(string title)
        {
            return await context.Topics.AsNoTracking().FirstOrDefaultAsync(topic => topic.Title == title);
        }

        public async Task<Topic> Create(Topic topic)
        {
            context.Topics.Add(topic);
            await context.SaveChangesAsync();
            return topic;
        }

        public async Task<Topic> Update(Topic topic)
        {
            context.Topics.Update(topic);
            await context.SaveChangesAsync();
            return topic;
        }

        public async Task Delete(Topic topic)
        {
            context.Topics.Remove(topic);
            await context.SaveChangesAsync();
        }
    }
}