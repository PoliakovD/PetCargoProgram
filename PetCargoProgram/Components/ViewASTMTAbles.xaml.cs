using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ViewModel.ASTM;

namespace PetCargoProgram.Components;

public partial class ViewASTMTAbles : UserControl
{
    // // Density15
    // public static readonly DependencyProperty Density15Property =
    //     DependencyProperty.Register(nameof(Density15), typeof(double), typeof(ViewASTMTAbles));
    // public double Density15
    // {
    //     get => (double)GetValue(Density15Property);
    //     set => SetValue(Density15Property, value);
    // }
    //
    // // Density60
    // public static readonly DependencyProperty Density60Property =
    //     DependencyProperty.Register(nameof(Density60), typeof(double), typeof(ViewASTMTAbles));
    // public double Density60
    // {
    //     get => (double)GetValue(Density60Property);
    //     set => SetValue(Density60Property, value);
    // }
    // // API
    // public static readonly DependencyProperty APIProperty =
    //     DependencyProperty.Register(nameof(API), typeof(double), typeof(ViewASTMTAbles));
    // public double API
    // {
    //     get => (double)GetValue(APIProperty);
    //     set => SetValue(APIProperty, value);
    // }
    // // CurrentTemperature
    // public static readonly DependencyProperty CurrentTemperatureProperty =
    //     DependencyProperty.Register(nameof(CurrentTemperature), typeof(double), typeof(ViewASTMTAbles));
    // public double CurrentTemperature
    // {
    //     get => (double)GetValue(CurrentTemperatureProperty);
    //     set => SetValue(CurrentTemperatureProperty, value);
    // }
    // // VolumeCorrection
    // public static readonly DependencyProperty DVolumeCorrectionProperty =
    //     DependencyProperty.Register(nameof(VolumeCorrection), typeof(double), typeof(ViewASTMTAbles));
    // public double VolumeCorrection
    // {
    //     get => (double)GetValue(DVolumeCorrectionProperty);
    //     set => SetValue(DVolumeCorrectionProperty, value);
    // }
    // // WeightVacToAir
    // public static readonly DependencyProperty WeightVacToAirProperty =
    //     DependencyProperty.Register(nameof(WeightVacToAir), typeof(double), typeof(ViewASTMTAbles));
    // public double WeightVacToAir
    // {
    //     get => (double)GetValue(WeightVacToAirProperty);
    //     set => SetValue(WeightVacToAirProperty, value);
    // }
    // // WeightAirToVac
    // public static readonly DependencyProperty WeightAirToVacProperty =
    //     DependencyProperty.Register(nameof(WeightAirToVac), typeof(double), typeof(ViewASTMTAbles));
    // public double WeightAirToVac
    // {
    //     get => (double)GetValue(WeightAirToVacProperty);
    //     set => SetValue(WeightAirToVacProperty, value);
    // }
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

