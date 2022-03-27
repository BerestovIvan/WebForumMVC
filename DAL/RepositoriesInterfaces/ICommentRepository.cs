using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RepositoriesInterfaces
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> Get();
        Task<Comment> Get(Guid id);
        Task<Comment> Create(Comment comment);
        Task<Comment> Update(Comment comment);
        Task Delete(Comment comment);
    }
}
