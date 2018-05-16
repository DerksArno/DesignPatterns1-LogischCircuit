using System;
using System.Linq;

namespace DesignPatterns1_LogischCircuit.Models.Nodes
{
    class NotNode : Node
    {
        public override void CalculateOutput()
        {
            Output = !_inputs.First().Value;
        }

        public override string GetTypeName()
        {
            return "NOT";
        }
    }
}
