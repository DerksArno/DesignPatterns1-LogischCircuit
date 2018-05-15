using DesignPatterns1_LogischCircuit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1_LogischCircuit.Builder
{
    public static class CircuitBuilder
    {
        public static Circuit CreateCircuit(int fileId)
        {
            return new Circuit(Utility.FileReader.ReadFile(fileId));

            /*
            foreach (Node node in _nodes)
            {
                SetInput(node);
            }
            */

            /* 
            Node c = NodeFactory.CreateNode(nodeType, nodeName);
            _nodes.Add(c);

            // TODO Implement better way to get the Source nodes?
            if (nodeType == "INPUT_HIGH" || nodeType == "INPUT_LOW")
            {
                _sourceNodes.Add((Source)c);
                //Debug.WriteLine(c._name);
            }*/

            /*
            private static Node SetOutput(String outputText)
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
            }*/
            }

        }

}
