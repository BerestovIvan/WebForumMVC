using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class Topic
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}