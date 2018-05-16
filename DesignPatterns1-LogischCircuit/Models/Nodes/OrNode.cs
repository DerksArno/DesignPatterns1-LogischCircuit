using System;
using System.Collections.Generic;

namespace DesignPatterns1_LogischCircuit.Models.Nodes
{
    public class OrNode : Node
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
            _output = output;
        }

        public override string GetTypeName()
        {
            return "OR";
        }
    }
}
