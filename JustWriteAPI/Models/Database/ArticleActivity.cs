using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustWriteAPI.Models.Database
{
    public class ArticleActivity
    {
        public int ArticleId { get; set; }
        public int AuthorId { get; set; }
        public bool IsLiked { get; set; }
        public bool IsRepost { get; set; }
        public bool IsVisited { get; set; }
        public DateTime? LikeDate { get; set; }
        public DateTime? RepostDate { get; set; }
        public DateTime? VisitDate { get; set; }

        public virtual Article Article { get; set; }
        public virtual Author Author { get; set; }
    }
}
