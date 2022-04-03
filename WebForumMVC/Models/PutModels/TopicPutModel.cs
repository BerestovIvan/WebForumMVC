using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebForumMVC.Models.PutModels
{
    public class TopicPutModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
