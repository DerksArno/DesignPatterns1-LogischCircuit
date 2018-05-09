using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1_LogischCircuit.Models.Nodes
{
    class NotNode : Node
    {
        public override string GetTypeName()
        {
            return "NOT";
        }
    }
}
