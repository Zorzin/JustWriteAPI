using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustWriteAPI.Models.Database
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int AuthorId { get; set; }
        public int AgeRestrictionId { get; set; }

        public virtual Author Author { get; set; }
        public virtual AgeRestriction AgeRestriction { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; }
        public virtual IEnumerable<ArticleTag> ArticleTags { get; set; }
        public virtual IEnumerable<ArticleActivity> ArticleActivities { get; set; }
    }
}
