using FormManager.Data;
using FormManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormManager.Controllers
{   [Authorize]
    public class FormController : Controller
    {
        // GET: Form
        public ActionResult Menu()
        {
            FormManagerContext ctxt = new FormManagerContext();

            //ctxt.Forms.Add(new Form { Name = "Test", Description = "None" });
            //ctxt.SaveChanges();

            return View();
        }

        public ActionResult Build()
        {
            var frm = new Form();

            frm.Id = 1;
            frm.Name = "Roadmap for Reflection";
            frm.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
            
            frm.Questions=new List<Question>();

            frm.Questions.Add(new Question {Id=1,
                Description="What are your next steps?",
                Answers=new List<Answer>(){
                    new Answer{Id=1,
                        Description="Know",
                        NextQuestionId=2},
                    new Answer{Id=2,
                        Description="Don't Know",
                        NextQuestionId=4},
                    }});

            frm.Questions.Add(new Question {Id=2,
                Description="Based on your past experience or what you know about job hunting, how could you get started?",
                Answers=new List<Answer>(){
                    new Answer{Id=1,
                        Description="Know",
                        NextQuestionId=3},
                    new Answer{Id=2,
                        Description="Don't Know",
                        NextQuestionId=4},
                    }});
     
            frm.Questions.Add(new Question {Id=3,
                Description="When will you do that?",
                Answers=new List<Answer>()});

            frm.Questions.Add(new Question {Id=4,
                Description="Why are you here?",
                Answers=new List<Answer>(){
                    new Answer{Id=1,
                        Description="Know",
                        NextQuestionId=1},
                    new Answer{Id=2,
                        Description="Don't Know",
                        NextQuestionId=4},
                    }});

            return View();
        }
    }
}