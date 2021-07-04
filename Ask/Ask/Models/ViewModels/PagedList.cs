using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ask.Models.ViewModels
{
    public class PagedList<T> : List<T>
    {
        public PagedList(IQueryable<T> query,int currentPage)
        {
            CurrentPage = currentPage;
            TotalPages = query.Count() / 50;
            AddRange(query.Skip((currentPage - 1) * 50).Take(50));
        }
       
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }

        public bool HasNextPage => CurrentPage < TotalPages;
        public bool HasPreviousPage => CurrentPage > 1;
    }
    public class QuestionView
    {
        public long QuestionId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int AnswerCount { get; set; }
        public int Vote { get; set; }

        public string UserId { get; set; }
        public string UserName { get; set; }

        public string ImagePath { get; set; }
        public DateTime PostedDate { get; set; }
        [NotMapped]

        public IEnumerable<DTags> QTags { get; set; }
        [NotMapped]
        public TimeSpan TimeSpan { get; set; }
    }

    public class DTags
    {
       
        public long TagId { get; set; }
        public string Name { get; set; }
    }
    
}
