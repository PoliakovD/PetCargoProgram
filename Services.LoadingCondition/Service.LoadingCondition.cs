using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using PetCargoProgram.Models.LoadingCondition;
using PetCargoProgram.Models.ShipCondition;
using PetCargoProgram.Models.Tanks;
using PetCargoProgram.Services.CargoTables;
using PetCargoProgram.ViewModels.Base;

namespace PetCargoProgram.Services.LoadingCondition;

public partial class ServiceLoadingCondition : NotifyPropertyChanged
{
    public ObservableCollection<CargoTank> TableCargoTanks { get; set; } = [];
    public ObservableCollection<ILoadingConditionItem> Table { get; set; } = [];


    private ShipConditionClass _shipCondition;
    public ShipConditionClass ShipCondition
    {
        get => _shipCondition;
        set => SetField(ref _shipCondition, value);
    }

    public ServiceLoadingCondition()
    {
        Table.CollectionChanged  += ItemsOnListChanged;
        ShipCondition = new ShipConditionClass();
        //UpdateShipCondition();
        // WeightOnListChanged();

    }

    private ServiceHydrostatic _hydrostatic=CargoTablesProvider.Hydrostatic;
    public void Add(ILoadingConditionItem item) => Table.Add(item);
    public void AddRange(IEnumerable<ILoadingConditionItem> items)
    {
        foreach (var item in items) Table.Add(item);
    }
    public void AddCargoTanks(IEnumerable<CargoTank> items)
    {
        foreach (var item in items) TableCargoTanks.Add(item);
        AddRange(items);
    }

    private void ItemsOnListChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.OldItems != null)
        {
            foreach (INotifyPropertyChanged item in e.OldItems)
                item.PropertyChanged -= UpdateShipCondition;
        }
        if (e.NewItems != null)
        {
            foreach (INotifyPropertyChanged item in e.NewItems)
                item.PropertyChanged += UpdateShipCondition;
        }
    }


}
