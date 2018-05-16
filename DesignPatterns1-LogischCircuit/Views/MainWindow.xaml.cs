using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesignPatterns1_LogischCircuit.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            /* Example code how to insert new elements into the view
            for (int i = 0; i < 5; i++)
            {
                System.Windows.Controls.Button newBtn = new Button();

                newBtn.Content = i.ToString();
                newBtn.Name = "Button" + i.ToString();

                this.Grid.Children.Add(newBtn);
            }
            */
        }

        /*public AddInputs()
        {
            System.Windows.Controls.Check checkbox = new CheckBox();

            newBtn.Content = i.ToString();
            newBtn.Name = "Button" + i.ToString();
            this.checkBoxHolder.Children.Add()
        }*/
    }
}
