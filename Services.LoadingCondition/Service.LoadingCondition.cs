using System;
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
    public BindingList<ILoadingConditionItem> Table{get; set; }


    private ShipCondition _shipCondition;
    public ShipCondition ShipCondition
    {
        get => _shipCondition;
        set=>SetField(ref _shipCondition, value);
    }

    public ServiceLoadingCondition()
    {
        Table=new BindingList<ILoadingConditionItem>();
        Table.ListChanged  += ItemsOnListChanged;
    }

    private ServiceHydrostatic _hydrostatic=CargoTablesProvider.Hydrostatic;
    public void Add(ILoadingConditionItem item) => Table.Add(item);
    public void AddRange(IEnumerable<ILoadingConditionItem> items) => Table.AddRange(items);

    private void ItemsOnListChanged(object sender, ListChangedEventArgs  e)
    {
        if (e.ListChangedType == ListChangedType.ItemChanged)
        {
            UpdateShipCondition();
        }
    }

}
