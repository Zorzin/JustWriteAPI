using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustWriteAPI.Models.Database
{
    public class AuthorFollowing
    {
        public int AuthorId { get; set; }
        public int FollowingAuthorId { get; set; }
        public DateTime FollowDate { get; set; }

        public virtual Author Author { get; set; }
        public virtual Author FollowingAuthor { get; set; }
    }
}
