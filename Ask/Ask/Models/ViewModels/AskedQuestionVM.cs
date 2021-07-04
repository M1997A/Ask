using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ask.Models.ViewModels
{
    public class AskedQuestionVM
    {
        [Required(ErrorMessage ="You must type the question title")]
        public string Title { get; set; }
        [Required(ErrorMessage ="You must enter your question")]
        public string Body { get; set; }
        [Required(ErrorMessage = "You must select at least one tag")]
        public long[] TagIds { get; set; }

        public IEnumerable<TagsVM> TagsList { get; set; }
    }
    public class TagsVM
    {
        public string Name { get; set; }
        public long Id { get; set; }
    }
}

