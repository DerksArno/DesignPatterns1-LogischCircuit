using System;

namespace DesignPatterns1_LogischCircuit.Models.Nodes.Sources
{
    public abstract class Source : Node
    {   
        public void Start()
        {
            CalculateOutput();
        }

        public override void CalculateOutput()
        {
            Output = _output;
        }

        public void SwitchOutput()
        {
            Output = !Output;
        }
    }
}
