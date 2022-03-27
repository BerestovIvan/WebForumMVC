using BLL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.ServiceInterfaces
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentModel>> Get();
        Task<CommentModel> Get(Guid id);
        Task<CommentModel> Create(CommentModel commentModel);
        Task<CommentModel> Update(CommentModel commentModel);
        Task Delete(Guid id);
    }
}
