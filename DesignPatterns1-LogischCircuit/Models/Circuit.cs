using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DesignPatterns1_LogischCircuit.Factory;

namespace DesignPatterns1_LogischCircuit.Models
{
    public class Circuit
    {
        private Boolean _setOutputs = false;
        private NodeFactory _nodeFactory = new NodeFactory();

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
                    createNode(c);
                }
                else
                {
                    setOutput(c);
                }
                Debug.WriteLine(c);
            }
        }

        private void createNode(String nodeText)
        {
            Debug.WriteLine(_nodeFactory.CreateNode(nodeText));
        }

        private void setOutput(String outputText)
        {

        }
    }
}
