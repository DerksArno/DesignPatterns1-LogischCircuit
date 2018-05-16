using System;
using System.Collections.Generic;

namespace DesignPatterns1_LogischCircuit.Models.Nodes
{
    class NandNode : Node
    {
        public override void CalculateOutput()
        {
            bool output = true;
            foreach (KeyValuePair<Node, bool> entry in _inputs)
            {
                if (entry.Value == false)
                {
                    output = false;
                    break;
                }
            }
            _output = !output;
        }

        public override string GetTypeName()
        {
            return "NAND";
        }
    }
}
