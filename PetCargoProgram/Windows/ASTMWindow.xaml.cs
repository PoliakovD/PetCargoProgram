using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PetCargoProgram.Windows;

public partial class ASTMWindow : Window
{
    public ASTMWindow()
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

