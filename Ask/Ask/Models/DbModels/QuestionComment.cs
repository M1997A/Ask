using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ask.Models.DbModels
{
    public class QuestionComment
    {
        public long QuestionCommentId { get; set; }
        public string Body { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public DateTime CommentDate { get; set; }
        public long QuestionId { get; set; }
        public Question Question { get; set; }

    }
}
