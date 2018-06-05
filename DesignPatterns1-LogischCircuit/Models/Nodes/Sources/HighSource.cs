using System;

namespace DesignPatterns1_LogischCircuit.Models.Nodes.Sources
{
    class HighSource : Source
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public HighSource()
        {
            _output = true;
        }
        
        public override string GetTypeName()
        {
            return "INPUT_HIGH";
        }
    }
}
