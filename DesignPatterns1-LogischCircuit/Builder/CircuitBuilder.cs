using System.Collections.Generic;
using DesignPatterns1_LogischCircuit.Factory;
using DesignPatterns1_LogischCircuit.Models;
using DesignPatterns1_LogischCircuit.Models.Nodes;
using DesignPatterns1_LogischCircuit.Models.Nodes.Sources;
using System;

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

            Circuit newCircuit = new Circuit(nodes, _sourceNodes);

            // Check if the circuit is valid.
            if (!IsValidCircuit(newCircuit))
            {
                return null;
            }

            return newCircuit;
        }

        private static Node CreateNode(string nodeType, string nodeName)
        {
            Node node = NodeFactory.CreateNode(nodeType, nodeName);
            
            if (node is Source)
            {
                _sourceNodes.Add((Source)node);
            }
            return node;
        }

        private static Node SetOutput(KeyValuePair<string, string[]> entry, List<Node> nodes)
        {
            Node node = nodes.Find(k => k.Name == entry.Key);

            if (node == null)
            {
                return node;
            }

            foreach (string entryValue in entry.Value)
            {
                node.NextNodes.Add(nodes.Find(k => k.Name == entryValue));
            }
            
            return node;
        }

        private static void SetInput(Node selectedNode, List<Node> nodes)
        {
            foreach (Node node in nodes)
            {
                if (node.NextNodes.Contains(selectedNode))
                {
                    node.Subscribe(selectedNode);
                    selectedNode.PreviousNodes.Add(node);
                }
            }
        }

        private static bool IsValidCircuit(Circuit circuit)
        {
            foreach (Node node in circuit.GetNodes())
            {
                if (node.NextNodes.Count == 0 && node.GetTypeName() != "PROBE" && node is Source == false)
                {
                    return false;
                }

                if (!RecursiveLoop(node, node))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool RecursiveLoop(Node node, Node nodeToCheck)
        {
            foreach (Node n in node.NextNodes)
            {
                if (n == nodeToCheck || n.Name == nodeToCheck.Name)
                {
                    return false;
                }

                foreach (Node nextNode in n.NextNodes)
                {
                    return RecursiveLoop(nextNode, nodeToCheck);
                }
            }
            return true;
        }
    }
}
