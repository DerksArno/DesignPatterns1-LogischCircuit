using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1_LogischCircuit.Models.Nodes
{
    class ProbeNode : Node
    {
        public override string GetTypeName()
        {
            return "PROBE";
        }
    }
}
