﻿using AutoMapper;
using DAL.DbContext;
using DAL.Entity;
using DAL.Models;
using DAL.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        readonly ApplicationDbContext context;
        readonly IMapper mapper;

        public TopicRepository(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<TopicDalModel>> Get()
        {
            var topics = await context.Topics.AsNoTracking().ToListAsync();

            var topicModels = mapper.Map<List<TopicDalModel>>(topics);

            var articles = await context.Articles.AsNoTracking().ToListAsync();

            foreach(var topic in topicModels)
            {
                topic.ArticleNumber = articles.Count(article => article.TopicId == topic.Id);
            }
            return topicModels;
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
            List<Comment> comments = new List<Comment>();
            var articles = await context.Articles.Where(article => article.TopicId == topic.Id).AsNoTracking().ToListAsync();
            foreach(var article in articles)
            {
                comments.AddRange(context.Comments.Where(comment => comment.ArticleId == article.Id).AsNoTracking());
            }
            context.Comments.RemoveRange(comments);

            context.Articles.RemoveRange(articles);

            context.Topics.Remove(topic);
            await context.SaveChangesAsync();
        }
    }
}