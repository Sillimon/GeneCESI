using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneCESI.Lib.Helpers
{
    public static class CommonHelpers
    {
        public static List<string> StatementsToString(string statements) => statements.Split(';').ToList<string>();
    }
}
