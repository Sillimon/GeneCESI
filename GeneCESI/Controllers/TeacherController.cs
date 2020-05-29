using GeneCESI.Lib.Objects;
using GeneCESI.Lib.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            //Accès à la base de données
            ExamRepository repoExam = new ExamRepository(new SqlConnection(@"Data Source = (LocalDb)\MSSQLLocalDB;  Integrated Security=SSPI;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False; AttachDbFilename=" +
           Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
           @"\GeneCESI_BDD.mdf;"));
            List<Exam> exams = repoExam.GetAll().ToList();
            return View(exams);
        }
    }
}