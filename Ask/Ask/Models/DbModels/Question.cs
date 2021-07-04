using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ask.Models.DbModels
{
    public class Question
    {
        public long QuestionId { get; set; }
        public string Title { get; set; }
        

        public string Body { get; set; }
        public DateTime PostedDate { get; set; }
        public string AppUserId { get; set; }


        public AppUser AppUser { get; set; }
        
    }
}
