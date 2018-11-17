using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustWriteAPI.Models.Database
{
    public class CommentActivity
    {
        public int AuthorId { get; set; }
        public int CommentId { get; set; }
        public bool IsLiked { get; set; }
        public DateTime ActivityDate { get; set; } 

        public virtual Author Author { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
