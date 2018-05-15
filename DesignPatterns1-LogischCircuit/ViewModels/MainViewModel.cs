using GalaSoft.MvvmLight;
using System.Diagnostics;
using System.Windows.Controls;
using DesignPatterns1_LogischCircuit.Builder;
using DesignPatterns1_LogischCircuit.Models;
using System.Collections.ObjectModel;
using DesignPatterns1_LogischCircuit.Utility;

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
        Circuit _circuit;
        public ObservableCollection<string> Circuits { get; set; }
        public string SelectedCircuit;

        // TODO Feedback verwerken
        // Filereader moet 2 lists returnen die de circuitbuilder kan gebruiken
        // De circuitbuilder echt zelf het circuit maken en niet het circuit zelf
        // source nodes kunnen weg, kan er 1 worden, wel opletten met value zetten
        // FileReader is geen Utility...

        // TODO filereader files laten uitlezen zodat de bestandsnamen niet aangepast hoeven te worden.

        public MainViewModel()
        {
            Circuits = new ObservableCollection<string>() { "test" };
            // TODO selectCircuit en startSimulation werkend maken
            SelectCircuit();
            StartSimulation();
        }

        private void SelectCircuit()
        {
            string[] files = FileReader.GetFileNames();
            _circuit = CircuitBuilder.CreateCircuit(files[0]);
        }

        private void StartSimulation()
        {
            _circuit.StartSimulation();
        }
    }
}