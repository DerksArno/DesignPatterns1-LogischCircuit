using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesignPatterns1_LogischCircuit;
using DesignPatterns1_LogischCircuit.Models.Nodes;
using DesignPatterns1_LogischCircuit.Models.Nodes.Sources;
using DesignPatterns1_LogischCircuit.Models;
using DesignPatterns1_LogischCircuit.Factory;
using System.Collections.Generic;

namespace UnitTestProject.NodeTest
{
    [TestClass]
    public class AndNodeTest
    {
        private Source high1;
        private Source high2;
        private Source low1;
        private Source low2;

        private Node output;
        private Node andNode;

        [TestInitialize]
        public void TestInitialize()
        {
            high1 = (Source)NodeFactory.CreateNode("INPUT_HIGH", "A");
            high2 = (Source)NodeFactory.CreateNode("INPUT_HIGH", "B");
            low1 = (Source)NodeFactory.CreateNode("INPUT_HIGH", "C");
            low2 = (Source)NodeFactory.CreateNode("INPUT_HIGH", "D");
            output = NodeFactory.CreateNode("PROBE", "OUT");
            andNode = NodeFactory.CreateNode("AND", "AND");

            high1.NextNodes = new List<Node>() { andNode };
            high2.NextNodes = new List<Node>() { andNode };
            low1.NextNodes = new List<Node>() { andNode };
            low2.NextNodes = new List<Node>() { andNode };

            andNode.NextNodes = new List<Node>() { output };

            andNode.Subscribe(high1);
            andNode.Subscribe(high2);
            andNode.Subscribe(low1);
            andNode.Subscribe(low2);

            output.Subscribe(andNode);

        }

        [TestMethod]
        public void AndNode_Execute_TwoLow()
        {
            high1.Start();
            high2.Start();
            low1.Start();
            low2.Start();

            bool actual = output.Output;
            bool expected = true;
            // Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
