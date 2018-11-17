using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustWriteAPI.Models.Database
{
    public class Author
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastLoginDate { get; set; }

        public virtual IEnumerable<AuthorFollowing> AuthorFollowings { get; set; }
        public virtual IEnumerable<CommentActivity> CommentActivities { get; set; }
        public virtual IEnumerable<Article> Articles { get; set; }
        public virtual IEnumerable<ArticleActivity> ArticleActivities { get; set; }
    }
}
