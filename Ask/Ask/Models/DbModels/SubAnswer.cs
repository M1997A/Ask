using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ask.Models.DbModels
{
    public class SubAnswer
    {
        public long SubAnswerId { get; set; }
        public string Body { get; set; }
        public DateTime CommentedDate { get; set; }

        public long AnswerId { get; set; }
        public Answer Answer { get; set; }

      
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
