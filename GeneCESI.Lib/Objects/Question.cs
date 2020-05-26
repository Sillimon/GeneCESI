using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GeneCESI.Lib.Helpers.EnumHelper;

namespace GeneCESI.Lib.Objects
{
    class Question
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public QuestionType Type { get; set; }

        public Answer FK_Answers { get; set; }

        public Exam FK_Exam { get; set; }

        public Question(int id, string label, QuestionType type, Answer answer, Exam exam)
           => (this.Id, this.Label, this.Type, this.FK_Answers, this.FK_Exam) = (id, label, type, answer, exam);
    }
}
