using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustWriteAPI.Models.Database
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public int ArticleId { get; set; }
        public int ParentCommentId { get; set; }
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }
        public virtual Article Article { get; set; }
        public virtual Comment ParentComment { get; set; }
        public virtual IEnumerable<CommentActivity> CommentActivities { get; set; }
    }
}
