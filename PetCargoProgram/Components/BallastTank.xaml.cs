using System.Windows.Controls;
using System.Windows.Media;

namespace PetCargoProgram.Components
{
    /// <summary>
    /// Логика взаимодействия для BallastTank.xaml
    /// </summary>
    public partial class BallastTank : UserControl
    {
        double _percents;                       // Процент заполнения танка
        bool _statusValve = true;                      // Статус клапана
        double _volume;                         // Заполненный объем танка
        double _LCG;                            // Координата центра тяжести X
        double _TCG;                            // Координата центра тяжести Y
        double _VCG;                            // Координата центра тяжести Z
        double _IY;                             // Площадь свободной поверхности
        //Table_Volume _Table_Volume;   // Таблица объемов и координат центра тяжести
        public string BallastTankName { get; set; }

        // Реализация функционала доступа к клапану
        // Аксессор:
        public bool StatusValve
        {
            get
            {
                return _statusValve;
            }
            set
            {
                _statusValve = value;
                if (value == true)
                {
                    Output_ValveStatus.Content = "open";
                    Input_ValveButtonStatus.Background = Brushes.LightGreen;
                    IO_SliderVolume.IsEnabled = true;
                    Input_Output_Volume.IsEnabled = true;
                    Input_Output_Weight.IsEnabled = true;
                    Input_Output_Sound.IsEnabled = true;
                }
                else
                {
                    Output_ValveStatus.Content = "closed";
                    Input_ValveButtonStatus.Background = Brushes.LightCoral;
                    IO_SliderVolume.IsEnabled = false;
                    Input_Output_Volume.IsEnabled = false;
                    Input_Output_Weight.IsEnabled = false;
                    Input_Output_Sound.IsEnabled = false;
                }
            }
        }
        public BallastTank()
        {
            InitializeComponent();
            Loaded += (_, _) =>
            {
                GroupBoxTank.Header = BallastTankName;
                Output_ValveStatus.Content = "opened";
            };
            double _percents = 0.0;                     // Процент заполнения танка
            bool _statusValve = true;                   // Статус клапана
            double _volume = 0.0;                       // Заполненный объем танка
            double _LCG = 0.0;                          // Координата центра тяжести X
            double _TCG = 0.0;                          // Координата центра тяжести Y
            double _VCG = 0.0;                          // Координата центра тяжести Z
            double _IY = 0.0;                           // Площадь свободной поверхности
        }
        public void Clear() => GroupBoxTank.Header = string.Empty;

        private void Event_ButtonValveClick(object sender, System.Windows.RoutedEventArgs e)
        {
            StatusValve = !StatusValve;
        }
    }
}
