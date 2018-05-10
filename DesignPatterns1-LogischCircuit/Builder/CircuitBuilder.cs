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
        }
    }
}
