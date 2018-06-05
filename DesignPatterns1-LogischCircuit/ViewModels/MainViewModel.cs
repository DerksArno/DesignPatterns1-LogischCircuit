using GalaSoft.MvvmLight;
using DesignPatterns1_LogischCircuit.Builder;
using DesignPatterns1_LogischCircuit.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.Generic;
using System;
using DesignPatterns1_LogischCircuit.Models.Nodes.Sources;
using System.Linq;
using System.ComponentModel;
using DesignPatterns1_LogischCircuit.Models.Nodes;

namespace DesignPatterns1_LogischCircuit.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        // TODO Composite pattern
        // Compononent = gewoon nodig voor het aanroepen van "proces"
        // Leaf = Node
        // Composite = Verzameling nodes / circuit

        public Circuit _circuit;
        public ObservableCollection<string> CircuitNames { get; set; }

        private string _selectedCircuit;
        public string SelectedCircuit {
            get { return _selectedCircuit; }
            set
            {
                _selectedCircuit = value;
                SelectCircuit();
            }
        }

        private ICommand _startCommand;
        public ICommand StartCommand
        {
            get
            {
                if (_startCommand == null)
                {
                    _startCommand = new RelayCommand(
                        () => StartSimulation()
                    );
                }
                return _startCommand;
            }
        }
        
        private ObservableCollection<Source> _sourceNodes;
        public ObservableCollection<Source> SourceNodes
        {
            get { return _sourceNodes; }
            set
            {
                _sourceNodes = value;
            }
        }

        private ObservableCollection<Node> _probeNodes;
        public ObservableCollection<Node> ProbeNodes
        {
            get { return _probeNodes; }
            set { _probeNodes = value; }
        }

        private ObservableCollection<Node> _nodes;
        public ObservableCollection<Node> Nodes
        {
            get { return _nodes; }
            set
            {
                _nodes = value;
            }
        }

        private ObservableCollection<string> _consoleOutput = new ObservableCollection<string>();

        public ObservableCollection<string> ConsoleOutput
        {
            get { return _consoleOutput; }
            set { _consoleOutput = value; }
        }

        public MainViewModel()
        {
            Nodes = new ObservableCollection<Node>();
            SourceNodes = new ObservableCollection<Source>();
            ProbeNodes = new ObservableCollection<Node>(_nodes.Where(n => n.TypeName == "PROBE").ToList());
            CircuitNames = new ObservableCollection<string>(Utility.FileReader.GetFileNames());

            if (CircuitNames.Count == 0)
            {
                ConsoleOutput.Add("No files found!");
                ConsoleOutput.Add("Add files to your Documents/circuits folder.");
                return;
            }

            SelectedCircuit = CircuitNames[0];
            ConsoleOutput.Add("Program is ready for use.");
        }

        private void SelectCircuit()
        {
            _circuit = CircuitBuilder.CreateCircuit(SelectedCircuit);

            if (_circuit == null)
            {
                ConsoleOutput.Add("Circuit is not valid.");
                return;
            }

            SourceNodes.Clear();
            foreach (Source source in _circuit.GetSourceNodes())
            {
                SourceNodes.Add(source);
            }
            Nodes.Clear();
            foreach (Node node in _circuit.GetNodes())
            {
                Nodes.Add(node);
            }
            ProbeNodes.Clear();
            foreach (Node node in _nodes.Where(n => n.TypeName == "PROBE").ToList())
            {
                ProbeNodes.Add(node);
            }
        }

        private void StartSimulation()
        {
            if (_circuit == null)
                return;

            ConsoleOutput.Add("Simulation started.");

            PropagationVisitor visitor = new PropagationVisitor();
            _circuit.Accept(visitor);
            
            _circuit.StartSimulation();
            ConsoleOutput.Add("Simulation ended.");

            ConsoleOutput.Add("The delay = " + visitor.Output);
        }

    }
}