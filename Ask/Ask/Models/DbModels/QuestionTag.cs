using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ask.Models.DbModels
{
    public class QuestionTag
    {
        public long QuestionTagId { get; set; }

        public long QuestionId {get;set;}
        public Question Question { get; set; }

        public long TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
