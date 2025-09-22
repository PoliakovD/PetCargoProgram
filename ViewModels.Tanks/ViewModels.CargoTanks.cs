using System.Collections.Generic;
using System.Collections.ObjectModel;
using PetCargoProgram.Models.Tanks;
using PetCargoProgram.Services.CargoTank;
using PetCargoProgram.ViewModels.Base;

namespace PetCargoProgram.ViewModels.Tanks;

public class ViewModel_CargoTank: ViewModelBase
{
    private ServiceCargoTanks _service;

    public ObservableCollection<CargoTank> CargoTanks { get; } = [];

    public ViewModel_CargoTank()
    {
        _service = new ServiceCargoTanks();
        FillObservableCollections(_service.GetAll(), CargoTanks);
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
