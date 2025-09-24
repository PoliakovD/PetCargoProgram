using System.Windows;
using PetCargoProgram.DataAccess;
using PetCargoProgram.Models.CargoTables;
using PetCargoProgram.Models.Tanks;

namespace PetCargoProgram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // private AllCargoTables? _cargoTables;
        public MainWindow()
        {
            // _cargoTables = new AllCargoTables();
            // BinaryCTService.Load(ref _cargoTables);
            // CargoTank.InitCargoTables(_cargoTables);

            InitializeComponent();

            // InitViewCargoTanks();
            // Load_LoadingCondition();
        }
        // private void Load_LoadingCondition()
        // {
        //     var Table = _cargoTables.TablesHydrostatic.Tables[0];
        //     DataGrid_LoadingCondion.ItemsSource = Table.Table;
        // }

        // private void InitViewCargoTanks()
        // {
        //     COT1P.Component.Name = COT1P.CargoTankName;
        //     COT2P.Component.Name = COT2P.CargoTankName;
        //     COT3P.Component.Name = COT3P.CargoTankName;
        //     COT4P.Component.Name = COT4P.CargoTankName;
        //     COT5P.Component.Name = COT5P.CargoTankName;
        //     COT6P.Component.Name = COT6P.CargoTankName;
        //     SLOPP.Component.Name = SLOPP.CargoTankName;
        //     COT1S.Component.Name = COT1S.CargoTankName;
        //     COT2S.Component.Name = COT2S.CargoTankName;
        //     COT3S.Component.Name = COT3S.CargoTankName;
        //     COT4S.Component.Name = COT4S.CargoTankName;
        //     COT5S.Component.Name = COT5S.CargoTankName;
        //     COT6S.Component.Name = COT6S.CargoTankName;
        //     SLOPS.Component.Name = SLOPS.CargoTankName;
        //
        // }
    }
}
