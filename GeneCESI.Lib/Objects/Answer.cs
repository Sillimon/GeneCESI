using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneCESI.Lib.Objects
{
    public class Answer
    {
        public int Id { get; set; }
        public string Correct { get; set; }
        public string Statements { get; set; }

        public Answer() { }
        public Answer(string correct, string statements, int id = 0)
            => (this.Id, this.Correct, this.Statements) = (id, correct, statements);
    }
}
