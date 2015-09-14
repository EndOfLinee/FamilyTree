using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree.Models
{
    public class TreeWrapper
    {
        public Tree tree { get; set; }
        public List<Node> nodes { get; set; }
    }
}
