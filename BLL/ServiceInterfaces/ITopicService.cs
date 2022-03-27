using BLL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.ServiceInterfaces
{
    public interface ITopicService
    {
        Task<IEnumerable<TopicModel>> Get();
        Task<TopicModel> Get(Guid id);
        Task<TopicModel> Create(TopicModel topicModel);
        Task<TopicModel> Update(TopicModel topicModel);
        Task Delete(Guid id);
    }
}
