using System.Windows;

namespace PetCargoProgram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CargoTables.CargoTables? Tables { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Tables = CargoTables.CargoTables.Load();
            //Tables = new CargoTables.CargoTables();
            //Tables.Save();
            Load_LoadingCondition();
        }
        private void Load_LoadingCondition()
        {
            var Table = Tables.Tables_Hydrostatic[0];
            DataGrid_LoadingCondion.ItemsSource = Table.Table;
        }
    }
}
