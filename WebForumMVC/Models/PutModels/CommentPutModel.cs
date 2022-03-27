using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebForumMVC.Models.PutModels
{
    public class CommentPutModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string ApplicationUserId { get; set; }
        public Guid ArticleId { get; set; }
    }
}
