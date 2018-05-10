using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1_LogischCircuit.Models.Nodes
{
    class NorNode : Node
    {
        public override void CalculateOutput()
        {
            bool output = false;
            foreach (KeyValuePair<Node, bool> entry in _inputs)
            {
                if (entry.Value == true)
                {
                    output = true;
                    break;
                }
            }
            _output = !output;
        }

        public override string GetTypeName()
        {
            return "NOR";
        }
    }
}
