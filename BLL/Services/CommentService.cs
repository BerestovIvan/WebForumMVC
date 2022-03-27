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
    public class CommentService : ICommentService
    {
        readonly ICommentRepository commentRepository;
        readonly IMapper mapper;
        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            this.commentRepository = commentRepository;
            this.mapper = mapper;
        }
        public async Task<CommentModel> Create(CommentModel commentModel)
        {
            commentModel.Id = Guid.NewGuid();
            await commentRepository.Create(mapper.Map<Comment>(commentModel));
            return commentModel;
        }

        public async Task Delete(Guid id)
        {
            var model = await commentRepository.Get(id);
            if (model == null)
            {
                throw new EntityNotFoundException("This comment doesn't exists");
            }
            else
            {
                await commentRepository.Delete(model);
            }
        }

        public async Task<IEnumerable<CommentModel>> Get()
        {
            var comments = await commentRepository.Get();
            return mapper.Map<IEnumerable<CommentModel>>(comments);
        }

        public async Task<CommentModel> Get(Guid id)
        {
            var comment = await commentRepository.Get(id);
            if (comment == null)
            {
                throw new EntityNotFoundException("This comment doesn't exists");
            }
            else
            {
                return mapper.Map<CommentModel>(comment);
            }
        }

        public async Task<CommentModel> Update(CommentModel commentModel)
        {
            var comment = await commentRepository.Get(commentModel.Id);
            if (comment == null)
            {
                throw new EntityNotFoundException("This comment doesn't exists");
            }
            else
            {
                comment = await commentRepository.Update(mapper.Map<Comment>(commentModel));
                return mapper.Map<CommentModel>(comment);
            }
        }
    }
}
