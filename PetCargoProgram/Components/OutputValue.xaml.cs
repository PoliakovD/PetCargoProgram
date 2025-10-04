using System.Windows;
using System.Windows.Controls;

namespace PetCargoProgram.Components;

public partial class OutputValue : UserControl
{
    // Title
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(nameof(Title), typeof(string), typeof(OutputValue));
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    // Value
    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register(nameof(Value), typeof(string), typeof(OutputValue));
    public string Value
    {
        get => (string)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }


    public OutputValue()
    {
        InitializeComponent();
    }
}

