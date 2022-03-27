using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.RepositoriesInterfaces
{
    public interface ITopicRepository
    {
        Task<IEnumerable<Topic>> Get();
        Task<Topic> Get(Guid id);
        Task<Topic> Get(string title);
        Task<Topic> Create(Topic topic);
        Task<Topic> Update(Topic topic);
        Task Delete(Topic topic);
    }
}
