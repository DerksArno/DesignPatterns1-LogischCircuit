﻿using DesignPatterns1_LogischCircuit.Observable;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1_LogischCircuit.Models.Nodes
{
    public abstract class Node : Observable<Node>, IObserver<Node>
    {
        public String _name;
        protected bool _outputValue = false;
        protected Dictionary<Node, bool> _inputs = new Dictionary<Node, bool>();
        public ObservableCollection<Node> _previousNodes = new ObservableCollection<Node>();
        public List<Node> _nextNodes = new List<Node>();

        public bool _output {
            get { return _outputValue; }
            set
            {
                _outputValue = value;
                Notify(this);
            }
        }

        public void PreviousNodeValue(Node node, Boolean value)
        {
            AddToInput(node, value);
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

        // Used for registering node objects
        public abstract string GetTypeName();
        
        public void OnNext(Node value)
        {
            PreviousNodeValue(value, value._output);
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
