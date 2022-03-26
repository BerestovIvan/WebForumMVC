using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entity
{
    public class Article
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string CreatorId { get; set; }
        [ForeignKey("CreatorId")]
        public ApplicationUser Creator { get; set; }
        public Guid TopicId { get; set; }
        public Topic Topic { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
