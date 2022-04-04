using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class TopicDalModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int ArticleNumber { get; set; }
    }
}
