using GalaSoft.MvvmLight;
using System.Diagnostics;
using System.Windows.Controls;
using DesignPatterns1_LogischCircuit.Builder;
using DesignPatterns1_LogischCircuit.Models;

namespace DesignPatterns1_LogischCircuit.ViewModel
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
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            CircuitBuilder c = new CircuitBuilder();
            Circuit circuit = c.CreateCircuit(1);
        }
    }
}