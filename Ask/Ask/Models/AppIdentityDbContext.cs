using Ask.Models.DbModels;
using Ask.Models.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ask.Models
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options) { }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<QuestionComment> QuestionComments { get; set; }
        public DbSet<AnswerComment> AnswerComments { get; set; }
       
        public DbSet<Tag> Tags { get; set; }

        public DbSet<QuestionTag> QuestionTags { get; set; }
        public DbSet<QuestionVote> QuestionVotes { get; set; }
        public DbSet<AnswerVote> AnswerVotes { get; set; }

        public DbQuery<QuestionView> QuestionViews { get; set; }
        //public DbQuery<AnswerDetails> AnswerDetails { get; set; }
        //public DbQuery<SubAnswerDetails> SubAnswerDetails { get; set; }
    }
   
}
