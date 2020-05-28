using GeneCESI.Lib.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeneCESI.Controllers
{
    public class QuestionController : Controller
    {
        // GET: Question
        public ActionResult Index()
        {
            return View();
        }
        // POST: Question/Create
        [HttpPost]
        public ActionResult Create(Exam_Questions_Answers model)
        {
            try
            {
                // TODO: Add insert logic here
                //Insert l'exam
                return View("ListQuestions", model);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ListQuestions()
        {
            return View();
        }
    }
}
