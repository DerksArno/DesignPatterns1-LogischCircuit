using DesignPatterns1_LogischCircuit.Models.Nodes;
using DesignPatterns1_LogischCircuit.Models.Nodes.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1_LogischCircuit.Models
{
    public interface ICircuit
    {
        List<Source> GetSourceNodes();

        List<Node> GetNodes();

        void StartSimulation();
    }
}
