using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1_LogischCircuit.Models.Nodes.Sources
{
    class LowSource : Source
    {
        protected bool _defaultOutput = false;

        public override void CalculateOutput()
        {
            _output = _defaultOutput;
        }

        public override string GetTypeName()
        {
            return "INPUT_LOW";
        }
    }
}
