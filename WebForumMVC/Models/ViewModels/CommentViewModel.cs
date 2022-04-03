using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebForumMVC.Models.ViewModels
{
    public class CommentViewModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public UserViewModel ApplicationUser { get; set; }
        public Guid ArticleId { get; set; }
    }
}