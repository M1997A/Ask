using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ask.Models.DbModels
{
    public class Answer
    {
        public long AnswerId { get; set; }
        public string Body { get; set; }
        public DateTime CommentedDate { get; set; }

        public long QuestionId { get; set; }
        public Question Question { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        
    }
}
