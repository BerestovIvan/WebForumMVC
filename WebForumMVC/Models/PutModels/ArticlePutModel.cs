using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebForumMVC.Models.PutModels
{
    public class ArticlePutModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string CreatorId { get; set; }
        public Guid TopicId { get; set; }
    }
}
