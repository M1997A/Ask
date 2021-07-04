using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ask.Models.ViewModels
{
    public class AnswerVoteVM
    {
        public long AnswerId { get; set; }
        public string AppUserId { get; set; }
        public bool Vote { get; set; }
    }
}
