using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scanner
{
    class node
    {
        public string tknType;
        public string tknValue;
        public node(string tknt,string tknv)
        {
            tknType = tknt;
            tknValue = tknv;
        }
    }
}
