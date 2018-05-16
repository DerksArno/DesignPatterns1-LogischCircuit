﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DesignPatterns1_LogischCircuit.Observable;

namespace DesignPatterns1_LogischCircuit.Models.Nodes
{
    public abstract class Node : Observable<Node>, IObserver<Node>
    {
        protected Dictionary<Node, bool> _inputs = new Dictionary<Node, bool>();
        public ObservableCollection<Node> _previousNodes = new ObservableCollection<Node>();
        public List<Node> _nextNodes = new List<Node>();

        protected String _name;
        public String Name {
            get { return _name; }
            set { _name = value; }
        }
        protected bool _output = false;
        public bool Output {
            get { return _output; }
            set
            {
                _output = value;
                Notify(this);
            }
        }

        public void PreviousNodeValue(Node node)
        {
            AddToInput(node, node.Output);
            if (_inputs.Count == _previousNodes.Count)
            {
                CalculateOutput();
            }
        }

        public abstract void CalculateOutput();

        private void AddToInput(Node node, Boolean value)
        {
            if (_inputs.ContainsKey(node))
            {
                _inputs[node] = value;
            }
            else
            {
                _inputs.Add(node, value);
            }
        }
                
        public abstract string GetTypeName();

        public void OnNext(Node node)
        {
            PreviousNodeValue(node);
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }
    }
}
