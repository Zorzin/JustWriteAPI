using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustWriteAPI.Models.Database
{
    public class AgeRestriction
    {
        public int Id { get; set; }
        public DateTime MinimalBirthday { get; set; }
    }
}
