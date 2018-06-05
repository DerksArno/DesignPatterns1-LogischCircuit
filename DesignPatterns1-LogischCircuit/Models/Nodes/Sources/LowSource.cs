using System;

namespace DesignPatterns1_LogischCircuit.Models.Nodes.Sources
{
    class LowSource : Source
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string GetTypeName()
        {
            return "INPUT_LOW";
        }
    }
}
