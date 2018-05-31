using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DesignPatterns1_LogischCircuit.Observable;
using System.ComponentModel;

namespace DesignPatterns1_LogischCircuit.Models.Nodes
{
    public abstract class Node : Observable<Node>, INotifyPropertyChanged, IObserver<Node>
    {
        protected Dictionary<Node, bool> _inputs = new Dictionary<Node, bool>();
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<Node> _previousNodes = new ObservableCollection<Node>();

        public ObservableCollection<Node> PreviousNodes
        {
            get { return _previousNodes; }
            set { _previousNodes = value; }
        }

        public List<Node> _nextNodes = new List<Node>();

        public List<Node> NextNodes
        {
            get { return _nextNodes; }
            set { _nextNodes = value; }
        }

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
                NotifyPropertyChanged("Output");
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
