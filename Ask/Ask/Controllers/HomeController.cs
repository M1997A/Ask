using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Ask.Models.Repositories;
using Ask.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ask.Controllers
{
    public class HomeController : Controller
    {

        private IQuestionRepository questionRepository;
        public HomeController(IQuestionRepository questionRepo)
        {
            questionRepository = questionRepo;
        }
     
        public IActionResult Index(int currentPage = 1)
        {
           
            return View(questionRepository.GetQuestionsList(currentPage));
        }
        
    }
}
