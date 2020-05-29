using GeneCESI.Lib.Objects;
using GeneCESI.Lib.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneCESI.TestIt
{
    [TestClass]
    class ExamCRUD
    {
        static IRepository<Exam> _examRepo = new ExamRepository(new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" +
           Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()))) +
           @"\GeneCESI_BDD.mdf;Integrated Security=True;Connect Timeout=30"));

        [TestMethod]
        public bool ExamAdd()
        {
            var newExam = new Exam("Exam ASP", 3, 20, new DateTime(500), 3);

            try { _examRepo.Insert(newExam); } catch { return false; }

            return true;
        }

        [TestMethod]
        public bool ExamDelete()
        {
            var exam = new Exam();
            exam.Id = 1;
            try { _examRepo.Delete(exam); } catch { return false; }

            return true;
        }

        [TestMethod]
        public bool ExamGetById()
        {
            var exam = new Exam();

            try { exam = _examRepo.GetById(1); } catch { return false; }

            return true;
        }

        [TestMethod]
        public bool ExamGetAll()
        {
            var exams = new List<Exam>();

            try { exams = _examRepo.GetAll().ToList<Exam>(); } catch { return false; }

            foreach (var e in exams)
                Console.WriteLine(e.ToString());

            return true;
        }
    }
}
