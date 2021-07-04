using Ask.Models.DbModels;
using Ask.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ask.Models.Repositories
{
    public interface ITagRepository
    {
        IEnumerable<TagsVM> TagsList { get; }
        IEnumerable<Tag> GetTags();
    }
    public class TagRepository : ITagRepository
    {
        private AppIdentityDbContext context;
        public TagRepository(AppIdentityDbContext dbContext) => context = dbContext;

        public IEnumerable<TagsVM> TagsList => context.Tags.Select(t => new TagsVM() { Id = t.TagId , Name = t.Name}).ToArray();

        public IEnumerable<Tag> GetTags()
        {
            return context.Tags;
        }
    }
}
