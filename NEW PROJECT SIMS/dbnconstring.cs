using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW_PROJECT_SIMS
{
    class dbnconstring
    {
        public static string connection = System.IO.File.ReadAllText(System.Environment.CurrentDirectory + @"\config.jo");
    }
}
