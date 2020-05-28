using GeneCESI.Lib.Objects;
using GeneCESI.Lib.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeneCESI.Controllers
{
    public class TeacherController : Controller
    {
        public ActionResult Index()
        {
            ExamRepository repoExam = new ExamRepository(new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDb;Initial Catalog=geneCesi2;Integrated Security=True;Pooling=False"));
            List<Exam> exams = repoExam.GetAll().ToList();
            return View(exams);
        }
    }
}