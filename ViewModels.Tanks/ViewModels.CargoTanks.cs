using System.Collections.Generic;
using System.Collections.ObjectModel;
using PetCargoProgram.Models.Tanks;
using PetCargoProgram.ViewModels.Base;

namespace PetCargoProgram.ViewModels.Tanks;

public class ViewModelCargoTanks: NotifyPropertyChanged
{
    private static string[] _cargoTanksNames =
    ["COT 1P", "COT 2P", "COT 3P","COT 4P","COT 5P","COT 6P","SLOPP",
        "COT 1S", "COT 2S", "COT 3S","COT 4S","COT 5S","COT 6S","SLOPS"];

    public Dictionary<string, CargoTank> CargoTanks { get; set; } = [];
    // public ObservableCollection<CargoTank> CargoTanks { get; } = [];

    public ViewModelCargoTanks()
    {
        Init();
        // FillObservableCollections(_cargoTanks.Values, CargoTanks);
    }

    private void Init()
    {
        foreach (var tankName in _cargoTanksNames)
        {
            CargoTanks.Add(tankName,new CargoTank(tankName));
        }
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
