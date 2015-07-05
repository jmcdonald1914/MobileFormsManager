using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FormManager.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Description { get; set;}
        public int NextQuestionId { get; set; }

        [ForeignKey("NextQuestionId")]
        public virtual Question NextQuestion { get; set; }
    }
}