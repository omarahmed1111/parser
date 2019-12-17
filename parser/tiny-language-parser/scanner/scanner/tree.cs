using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scanner
{
    
    public class tree
    {
        public string text;
        public bool type;
        public List<tree> children;
        public List<tree> friends;
        public tree(bool ty,string value)
        {
            text = value;
            type = ty;
            friends = new List<tree>();
            children = new List<tree>();
        }
    }
}
