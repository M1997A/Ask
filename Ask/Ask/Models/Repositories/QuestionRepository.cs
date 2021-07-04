using Ask.Models.DbModels;
using Ask.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ask.Models.Repositories
{
    public interface IQuestionRepository
    {
        long AddQuestion(Question question);
        void AddQuestionTags(List<QuestionTag> questionTags);
        QuestionDetails GetQuestion(long Id);
        long AddAnswer(Answer answer);
        int CheckVote(QuestionVoteVM questionVoteVM);
        int CheckAnswerVote(AnswerVoteVM answerVoteVM);
        QuestionCommentVM AddQuestioComment(QuestionCommentVM questionCommentVM);
        PagedList<QuestionView> GetQuestionsList(int currentPage);

    }
    public class QuestionRepository : IQuestionRepository
    {
        private AppIdentityDbContext context;
        public QuestionRepository(AppIdentityDbContext dbContext) => context = dbContext;

        public long AddAnswer(Answer answer)
        {
            context.Answers.Add(answer);
            context.SaveChanges();
            return answer.AnswerId;
        }

        public long AddQuestion(Question question)
        {
            context.Questions.Add(question);
            context.SaveChanges();
            return question.QuestionId;
        }

        public void AddQuestionTags(List<QuestionTag> questionTags)
        {
            context.QuestionTags.AddRange(questionTags);
            context.SaveChanges();

        }

        public int CheckVote(QuestionVoteVM questionVoteVM)
        {
            var questionVote = context.QuestionVotes.FirstOrDefault(v => v.QuestionId == questionVoteVM.QuestionId && v.AppUserId == questionVoteVM.AppUserId);
            if (questionVote == null)
            {
                context.QuestionVotes.Add(new QuestionVote
                {
                    AppUserId = questionVoteVM.AppUserId,
                    QuestionId = questionVoteVM.QuestionId,
                    Vote = questionVoteVM.Vote
                });
                context.SaveChanges();
            }
            else
            {
                if ((questionVote.Vote == true && questionVoteVM.Vote == false) || (questionVote.Vote == false && questionVoteVM.Vote == true))
                {
                    questionVote.Vote = questionVoteVM.Vote;
                    context.QuestionVotes.Update(questionVote);
                    context.SaveChanges();
                }
            }
            //new QuestionVote
            //{
            //    Id = questionVote.Id,
            //    AppUserId = questionVote.AppUserId,
            //    QuestionId = questionVote.QuestionId,
            //    Vote = questionVoteVM.Vote
            //}
            var vote = context.QuestionVotes.Where(qv => qv.QuestionId == questionVoteVM.QuestionId).ToList();
            int votecount = vote.Where(v => v.Vote == true).Count() - vote.Where(v => v.Vote == false).Count();
            return votecount;
        }
        public int CheckAnswerVote(AnswerVoteVM answerVoteVM)
        {
            var answerVote = context.AnswerVotes.FirstOrDefault(v => v.AnswerId == answerVoteVM.AnswerId && v.AppUserId == answerVoteVM.AppUserId);
            if (answerVote == null)
            {
                context.AnswerVotes.Add(new AnswerVote
                {
                    AppUserId = answerVoteVM.AppUserId,
                    AnswerId = answerVoteVM.AnswerId,
                    Vote = answerVoteVM.Vote
                });
                context.SaveChanges();
            }
            else
            {
                if ((answerVote.Vote == true && answerVoteVM.Vote == false) || (answerVote.Vote == false && answerVoteVM.Vote == true))
                {
                    answerVote.Vote = answerVoteVM.Vote;
                    context.AnswerVotes.Update(answerVote);
                    context.SaveChanges();
                }
            }
           
            var vote = context.AnswerVotes.Where(v => v.AnswerId == answerVoteVM.AnswerId).ToList();
            int votecount = vote.Where(v => v.Vote == true).Count() - vote.Where(v => v.Vote == false).Count();
            return votecount;
        }
        public QuestionDetails GetQuestion(long Id)
        {
            
            var QuestionVote = context.QuestionVotes.Where(qv => qv.QuestionId == Id).ToList();
            int vote = QuestionVote.Where(q => q.Vote == true).Count() - QuestionVote.Where(q => q.Vote == false).Count();
            var questionDetail = context.Questions
                .Where(q => q.QuestionId == Id).
                Select(q => new QuestionDetails
                {
                    QuestionId = q.QuestionId,
                    Title = q.Title,
                    Body = q.Body,
                    PostedDate = q.PostedDate,
                    AppUserId = q.AppUserId,
                    UserName = q.AppUser.UserName,
                    ImagePath = q.AppUser.ImagePath,
                    Vote = vote

                }).ToList().FirstOrDefault();



            if (questionDetail != null)
            {
                var questionComments = context.QuestionComments.Where(qc => qc.QuestionId == questionDetail.QuestionId)
                    .Select(qc => new QuestionCommentVM {
                        QuestionCommentId = qc.QuestionCommentId,
                        CommentDate = qc.CommentDate,
                        AppUserId = qc.AppUserId,
                        UserName = qc.AppUser.UserName,
                        Body = qc.Body
                    }).ToList();

                questionDetail.QuestionComments = questionComments;

                var questionTagList = context.QuestionTags.Where(qt => qt.QuestionId == Id).
                    Select(qt => new QuesTag { TagId = qt.TagId, TagName = qt.Tag.Name });
                questionDetail.QuesTags = questionTagList;


              
                var answerDetail = context.Answers.Where(a => a.QuestionId == questionDetail.QuestionId)
                    .Select(a => new AnswerDetails
                    {
                        AnswerId = a.AnswerId,
                        Body = a.Body,
                        CommentedDate = a.CommentedDate,
                        AppUserId = a.AppUserId,
                        UserName = a.AppUser.UserName,
                        ImagePath = a.AppUser.ImagePath,
                        
                        
                    }).ToList();
                if (answerDetail != null)
                {

                    foreach (var ad in answerDetail)
                    {
                        ad.Vote = AnswerVoteCount(ad.AnswerId);
                        
                    }
                }
                questionDetail.AnswerDetails = answerDetail;
            }

            return questionDetail;
        }
        public int AnswerVoteCount(long AnswerId)
        {
            var answerVote = context.AnswerVotes.Where(av => av.AnswerId == AnswerId).ToList();
            int Avote = answerVote.Where(q => q.Vote == true).Count() - answerVote.Where(q => q.Vote == false).Count();

            return Avote;
        }

        public QuestionCommentVM AddQuestioComment(QuestionCommentVM questionCommentVM)
        {
            context.QuestionComments.Add(new QuestionComment
            {
                Body = questionCommentVM.Body,
                AppUserId = questionCommentVM.AppUserId,
                CommentDate = DateTime.Now,
                QuestionId = questionCommentVM.QuestionId
            });
            context.SaveChanges();
            return questionCommentVM;
        }

        public PagedList<QuestionView> GetQuestionsList(int currentPage)
        {

            var questions = context.QuestionViews.FromSql("spGetQuestionsDetails").OrderByDescending(q => q.PostedDate);
            var PagedList = new PagedList<QuestionView>(questions, currentPage);
            foreach(var q in PagedList)
            {
                q.QTags = context.QuestionTags.Where(qt => qt.QuestionId == q.QuestionId)
                    .Select(qt => new DTags
                    {
                        TagId = qt.TagId,
                        Name = qt.Tag.Name
                    }).ToList();
                q.TimeSpan = DateTime.Now.Subtract(q.PostedDate);
            }
            return PagedList;
        }
    }
    
}











