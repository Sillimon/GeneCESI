﻿using System;
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
        public string Type { get; set; }
        public string Statements { get; set; }

        public Answer(int id, string correct, string type, string statements)
            => (this.Id, this.Correct, this.Type, this.Statements) = (id, correct, type, statements);
    }
}
