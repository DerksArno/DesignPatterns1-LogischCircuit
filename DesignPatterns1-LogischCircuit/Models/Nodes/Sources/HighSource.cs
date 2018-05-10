using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1_LogischCircuit.Models.Nodes.Sources
{
    class HighSource : Source
    {
        private bool _defaultOutput = true;

        public override void CalculateOutput()
        {
            _output = _defaultOutput;
        }

        public override string GetTypeName()
        {
            return "INPUT_HIGH";
        }
    }
}
