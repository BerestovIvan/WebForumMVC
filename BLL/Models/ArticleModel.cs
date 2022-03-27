using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class ArticleModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string CreatorId { get; set; }
        public UserModel Creator { get; set; }
        public Guid TopicId { get; set; }
        public TopicModel Topic { get; set; }
        public ICollection<CommentModel> Comments { get; set; }
    }
}
