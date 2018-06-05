using System;
using System.Collections.Generic;
using DesignPatterns1_LogischCircuit.Models.Nodes;
using DesignPatterns1_LogischCircuit.Models.Nodes.Sources;

namespace DesignPatterns1_LogischCircuit.Models
{
    public class Circuit : ICircuit
    {
        private List<Node> _nodes;
        private List<Source> _sourceNodes;

        public Circuit(List<Node> nodes, List<Source> sources)
        {
            _nodes = nodes;
            _sourceNodes = sources;
        }

        public List<Source> GetSourceNodes()
        {
            return _sourceNodes;
        }
        
        public List<Node> GetNodes()
        {
            return _nodes;
        }

        public void StartSimulation()
        {
            foreach (Source sourceNode in _sourceNodes)
            {
                sourceNode.Start();
            }
        }

        public void Accept(IVisitor visitor)
        {
            foreach (Node node in this._nodes)
            {
                node.Accept(visitor);
            }
        }

    }
}
