using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormManager.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Description { get; set; }
        [MaxLength(5000)]
        public string Script { get; set; }

        public string Color { get; set; }

        public virtual IList<Answer> Answers { get; set; }
    }
}