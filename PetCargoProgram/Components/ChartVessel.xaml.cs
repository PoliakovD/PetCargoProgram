using System.Windows;
using System.Windows.Controls;

namespace PetCargoProgram.Components;

public partial class ChartVessel : UserControl
{
    public static readonly DependencyProperty AngleProperty =
        DependencyProperty.Register(nameof(Angle), typeof(double), typeof(ChartVessel));
    public double Angle
    {
        get => (double)GetValue(AngleProperty);
        set
        {
            SetValue(AngleProperty, value);
        }
    }

    public static readonly DependencyProperty DraftProperty =
        DependencyProperty.Register(nameof(Draft), typeof(double), typeof(ChartVessel));
    public double Draft
    {
        get => (double)GetValue(DraftProperty);
        set
        {
            SetValue(DraftProperty, value);
        }
    }
    public ChartVessel()
    {
        InitializeComponent();
    }
}

