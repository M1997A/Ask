using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ask.Models.DbModels
{
    public class QuestionVote
    {
        public long Id { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public Question Question { get; set; }
        public long QuestionId { get; set; }
        public bool Vote { get; set; }
    }
}