//var questionSqlQuery = "select q.QuestionId,q.Title,q.Body,q.PostedDate,q.AppUserId,u.UserName from Questions as q join AspNetUsers as u on q.AppUserId = u.Id where q.QuestionId = " + Id;
//var questionDetail = context.QuestionDetails.FromSql(questionSqlQuery).ToList().FirstOrDefault();
//var answerSqlQuery = "select a.AnswerId,a.Body,a.CommentedDate,a.AppUserId,u.UserName from Answers as a join AspNetUsers as u on a.AppUserId = u.Id where a.QuestionId = " + questionDetail.QuestionId;
//var answerDetail = context.AnswerDetails.FromSql(answerSqlQuery).ToList();
//var subanswerSqlQuery = "select sa.SubAnswerId,sa.Body,sa.CommentedDate,sa.AnswerId,sa.AppUserId,u.UserName from SubAnswers as sa join AspNetUsers as u on sa.AppUserId = u.Id where sa.AnswerId = " + ad.AnswerId;
//var subAnswerDetail = context.SubAnswerDetails.FromSql(subanswerSqlQuery).ToList();


//var answerComments = context.AnswerComments.Where(ac => ac.AnswerId == ad.AnswerId)
//                        .Select(ac => new AnswerCommentVM
//                        {
//                            AnswerCommentId = ac.AnswerCommentId,
//                            Body = ac.Body,
//                            CommentDate = ac.CommentDate,
//                            AppUserId = ac.AppUserId,
//                            UserName = ac.AppUser.UserName
//                        }).ToList();

//ad.AnswerComments = answerComments;
//var test = from q in context.Questions
//           join a in context.Answers
//           on q.QuestionId equals a.QuestionId into lq
//           from subansw in lq.DefaultIfEmpty()
//           select new { q.QuestionId, q.Title, q.Body } into x
//           group x by new { x.QuestionId, x.Title, x.Body } into gx
//           select new QuestionView
//           {


//               QuestionId = gx.Key.QuestionId,
//               Title = gx.Key.Title,
//               Body = gx.Key.Body,
//               Votes = ((from qv in context.QuestionVotes where qv.QuestionId == gx.Key.QuestionId && qv.Vote == true select (qv.Id)).Count()
//                       - (from qv in context.QuestionVotes where qv.QuestionId == gx.Key.QuestionId && qv.Vote == false select (qv.Id)).Count()
//                       ),
//               Answers =



//                       };