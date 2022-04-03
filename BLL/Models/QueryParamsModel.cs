using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class QueryParamsModel
    {
        public Guid? TopicId { get; set; }
        public string UserId { get; set; }
    }
}
