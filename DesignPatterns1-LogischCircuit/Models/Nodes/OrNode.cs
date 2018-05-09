using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1_LogischCircuit.Models.Nodes
{
    public class OrNode : Node
    {
        public override string GetTypeName()
        {
            return "OR";
        }
    }
}
