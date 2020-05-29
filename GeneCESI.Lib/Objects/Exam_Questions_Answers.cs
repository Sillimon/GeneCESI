using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneCESI.Lib.Objects
{
    public class Exam_Questions_Answers
    {
        public Exam exam { get; set; }
        public List<Question> questions { get; set; }
    }
}
