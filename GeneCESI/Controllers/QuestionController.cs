using GeneCESI.Lib.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
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
                //TempData sert a garder l'exam jusque dans la prochaine action
                TempData["exam"] = model.exam;
                TempData.Keep("exam");
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

        public ActionResult GetCreatedExam(Exam_Questions_Answers model)
        {
            Exam exam = TempData["exam"] as Exam;
            model.exam = exam;
            foreach(var item in model.questions)
            {
                item.Type = model.exam.ExamType;
            }
            //Insert Exam SIMON
            return View(model);
        }
    }
}
