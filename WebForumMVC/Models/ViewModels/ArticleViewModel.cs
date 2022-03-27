using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebForumMVC.Models.ViewModels
{
    public class ArticleViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string CreatorId { get; set; }
        public UserViewModel Creator { get; set; }
        public Guid TopicId { get; set; }
        public TopicViewModel Topic { get; set; }
        public ICollection<CommentViewModel> Comments { get; set; }
    }
}
