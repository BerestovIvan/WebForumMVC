using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebForumMVC.Models.QueryParam
{
    public class QueryParamsViewModel
    {
        public Guid? TopicId { get; set; }
        public string UserId { get; set; }
    }
}