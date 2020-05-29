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
    class QuestionCRUD
    {
        static IRepository<Question> _questionRepo = new QuestionRepository(new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" +
           Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()))) +
           @"\GeneCESI_BDD.mdf;Integrated Security=True;Connect Timeout=30"));

        [TestMethod]
        public bool QuestionAdd()
        {
            var newQuestion = new Question("42?", Lib.Helpers.EnumHelper.QuestionType.YesNo, new Answer(), new Exam());

            try { _questionRepo.Insert(newQuestion); } catch { return false; }

            return true;
        }

        [TestMethod]
        public bool QuestionDelete()
        {
            var question = new Question();
            question.Id = 1;
            try { _questionRepo.Delete(question); } catch { return false; }

            return true;
        }

        [TestMethod]
        public bool QuestionGetById()
        {
            var question = new Question();

            try { question = _questionRepo.GetById(1); } catch { return false; }

            return true;
        }

        [TestMethod]
        public bool QuestionGetAll()
        {
            var questions = new List<Question>();

            try { questions = _questionRepo.GetAll().ToList<Question>(); } catch { return false; }

            foreach (var q in questions)
                Console.WriteLine(q.ToString());

            return true;
        }
    }
}
