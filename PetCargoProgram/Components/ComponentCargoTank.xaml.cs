using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using PetCargoProgram.Models.Tanks;

namespace PetCargoProgram.Components
{
    /// <summary>
    /// Логика взаимодействия для CargoTank.xaml
    /// </summary>
    public partial class ViewCargoTank : UserControl
    {
        // Ullage
        public static readonly DependencyProperty UllageProperty =
            DependencyProperty.Register(nameof(Ullage), typeof(double), typeof(ViewCargoTank));
        public double Ullage
        {
            get => (double)GetValue(UllageProperty);
            set => SetValue(UllageProperty, value);
        }
        // Temperature
        public static readonly DependencyProperty TemperatureProperty =
            DependencyProperty.Register(nameof(Temperature), typeof(double), typeof(ViewCargoTank));
        public double Temperature
        {
            get => (double)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }
        // Percents
        public static readonly DependencyProperty PercentsProperty =
            DependencyProperty.Register(nameof(Percents), typeof(double), typeof(ViewCargoTank));
        public double Percents
        {
            get => (double)GetValue(PercentsProperty);
            set => SetValue(PercentsProperty, value);
        }
        // Volume
        public static readonly DependencyProperty VolumeProperty =
            DependencyProperty.Register(nameof(Volume), typeof(double), typeof(ViewCargoTank));
        public double Volume
        {
            get => (double)GetValue(VolumeProperty);
            set => SetValue(VolumeProperty, value);
        }
        // Weight
        public static readonly DependencyProperty WeightProperty =
            DependencyProperty.Register(nameof(Weight), typeof(double), typeof(ViewCargoTank));
        public double Weight
        {
            get => (double)GetValue(WeightProperty);
            set => SetValue(WeightProperty, value);
        }
        // CargoTankName
        public static readonly DependencyProperty CargoTankNameProperty =
            DependencyProperty.Register(nameof(CargoTankName), typeof(string), typeof(ViewCargoTank));
        public string CargoTankName
        {
            get => (string)GetValue(CargoTankNameProperty);
            set => SetValue(CargoTankNameProperty, value);
        }
        // StatusValve
        public static readonly DependencyProperty StatusValveProperty =
            DependencyProperty.Register(nameof(StatusValve), typeof(bool), typeof(ViewCargoTank));
        private bool _statusValve = true;

        public bool StatusValve
        {
            get => (bool)GetValue(StatusValveProperty);
            set
            {
                SetValue(StatusValveProperty, value);
                if (value == true)
                {
                    Output_ValveStatus.Content = "open";
                    Input_ValveButtonStatus.Background = Brushes.LightGreen;
                    IO_SliderVolume.IsEnabled = true;
                    Input_Output_Ullage.IsEnabled = true;
                    Input_Output_Temperature.IsEnabled = true;
                    Input_Output_Volume.IsEnabled = true;
                    Input_Output_Weight.IsEnabled = true;
                    Input_Output_Percents.IsEnabled = true;
                }
                else
                {
                    Output_ValveStatus.Content = "closed";
                    Input_ValveButtonStatus.Background = Brushes.LightCoral;
                    IO_SliderVolume.IsEnabled = false;
                    Input_Output_Ullage.IsEnabled = false;
                    Input_Output_Temperature.IsEnabled = false;
                    Input_Output_Volume.IsEnabled = false;
                    Input_Output_Weight.IsEnabled = false;
                    Input_Output_Percents.IsEnabled = false;
                }
            }
        }
        public ViewCargoTank()
        {
            InitializeComponent();
            Loaded += (_, _) =>
            {
                StatusValve = true;
                // CargoTank = new CargoTank((string)CargoTankName);
            };
        }
        public void Clear() => GroupBoxTank.Header = string.Empty;

        private void Event_ButtonValveClick(object sender, System.Windows.RoutedEventArgs e)
        {
            StatusValve = !StatusValve;
        }

        private void Event_LoseFocusOnEnter(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                if (sender is TextBox) ((TextBox)sender).MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }
        }

        private void Event_SelectWhenEntered(object sender, System.Windows.RoutedEventArgs e)
        {
            if (sender is TextBox) ((TextBox)sender).SelectAll();
        }

        private void Event_SelectWhenClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is TextBox) ((TextBox)sender).SelectAll();
        }

        private void Event_SelectWhenKeyboardEnter(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (sender is TextBox) ((TextBox)sender).SelectAll();
        }

    }
}
