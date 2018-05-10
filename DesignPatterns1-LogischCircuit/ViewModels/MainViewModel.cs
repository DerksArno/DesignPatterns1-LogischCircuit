using GalaSoft.MvvmLight;
using System.Diagnostics;
using System.Windows.Controls;
using DesignPatterns1_LogischCircuit.Builder;
using DesignPatterns1_LogischCircuit.Models;
using System.Collections.ObjectModel;

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

        public MainViewModel()
        {
            Circuits = new ObservableCollection<string>() { "test" };
            // TODO selectCircuit en startSimulation werkend maken
            SelectCircuit();
            StartSimulation();
        }

        private void SelectCircuit()
        {
            _circuit = CircuitBuilder.CreateCircuit(1);
        }

        private void StartSimulation()
        {
            _circuit.StartSimulation();
        }
    }
}