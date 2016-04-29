using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTDD
{
    class Ctype
    {
        class Exercise
        {
            public int Number;
            public int Type;
            public string Stem;
            public string[] Choice = new string[Const.MAXN_Choice];
            public string Answer;
        }
    }
}
