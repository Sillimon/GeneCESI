using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneCESI.Lib.Objects
{
    public class Exam
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public int NbrQuestions { get; set; }
        public int Time { get; set; }
        public DateTime EndDate { get; set; }
        public int Tries { get; set; }

        public Exam() { }
        public Exam(string label, int nbrQuestions, int time, DateTime endDate, int tries, int id = 0)
            => (this.Id, this.Label, this.NbrQuestions, this.Time, this.EndDate, this.Tries) = (id, label, nbrQuestions, time, endDate, tries);
    }
}
