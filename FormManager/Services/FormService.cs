using FormManager.Data;
using FormManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using RefactorThis.GraphDiff;

namespace FormManager.Services
{

    public class FormService
    {
        private FormManagerContext context;

        public FormService()
        {
            context = new FormManagerContext();
        }

        public IList<Form> GetForms()
        {
            return context.Forms.ToList();
        }

        public Form GetForm(int formId)
        {
            return context.Forms.FirstOrDefault(f => f.Id == formId);
        }

        public bool UpdateForm(Form form)
        {
            //context.Entry(form).State = form.Id == 0 ?
            //                      EntityState.Added :
            //                      EntityState.Modified;
            if(form.Id==0)
            {
                context.Forms.Add(form);

            }
            else { 
                context.UpdateGraph(form, map => map
                                .OwnedCollection(p => p.Questions, with => with
                                    .OwnedCollection(p => p.Answers)));
            }
            
            context.SaveChanges();

            return true;
        }
    }
}