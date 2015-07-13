using FormManager.Data;
using FormManager.Models;
using FormManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormManager.Controllers
{   [Authorize]
    public class FormController : Controller
    {
        private FormService svc;

        public FormController() { svc = new FormService(); }
        // GET: Form
        public ActionResult Menu()
        {
            FormManagerContext ctxt = new FormManagerContext();

            //ctxt.Forms.Add(new Form { Name = "Test", Description = "None" });
            //ctxt.SaveChanges();

            return View();
        }
        [HttpPost]
        public ActionResult Update(Form frm)
        {
            svc.UpdateForm(frm);

            return View("Build",frm);
        }

        public ActionResult Build()
        {
            var frm = svc.GetForm(3);

      
            return View(frm);
        }
       
    
    [AllowAnonymous]
        public JsonResult Demo()
        {
            var frm = new Form();

            frm.Id = 1;
            frm.Name = "Roadmap for Reflection";
            frm.Description = "Roadmap for Reflection";

            frm.Questions = new List<Question>();

            frm.Questions.Add(new Question
            {
                Id = 1,
                Description = "What is the job going to help you do?",
                Answers = new List<Answer>(){
                    new Answer{Id=1,
                        Description="Next",
                        NextQuestionId=2}
                    }
            });

            frm.Questions.Add(new Question
            {
                Id = 2,
                Description = "What kind of job are you thinking about?",
                Answers = new List<Answer>(){
                    new Answer{Id=1,
                        Description="Next",
                        NextQuestionId=3}
                    }
            });

          

            frm.Questions.Add(new Question
            {
                Id = 3,
                Description = "How will that help you provide long-term for your family?",
                Answers = new List<Answer>(){
                    new Answer{Id=1,
                        Description="Will Provide",
                        NextQuestionId=4},
                    new Answer{Id=2,
                        Description="Won't Provide",
                        NextQuestionId=5},
                    }
            });

            frm.Questions.Add(new Question
            {
                Id = 4,
                Description = "What have you done so far?",
                Answers = new List<Answer>(){
                    new Answer{Id=1,
                        Description="Something",
                        NextQuestionId=6},
                    new Answer{Id=2,
                        Description="Nothing",
                        NextQuestionId=7},
                    }
            });
            frm.Questions.Add(new Question
            {
                Id = 5,
                Description = "What are your thoughts about a long-yerm solution (to financial stability)?",
                Answers = new List<Answer>(){
                    new Answer{Id=1,
                        Description="Know",
                        NextQuestionId=2},
                    new Answer{Id=2,
                        Description="Don't Know",
                        NextQuestionId=4},
                    }
            });

            frm.Questions.Add(new Question
            {
                Id = 6,
                Description = "What are your next steps?",
                Answers = new List<Answer>(){
                    new Answer{Id=1,
                        Description="Know",
                        NextQuestionId=8},
                    new Answer{Id=2,
                        Description="Don't Know",
                        NextQuestionId=7},
                    }
            });

            frm.Questions.Add(new Question
            {
                Id = 7,
                Description = "Based on your past experience or what you know about job hunting, how could you get started?",
                Answers = new List<Answer>(){
                    new Answer{Id=1,
                        Description="Know",
                        NextQuestionId=6},
                    new Answer{Id=2,
                        Description="Don't Know",
                        NextQuestionId=8},
                    }
            });

            frm.Questions.Add(new Question
            {
                Id = 8,
                Description = "When should we revisit this plan?",
                Answers = new List<Answer>()
            });

            JsonResult jr= new JsonResult();

            //jr.Data=frm;
            return Json(frm,JsonRequestBehavior.AllowGet);
        }
    }
}