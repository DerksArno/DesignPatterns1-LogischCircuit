using DesignPatterns1_LogischCircuit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1_LogischCircuit.Builder
{
    class CircuitBuilder
    {
        public Circuit CreateCircuit(int fileId)
        {
            return new Circuit(Utility.FileReader.ReadFile(fileId));
        }
    }
}
