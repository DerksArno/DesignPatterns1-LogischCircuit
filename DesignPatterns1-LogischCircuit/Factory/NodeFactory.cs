using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns1_LogischCircuit.Models.Nodes;

namespace DesignPatterns1_LogischCircuit.Factory
{
    public class NodeFactory
    {
        private Dictionary<string, Type> _types = CreateTypeMap();

        private static Dictionary<string, Type> CreateTypeMap()
        {
            Dictionary<string, Type> typeMap =
                new Dictionary<string, Type>();

            Assembly currAssembly = Assembly.GetExecutingAssembly();

            Type baseType = typeof(Node);

            foreach (Type type in currAssembly.GetTypes())
            {
                if (!type.IsClass || type.IsAbstract ||
                    !type.IsSubclassOf(baseType))
                {
                    continue;
                }

                Node derivedObject =
                    System.Activator.CreateInstance(type) as Node;
                if (derivedObject != null)
                {
                    typeMap.Add(
                        derivedObject.GetTypeName(),
                        derivedObject.GetType()
                    );
                }
            }
            return typeMap;
        }

        public Node CreateNode(string type, string name)
        {
            Type t = _types[type];
            Node node = (Node)Activator.CreateInstance(t);
            node._name = name;
            return node;
        }
    }
}
