using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormManager.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public virtual IList<Answer> Answers { get; set; }
    }
}