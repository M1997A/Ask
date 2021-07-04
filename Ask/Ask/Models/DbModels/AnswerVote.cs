using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ask.Models.DbModels
{
    public class AnswerVote
    {
        public long Id { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public Answer Answer { get; set; }
        public long AnswerId { get; set; }
        public bool Vote { get; set; }
    }
}
