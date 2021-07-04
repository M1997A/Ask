using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ask.Models;
using Ask.Models.DbModels;
using Ask.Models.Repositories;
using Ask.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : Controller
    {
        private UserManager<AppUser> userManager;
        private IQuestionRepository questionRepository;
        public AnswerController(IQuestionRepository repository, UserManager<AppUser> user)
        {
            questionRepository = repository;
            userManager = user;
        }
      
        [HttpPost]
        public  AnswerDetails Post([FromBody] Answer answer)
        {
            AnswerDetails dbAnswer = new AnswerDetails();
            if (answer.AppUserId == null)
            {
                answer.AppUserId = userManager.GetUserId(User);

            }
            if (answer.Body != null && answer.AppUserId != null && answer.QuestionId > 0)
            {
                
                answer.CommentedDate = DateTime.Now;
                long answerId =  questionRepository.AddAnswer(answer);

                dbAnswer = new AnswerDetails
                {
                    Body = answer.Body,
                    ImagePath = userManager.FindByIdAsync(answer.AppUserId).Result.ImagePath,
                    UserName = userManager.GetUserName(User),
                    AppUserId = answer.AppUserId,
                    AnswerId = answerId  
                };

            }
                

            
            return dbAnswer;
        }

        
    }
}
