using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PetCargoProgram.DataAccess;
using PetCargoProgram.Models.CargoTables;
using PetCargoProgram.Models.Tanks;
using PetCargoProgram.Services.CargoTables;
using PetCargoProgram.Services.LoadingCondition;

namespace PetCargoProgram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Event_LoseFocusOnEnter(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                if (sender is TextBox) ((TextBox)sender).MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }
        }
    }
}
