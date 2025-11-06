using System;
using System.Windows;
using System.Windows.Input;
using PetCargoProgram.Windows;

namespace PetCargoProgram;

public partial class MainWindow
{
    public ICommand CommandOpenASTMWindow { get;}
    private bool _isOpendASTMWindow;


    private void OpenASTMWindow(object? parameter = null)
    {
        if (_isOpendASTMWindow)
        {
            MessageBox.Show("Окно уже открыто!");
            return;
        }

        var astmWindow = new ASTMWindow();
        // MessageBox.Show("Открываю ASTM!");
        astmWindow.Closed += (s, args) => _isOpendASTMWindow = false;
        astmWindow.Show();
        _isOpendASTMWindow = true;
    }

    private bool CanOpenASTMWindow(object? paramete = null)
    {
        return true;
    }


}
