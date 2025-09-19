using System.Windows;
using PetCargoProgram.DataAccess;

namespace PetCargoProgram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AllTables? Tables { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Tables.BinaryLoad();
            //Tables = new CargoTables.CargoTables();
            //Tables.Save();
            Load_LoadingCondition();
        }
        private void Load_LoadingCondition()
        {
            var Table = Tables.TablesHydrostatic[0];
            DataGrid_LoadingCondion.ItemsSource = Table.Table;
        }
    }
}
