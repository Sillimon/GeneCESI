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
    class AnswerCRUD
    {
        static IRepository<Answer> _answerRepo = new AnswerRepository(new SqlConnection(@"Data Source = (LocalDb)\MSSQLLocalDB; Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False; AttachDbFilename=" +
           Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
           @"\GeneCESI_BDD.mdf;"));

        [TestMethod]
        public bool AnswerAdd()
        {
            var newAnswer = new Answer("Yes", "Yes;No");

            try { _answerRepo.Insert(newAnswer); } catch { return false; }

            return true;
        }

        [TestMethod]
        public bool AnswerDelete()
        {
            var answer = new Answer();
            answer.Id = 1;
            try { _answerRepo.Delete(answer); } catch { return false; }

            return true;
        }

        [TestMethod]
        public bool AnswerGetById()
        {
            var answer = new Answer();

            try { answer = _answerRepo.GetById(1); } catch { return false; }

            return true;
        }

        [TestMethod]
        public bool AnswerGetAll()
        {
            var answers = new List<Answer>();

            try { answers = _answerRepo.GetAll().ToList<Answer>(); } catch { return false; }

            foreach (var a in answers)
                Console.WriteLine(a.ToString());

            return true;
        }
    }
}
