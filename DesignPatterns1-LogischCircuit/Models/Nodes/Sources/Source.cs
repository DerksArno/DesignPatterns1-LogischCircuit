using System;

namespace DesignPatterns1_LogischCircuit.Models.Nodes.Sources
{
    public abstract class Source : Node
    {
        private bool _defaultOutput;
        
        public void Start()
        {
            CalculateOutput();
        }

        public void SwitchOutput()
        {
            _defaultOutput = !_defaultOutput;
        }
    }
}
