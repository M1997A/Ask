using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ask.Models;
using Ask.Models.DbModels;
using Ask.Models.Repositories;
using Ask.Models.ViewModels;
using Ganss.XSS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ask.Controllers
{
    public class QuestionsController : Controller
    {
        private UserManager<AppUser> userManager;
        private IQuestionRepository questionRepository;
        private ITagRepository tagRepository;
        public QuestionsController(UserManager<AppUser> userMngr,IQuestionRepository questionRepo,ITagRepository tagRepo)
        {
            tagRepository = tagRepo;
            userManager = userMngr;
            questionRepository = questionRepo;
        }
        [Authorize]
        public IActionResult AskView()
        {
            AskedQuestionVM askedQuestionVM = new AskedQuestionVM() { TagsList = tagRepository.TagsList };
            return View(askedQuestionVM);
        }
        [Authorize]
        [HttpPost]
        public IActionResult AskView(AskedQuestionVM askedQuestion)
        {
            if (ModelState.IsValid)
            {
                Question question = new Question
                {
                    AppUserId = userManager.GetUserId(User),
                    Body = askedQuestion.Body,
                    Title = askedQuestion.Title,
                    PostedDate = DateTime.Now,
                    
                };
                long? QuestionId = questionRepository.AddQuestion(question);
                List<QuestionTag> QuestionTagsList = new List<QuestionTag>();
                if (QuestionId.HasValue)
                {
                    foreach (long TagId in askedQuestion.TagIds)
                    {
                        QuestionTagsList.Add(new QuestionTag() { QuestionId = QuestionId.Value, TagId = TagId });
                    }
                }
                if(QuestionTagsList.Count > 0)
                {
                    questionRepository.AddQuestionTags(QuestionTagsList);
                }
                return RedirectToAction("QuestionDetails", new { Id = QuestionId });
            }
            askedQuestion.TagsList = tagRepository.TagsList;
            return View(askedQuestion);
        }
        [HttpPost]
        public string AddAnswer([FromBody]Answer answer)
        {
            Answer dbAnswer = new Answer();
            if(answer.AppUserId == null)
            {
                 dbAnswer.AppUserId =  userManager.GetUserId(User);
                
            }
            if(answer.Body != null && answer.AppUserId != null && answer.QuestionId > 0)
            {
                dbAnswer.Body = answer.Body;
                dbAnswer.AppUserId = answer.AppUserId;
                dbAnswer.QuestionId = answer.QuestionId;
                dbAnswer.CommentedDate = DateTime.Now;
                questionRepository.AddAnswer(dbAnswer);
                
            }
            return dbAnswer.AppUserId;
        }
        
        public IActionResult QuestionDetails(long Id)
        {
            QuestionDetails questionDetails = questionRepository.GetQuestion(Id);
            return View(questionDetails );
        }
        [HttpPost("questionVote")]
        public long QuestionVote([FromBody] QuestionVoteVM questionVoteVM)
        {
            int vote = questionRepository.CheckVote(questionVoteVM);
            
            return vote;
        }

        [HttpPost("answerVote")]
        public long AnswerVote([FromBody] AnswerVoteVM answerVoteVM)
        {
            int vote = questionRepository.CheckAnswerVote(answerVoteVM);

            return vote;
        }
        [HttpPost("addQuestioComment")]
        public QuestionCommentVM AddQuestionComment([FromBody] QuestionCommentVM questionCommentVM)
        {
            QuestionCommentVM questionCommentvm = questionRepository.AddQuestioComment(questionCommentVM);
            questionCommentvm.UserName = userManager.GetUserName(User);
            return questionCommentvm;
        }
    }
}
