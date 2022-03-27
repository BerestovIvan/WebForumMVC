using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class CommentModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string ApplicationUserId { get; set; }
        public UserModel ApplicationUser { get; set; }
        public Guid ArticleId { get; set; }
        public ArticleModel Article { get; set; }
    }
}
