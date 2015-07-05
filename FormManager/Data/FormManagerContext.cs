using FormManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FormManager.Data
{
    public class FormManagerContext: DbContext
    {
        public FormManagerContext()
            : base("formmanager")
        { }
        public DbSet<Form> Forms { get; set; }
    }
}