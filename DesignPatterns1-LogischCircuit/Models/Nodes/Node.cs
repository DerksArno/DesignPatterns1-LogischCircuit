using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1_LogischCircuit.Models.Nodes
{
    public abstract class Node
    {
        public String _name;
        public Boolean _output;
        private Dictionary<Node, bool> _inputs;
        private List<Node> _previousNodes;
        private List<Node> _nextNodes;

        public void PreviousNodeValue()
        {
            throw new NotImplementedException();
        }

        public void CalculateOutput()
        {
            throw new NotImplementedException();
        }

        public void AddToInput()
        {
            throw new NotImplementedException();
        }

        // Used for registering node objects
        public abstract string GetTypeName();
    }
}
