using System;
using System.ComponentModel.Design;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PetCargoProgram.Commands;
using PetCargoProgram.Windows;


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
            _isOpendASTMWindow = false;
            CommandOpenASTMWindow = new LambdaCommand(
                execute: _ => OpenASTMWindow(),
                canExecute: _ => CanOpenASTMWindow());

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
