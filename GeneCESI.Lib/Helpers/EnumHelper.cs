using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneCESI.Lib.Helpers
{
    public static class EnumHelper
    {
        [Flags]
        public enum QuestionType 
        { 
            UniqueChoice,
            MultipleChoice,
            Cloze,
            Textual,
            YesNo,
        };

        public static T ToEnum<T, Y>(this Y value)
        {
            return (T)Enum.ToObject(typeof(T), value);
        }
    }
}
