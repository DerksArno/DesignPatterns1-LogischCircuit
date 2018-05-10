using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1_LogischCircuit.Models.Nodes
{
    class XorNode : Node
    {
        public override void CalculateOutput()
        {
            int trueCounter = 0;
            int falseCounter = 0;
            foreach (KeyValuePair<Node, bool> entry in _inputs)
            {
                if (entry.Value == true)
                {
                    trueCounter++;
                }
                else
                {
                    falseCounter++;
                }
            }

            bool output = false;
            if (trueCounter == falseCounter)
            {
                output = true;
            }
            _output = output;
        }

        public override string GetTypeName()
        {
            return "XOR";
        }
    }
}
