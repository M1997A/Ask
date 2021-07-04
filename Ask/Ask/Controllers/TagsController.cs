using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ask.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ask.Controllers
{
    public class TagsController : Controller
    {
        private ITagRepository tagRepository;
        public TagsController(ITagRepository tagRepo)
        {
            tagRepository = tagRepo;
        }
        public IActionResult Index()
        {
            return View(tagRepository.GetTags());
        }
    }
}
