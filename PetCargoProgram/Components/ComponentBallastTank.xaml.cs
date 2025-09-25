using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace PetCargoProgram.Components
{
    /// <summary>
    /// Логика взаимодействия для BallastTank.xaml
    /// </summary>
    public partial class ViewBallastTank : UserControl
    {
       // Sound
        public static readonly DependencyProperty SoundProperty =
            DependencyProperty.Register(nameof(Sound), typeof(double), typeof(ViewBallastTank));
        public double Sound
        {
            get => (double)GetValue(SoundProperty);
            set => SetValue(SoundProperty, value);
        }
        // Percents
        public static readonly DependencyProperty PercentsProperty =
            DependencyProperty.Register(nameof(Percents), typeof(double), typeof(ViewBallastTank));
        public double Percents
        {
            get => (double)GetValue(PercentsProperty);
            set => SetValue(PercentsProperty, value);
        }
        // Volume
        public static readonly DependencyProperty VolumeProperty =
            DependencyProperty.Register(nameof(Volume), typeof(double), typeof(ViewBallastTank));
        public double Volume
        {
            get => (double)GetValue(VolumeProperty);
            set => SetValue(VolumeProperty, value);
        }
        // Weight
        public static readonly DependencyProperty WeightProperty =
            DependencyProperty.Register(nameof(Weight), typeof(double), typeof(ViewBallastTank));
        public double Weight
        {
            get => (double)GetValue(WeightProperty);
            set => SetValue(WeightProperty, value);
        }
        // BallastTankName
        public static readonly DependencyProperty BallastTankNameProperty =
            DependencyProperty.Register(nameof(BallastTankName), typeof(string), typeof(ViewBallastTank));
        public string BallastTankName
        {
            get => (string)GetValue(BallastTankNameProperty);
            set => SetValue(BallastTankNameProperty, value);
        }
        // StatusValve
        public static readonly DependencyProperty StatusValveProperty =
            DependencyProperty.Register(nameof(StatusValve), typeof(bool), typeof(ViewBallastTank));
        private bool _statusValve = true;

        public bool StatusValve
        {
            get => (bool)GetValue(StatusValveProperty);
            set
            {
                SetValue(StatusValveProperty, value);
                if (value == true)
                {
                    Output_ValveStatus.Content = "opened";
                    Input_ValveButtonStatus.Background = Brushes.LightGreen;
                    IO_SliderVolume.IsEnabled = true;
                    Input_Output_Sound.IsEnabled = true;
                    Input_Output_Volume.IsEnabled = true;
                    Input_Output_Weight.IsEnabled = true;
                }
                else
                {
                    Output_ValveStatus.Content = "closed";
                    Input_ValveButtonStatus.Background = Brushes.LightCoral;
                    IO_SliderVolume.IsEnabled = false;
                    Input_Output_Sound.IsEnabled = false;
                    Input_Output_Volume.IsEnabled = false;
                    Input_Output_Weight.IsEnabled = false;
                }
            }
        }
        public ViewBallastTank()
        {
            InitializeComponent();
            Loaded += (_, _) =>
            {
                StatusValve = true;
            };

        }


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
