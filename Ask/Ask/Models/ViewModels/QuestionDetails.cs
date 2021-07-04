using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ask.Models.ViewModels
{
    public class QuestionDetails
    {
        public long QuestionId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PostedDate { get; set; }
        public string AppUserId { get; set; }
        public string UserName { get; set; }
        public string ImagePath { get; set; }
        public int Vote { get; set; }
        public IEnumerable<QuestionCommentVM> QuestionComments { get; set; }
        public IEnumerable<QuesTag> QuesTags { get; set; }
        public IEnumerable<AnswerDetails> AnswerDetails { get; set; }

    }
    public class AnswerDetails
    {
        public long AnswerId { get; set; }
        public string Body { get; set; }
        public DateTime CommentedDate { get; set; }
        public int Vote { get; set; }
        public string ImagePath { get; set; }
        public string AppUserId { get; set; }
        public string UserName { get; set; }
        public IEnumerable<AnswerCommentVM> AnswerComments { get; set; }
    }
   
    public class QuesTag
    {
        public long TagId { get; set; }
        public string TagName { get; set; }

    }
    public class AnswerCommentVM
    {
        public long AnswerCommentId { get; set; }
        public string Body { get; set; }
        public string AppUserId { get; set; }
        public string UserName { get; set; }
        public DateTime CommentDate { get; set; }
        //public long AnswerId { get; set; }

       
    }
    public class QuestionCommentVM
    {
        public long QuestionCommentId { get; set; }
        public string Body { get; set; }
        public string AppUserId { get; set; }
        public string UserName { get; set; }
        public DateTime CommentDate { get; set; }
        public long QuestionId { get; set; }
        
    }
}
