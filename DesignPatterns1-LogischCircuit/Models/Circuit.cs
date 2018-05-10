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
        private Boolean _setOutputs = false;
        private List<Node> _nodes = new List<Node>();
        private List<Source> _sourceNodes = new List<Source>();

        public Circuit(String[] file)
        {
            foreach (string c in file)
            {
                if (c.Length > 0 && c.First() == '#')
                {
                    continue;
                }
                if (c.Length == 0)
                {
                    _setOutputs = true;
                    continue;
                }

                if (!_setOutputs)
                {
                    CreateNode(c);
                }
                else
                {
                    Node node = SetOutput(c);
                }
            }

            foreach (Node node in _nodes)
            {
                SetInput(node);
            }
        }

        private void CreateNode(String nodeText)
        {
            String nodeName = TrimText(nodeText, ':');
            String nodeType = FindType(nodeText);
            Node c = NodeFactory.CreateNode(nodeType, nodeName);
            _nodes.Add(c);

            // TODO Implement better way to get the Source nodes?
            if (nodeType == "INPUT_HIGH" || nodeType == "INPUT_LOW")
            {
                _sourceNodes.Add((Source)c);
                //Debug.WriteLine(c._name);
            }
        }

        private Node SetOutput(String outputText)
        {
            String nodeName = TrimText(outputText, ':');
            String[] outputNames = FindTypes(outputText);
            Node node = _nodes.Find(k => k._name == nodeName);
            if (node != null)
            {
                foreach (String name in outputNames)
                {
                    node._nextNodes.Add(_nodes.Find(k => k._name == name));
                }
            }
            return node;
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

        private String TrimText(String text, Char TrimAtChar)
        {
            int index = text.IndexOf(TrimAtChar);
            if (index > 0)
            {
                return text.Substring(0, index);
            }
            return "";
        }

        private String FindType(String text)
        {
            string pattern = @"[\w\d]+:[\s]+([\w,]+);";
            MatchCollection matches = Regex.Matches(text, pattern);
            return matches[0].Groups[1].Value;
        }

        private String[] FindTypes(String text)
        {
            String[] types = FindType(text).Split(',');
            return types;
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
