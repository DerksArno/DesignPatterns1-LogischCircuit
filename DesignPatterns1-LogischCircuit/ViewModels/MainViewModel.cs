using GalaSoft.MvvmLight;
using DesignPatterns1_LogischCircuit.Builder;
using DesignPatterns1_LogischCircuit.Models;
using System.Collections.ObjectModel;
using DesignPatterns1_LogischCircuit.Utility;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;

namespace DesignPatterns1_LogischCircuit.ViewModels
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        public Circuit _circuit;
        public ObservableCollection<string> Circuits { get; set; }
        public string SelectedCircuit { get; set; }

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
        // TODO Feedback verwerken
        // Filereader moet 2 lists returnen die de circuitbuilder kan gebruiken -                       Done, kan miss nog iets beter?
        // De circuitbuilder echt zelf het circuit maken en niet het circuit zelf                       Done
        // source nodes kunnen weg, kan er 1 worden, wel opletten met value zetten                      
        // FileReader is geen Utility...

        public MainViewModel()
        {
            Circuits = new ObservableCollection<string>(FileReader.GetFileNames());
            SelectedCircuit = Circuits[0];
        }

        private void StartSimulation()
        {
            _circuit = CircuitBuilder.CreateCircuit(SelectedCircuit);
            _circuit.StartSimulation();
        }

    }
}