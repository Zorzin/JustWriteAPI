using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustWriteAPI.Models.Database
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public virtual IEnumerable<ArticleTag> ArticleTags { get; set; }
    }
}
