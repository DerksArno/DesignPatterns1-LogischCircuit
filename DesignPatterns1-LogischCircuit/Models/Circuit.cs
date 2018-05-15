using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DesignPatterns1_LogischCircuit.Factory;
using System.Text.RegularExpressions;
using DesignPatterns1_LogischCircuit.Models.Nodes;
using DesignPatterns1_LogischCircuit.Models.Nodes.Sources;

namespace DesignPatterns1_LogischCircuit.Models
{
    public class Circuit
    {
        
        private List<Node> _nodes = new List<Node>();
        private List<Source> _sourceNodes = new List<Source>();

        public Circuit(String[] file)
        {
            
        }

        

        

        private void SetInput(Node selectedNode)
        {
            foreach (Node node in _nodes)
            {
                if (node._nextNodes.Contains(selectedNode))
                {
                    node.Subscribe(selectedNode);
                    selectedNode._previousNodes.Add(node);
                }
            }
        }
        
        public void StartSimulation()
        {
            foreach (Source sourceNode in _sourceNodes)
            {
                sourceNode.Start();
            }
        }
        
    }
}
