using GeneCESI.Lib.Objects;
using GeneCESI.Lib.Repositories;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeneCESI.Controllers
{
    public class TeacherController : Controller
    {
        public ActionResult Index()
        {
            ExamRepository repoExam = new ExamRepository(new SqliteConnection(@"Data Source=" +
           Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()))) +
           @"\GeneCESI_DB.db;"));

            List<Exam> exams = repoExam.GetAll().ToList();
            return View(exams);
        }
    }
}