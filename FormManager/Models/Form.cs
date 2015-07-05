using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormManager.Models
{
    public class Form
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public string Description { get; set; }

        public virtual IList<Question> Questions { get; set; }
    }
}