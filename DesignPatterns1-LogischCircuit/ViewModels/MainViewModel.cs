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
        // TODO Feedback verwerken
        // Filereader moet 2 lists returnen die de circuitbuilder kan gebruiken -                       Done, kan miss nog iets beter?
        // De circuitbuilder echt zelf het circuit maken en niet het circuit zelf                       Done
        // source nodes kunnen weg, kan er 1 worden, wel opletten met value zetten (idk of dat nodig is)
        // FileReader is geen Utility... (maar wat dan wel :O)
        // TODO show the circuit on the view

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

        private List<string> _consoleOutput = new List<string>();

        public List<string> ConsoleOutput
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
            SelectedCircuit = CircuitNames[0];
            ConsoleOutput.Add("Circuit ready for use");
        }

        private void SelectCircuit()
        {
            _circuit = CircuitBuilder.CreateCircuit(SelectedCircuit);
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
            _circuit.StartSimulation();
        }

    }
}