using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeneCESI.Controllers
{
    public class ExamController : Controller
    {
        // GET: Exam
        public ActionResult Evaluation()
        {
            return View();
        }

        public ActionResult CreationExamen()
        {
            return View();
        }

    }
}
