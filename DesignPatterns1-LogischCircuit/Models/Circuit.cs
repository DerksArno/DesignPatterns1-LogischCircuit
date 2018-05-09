using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DesignPatterns1_LogischCircuit.Factory;
using DesignPatterns1_LogischCircuit.Models.Nodes;
using DesignPatterns1_LogischCircuit.Models;
using System.Text.RegularExpressions;

namespace DesignPatterns1_LogischCircuit.Models
{
    public class Circuit
    {
        private Boolean _setOutputs = false;

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
                }

                if (!_setOutputs)
                {
                    CreateNode(c);
                }
                else
                {
                    SetOutput(c);
                }
            }
        }

        private void CreateNode(String nodeText)
        {
            String nodeName = TrimText(nodeText, ':');
            String nodeType = FindType(nodeText);
            Node c = NodeFactory.CreateNode(nodeType, nodeName);
        }

        private void SetOutput(String outputText)
        {
            //Debug.WriteLine("output" + _nodeFactory.CreateNode(outputText));
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
            string pattern = @"[\w\d]+:[\s]+([\w]+);";
            MatchCollection matches = Regex.Matches(text, pattern);
            return matches[0].Groups[1].Value;
        }

        public void StartSimulation()
        {

        }
        
    }
}
