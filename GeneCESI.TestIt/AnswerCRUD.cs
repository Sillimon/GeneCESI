using GeneCESI.Lib.Objects;
using GeneCESI.Lib.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneCESI.TestIt
{
    [TestClass]
    class AnswerCRUD
    {
        static IRepository<Answer> _answerRepo = new AnswerRepository(new SqliteConnection(@"Data Source=" +
           Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()))) +
           @"\GeneCESI_DB.db;"));

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
