using System;
using System.Collections.Generic;

namespace DesignPatterns1_LogischCircuit.Models.Nodes
{
    class AndNode : Node
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

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
            Output = output;
        }

        public override string GetTypeName()
        {
            return "AND";
        }
    }
}
