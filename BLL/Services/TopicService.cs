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
    public class TopicService : ITopicService
    {
        readonly ITopicRepository topicRepository;
        readonly IMapper mapper;
        public TopicService(ITopicRepository topicRepository, IMapper mapper)
        {
            this.topicRepository = topicRepository;
            this.mapper = mapper;
        }
        public async Task<TopicModel> Create(TopicModel topicModel)
        {
            var model = await topicRepository.Get(topicModel.Title);
            if (model == null)
            {
                topicModel.Id = Guid.NewGuid();
                await topicRepository.Create(mapper.Map<Topic>(topicModel));
                return topicModel;
            }
            else
            {
                throw new EntityAlreadyExistsException("Topic with this title allready exists");
            }
        }

        public async Task Delete(Guid id)
        {
            var model = await topicRepository.Get(id);
            if (model == null)
            {
                throw new EntityNotFoundException("This topic doesn't exists");
            }
            else
            {
                await topicRepository.Delete(model);
            }
        }

        public async Task<IEnumerable<TopicModel>> Get()
        {
            var topics = await topicRepository.Get();
            return mapper.Map<IEnumerable<TopicModel>>(topics);
        }

        public async Task<TopicModel> Get(Guid id)
        {
            var topic = await topicRepository.Get(id);
            if (topic == null)
            {
                throw new EntityNotFoundException("This topic doesn't exists");
            }
            else
            {
                return mapper.Map<TopicModel>(topic);
            }
        }

        public async Task<TopicModel> Update(TopicModel topicModel)
        {
            var topic = await topicRepository.Get(topicModel.Id);
            if (topic == null)
            {
                throw new EntityNotFoundException("This topic doesn't exists");
            }
            else
            {
                topic = await topicRepository.Update(mapper.Map<Topic>(topicModel));
                return mapper.Map<TopicModel>(topic);
            }
        }
    }
}