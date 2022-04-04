using DAL.Entity;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.RepositoriesInterfaces
{
    public interface ITopicRepository
    {
        Task<IEnumerable<TopicDalModel>> Get();
        Task<Topic> Get(Guid id);
        Task<Topic> Get(string title);
        Task<Topic> Create(Topic topic);
        Task<Topic> Update(Topic topic);
        Task Delete(Topic topic);
    }
}
