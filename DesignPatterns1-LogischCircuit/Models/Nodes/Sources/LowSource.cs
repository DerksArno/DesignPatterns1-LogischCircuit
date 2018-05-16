using System;

namespace DesignPatterns1_LogischCircuit.Models.Nodes.Sources
{
    class LowSource : Source
    {
        public override string GetTypeName()
        {
            return "INPUT_LOW";
        }
    }
}
