using System;

namespace DAL.Entity
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Guid ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
