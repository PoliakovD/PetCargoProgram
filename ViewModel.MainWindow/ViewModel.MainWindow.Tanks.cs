using System.Collections.Generic;
using System.Collections.ObjectModel;
using PetCargoProgram.DataAccess;
using PetCargoProgram.Models.CargoTables;
using PetCargoProgram.Models.Tanks;
using PetCargoProgram.Services.LoadingCondition;
using PetCargoProgram.ViewModels.Base;

namespace PetCargoProgram.ViewModels.MainWindow;

public partial class ViewModelMainWindow : ViewModelBase
{

    private static string[] _cargoTanksNames =
    ["COT 1P", "COT 2P", "COT 3P","COT 4P","COT 5P","COT 6P","SLOP P",
        "COT 1S", "COT 2S", "COT 3S","COT 4S","COT 5S","COT 6S","SLOP S"];

    private static string[] _ballastTanksNames =
    ["FPT", "BWT 1P","BWT 2P", "BWT 3P","BWT 4P","BWT 5P","BWT 6P","APT",
        "BWT 1S", "BWT 2S", "BWT 3S","BWT 4S","BWT 5S","BWT 6S"];
    public Dictionary<string, CargoTank> CargoTanks { get; set; } = [];
    // public ObservableCollection<CargoTank> CargoTanks { get; } = [];

    public Dictionary<string, BallastTank> BallastTanks { get; set; } = [];


    public ViewModelMainWindow()
    {
        Init();
        // CargoTanks = new ViewModelCargoTanks();
    }
    private void Init()
    {
        foreach (var tankName in _ballastTanksNames)
        {
            BallastTanks.Add(tankName,new BallastTank(tankName));
        }
        foreach (var tankName in _cargoTanksNames)
        {
            CargoTanks.Add(tankName,new CargoTank(tankName));
        }

        InitLoadingCondition();
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
