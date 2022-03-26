using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entity
{
    public class ApplicationUser : IdentityUser
    {
        [NotMapped]
        public string Password { get; set; }
        public ICollection<Comment> CreatedComments { get; set; }
        public ICollection<Article> CreatedArticles { get; set; }
    }
}
