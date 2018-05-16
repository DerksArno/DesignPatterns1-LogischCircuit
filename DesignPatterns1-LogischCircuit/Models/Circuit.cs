using System;
using System.Collections.Generic;
using DesignPatterns1_LogischCircuit.Models.Nodes;
using DesignPatterns1_LogischCircuit.Models.Nodes.Sources;

namespace DesignPatterns1_LogischCircuit.Models
{
    public class Circuit
    {
        private List<Node> _nodes;
        private List<Source> _sourceNodes;

        public Circuit(List<Node> nodes, List<Source> sources)
        {
            _nodes = nodes;
            _sourceNodes = sources;
        }
        
        public void StartSimulation()
        {
            foreach (Source sourceNode in _sourceNodes)
            {
                sourceNode.Start();
            }
            Console.WriteLine('a');
        }
        
    }
}
