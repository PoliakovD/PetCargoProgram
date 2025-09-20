using System.Windows;
using PetCargoProgram.DataAccess;
using PetCargoProgram.Models.CargoTables;

namespace PetCargoProgram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AllCargoTables? _cargoTables;
        public MainWindow()
        {
            InitializeComponent();
            _cargoTables = new AllCargoTables();
            BinaryCTService.Load(ref _cargoTables);
            //Tables = new CargoTables.CargoTables();
            //Tables.Save();
            Load_LoadingCondition();
        }
        private void Load_LoadingCondition()
        {
            var Table = _cargoTables.TablesHydrostatic.Tables[0];
            DataGrid_LoadingCondion.ItemsSource = Table.Table;
        }
    }
}
