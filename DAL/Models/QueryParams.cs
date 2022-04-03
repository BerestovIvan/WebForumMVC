using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class QueryParams
    {
        public List<Expression<Func<Article, bool>>> Predicates { get; set; }
    }
}
