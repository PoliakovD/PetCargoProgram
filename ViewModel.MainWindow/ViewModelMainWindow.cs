using System.Collections.Generic;
using System.Collections.ObjectModel;
using PetCargoProgram.DataAccess;
using PetCargoProgram.Models.CargoTables;
using PetCargoProgram.Models.Tanks;
using PetCargoProgram.ViewModels.Base;

namespace PetCargoProgram.ViewModels.MainWindow;

public class ViewModelMainWindow : ViewModelBase
{
    // private ViewModelCargoTanks _cargoTanks;
    // public ViewModelCargoTanks CargoTanks
    // {
    //     get => _cargoTanks;
    //     set => SetField(ref _cargoTanks, value);
    // }

    private static string[] _cargoTanksNames =
    ["COT 1P", "COT 2P", "COT 3P","COT 4P","COT 5P","COT 6P","SLOP P",
        "COT 1S", "COT 2S", "COT 3S","COT 4S","COT 5S","COT 6S","SLOP S"];

    public Dictionary<string, CargoTank> CargoTanks { get; set; } = [];
    // public ObservableCollection<CargoTank> CargoTanks { get; } = [];

    private AllCargoTables? _cargoTables;

    private CargoTank _testTank;

    public CargoTank TestTank
    {
        get => _testTank;
        set => SetField(ref _testTank, value);
    }

    public ViewModelMainWindow()
    {
        Init();
        // CargoTanks = new ViewModelCargoTanks();
    }
    private void Init()
    {
        _cargoTables = new AllCargoTables();
        BinaryCTService.Load(ref _cargoTables);
        CargoTank.InitCargoTables(_cargoTables);

        foreach (var tankName in _cargoTanksNames)
        {
            CargoTanks.Add(tankName,new CargoTank(tankName));
        }
        TestTank = new CargoTank("COT 1P");
    }

    private void FillObservableCollections<T>(IEnumerable<T> items, ObservableCollection<T> collection)
    {
        collection.Clear();
        foreach (var item in items)
        {
            collection.Add(item);
        }
    }
}
