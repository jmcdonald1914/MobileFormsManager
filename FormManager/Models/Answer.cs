using Newtonsoft.Json;
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

       [JsonIgnore]
        public virtual Question Question { get; set; }
    }
}