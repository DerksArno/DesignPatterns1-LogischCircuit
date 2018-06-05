using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1_LogischCircuit.Models.Nodes
{
    class PropagationVisitor : IVisitor
    {
        private int _output = 0;

        public int Output
        {
            get { return _output; }
        }

        public void Visit(Node node)
        {
            _output += 15;
        }
    }
}
