using System.Collections.Generic;
using DesignPatterns1_LogischCircuit.Factory;
using DesignPatterns1_LogischCircuit.Models;
using DesignPatterns1_LogischCircuit.Models.Nodes;
using DesignPatterns1_LogischCircuit.Models.Nodes.Sources;

namespace DesignPatterns1_LogischCircuit.Builder
{
    public static class CircuitBuilder
    {
        private static List<Source> _sourceNodes;

        public static Circuit CreateCircuit(string fileId)
        {
            Dictionary<string, string[]>[] file = Utility.FileReader.ReadFile(fileId);

            Dictionary<string, string[]> nodesFile = file[0];
            Dictionary<string, string[]> outputsFile = file[1];

            List<Node> nodes = new List<Node>();
            _sourceNodes = new List<Source>();

            foreach (KeyValuePair<string, string[]> entry in nodesFile)
            {
                foreach (string entryValue in entry.Value)
                {
                    Node c = CreateNode(entryValue, entry.Key);
                    nodes.Add(c);
                }
            }

            foreach (KeyValuePair<string, string[]> entry in outputsFile)
            {
                SetOutput(entry, nodes);
            }

            foreach (Node node in nodes)
            {
                SetInput(node, nodes);
            }

            return new Circuit(nodes, _sourceNodes);
        }

        private static Node CreateNode(string nodeType, string nodeName)
        {
            Node node = NodeFactory.CreateNode(nodeType, nodeName);

            // TODO Implement better way to get the Source nodes?
            if (nodeType == "INPUT_HIGH" || nodeType == "INPUT_LOW")
            {
                _sourceNodes.Add((Source)node);
            }
            return node;
        }

        private static Node SetOutput(KeyValuePair<string, string[]> entry, List<Node> nodes)
        {
            Node node = nodes.Find(k => k._name == entry.Key);

            if (node == null)
            {
                return node;
            }

            foreach (string entryValue in entry.Value)
            {
                node._nextNodes.Add(nodes.Find(k => k._name == entryValue));
            }
            
            return node;
        }

        private static void SetInput(Node selectedNode, List<Node> nodes)
        {
            foreach (Node node in nodes)
            {
                if (node._nextNodes.Contains(selectedNode))
                {
                    node.Subscribe(selectedNode);
                    selectedNode._previousNodes.Add(node);
                }
            }
        }

    }
}
