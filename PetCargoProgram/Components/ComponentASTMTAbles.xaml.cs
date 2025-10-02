using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ViewModel.ASTM;

namespace PetCargoProgram.Components;

public partial class ViewASTMTAbles : UserControl
{
    public ViewASTMTAbles()
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

