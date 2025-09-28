using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;
using PetCargoProgram.DataAccess;
using PetCargoProgram.Models.CargoTables;
using PetCargoProgram.Models.LoadingCondition;
using PetCargoProgram.Models.ShipCondition;
using PetCargoProgram.Models.Tanks;
using PetCargoProgram.Services.LoadingCondition;
using PetCargoProgram.ViewModels.Base;

namespace PetCargoProgram.ViewModels.MainWindow;

public partial class ViewModelMainWindow : ViewModelBase
{

    private static string[] _cargoTanksNames =
    [
        "COT 1P", "COT 2P", "COT 3P", "COT 4P", "COT 5P", "COT 6P", "SLOP P",
        "COT 1S", "COT 2S", "COT 3S", "COT 4S", "COT 5S", "COT 6S", "SLOP S"
    ];

    private static string[] _ballastTanksNames =
    [
        "FPT", "BWT 1P", "BWT 2P", "BWT 3P", "BWT 4P", "BWT 5P", "BWT 6P",
        "APT", "BWT 1S", "BWT 2S", "BWT 3S", "BWT 4S", "BWT 5S", "BWT 6S"
    ];

    private static string[] _fuelOilTanksNames =
    [
        "NO.1 HFO.STOR.T. (P)", "NO.1 HFO.STOR.T. (S)", "NO.2 HFO.STOR.T. (S)",
        "HFO SETT.T. (S)", "HFO SERV.T. (S)", "L.S. HFO.SETT.T. (S)", "L.S. HFO.SERV.T. (S)"
    ];

    private static string[] _dieselOilTanksNames =
    [
        "D.O STOR.T (S)", "D.O SERV.T (S)", "NO.2 HFO.STOR.T. (P)"
    ];

    private static string[] _lubeOilTanksNames =
    [
        "MAIN L.O SETT.T. (S)", "MAIN L.O.STOR.T. (S)",
        "NO.1 CYL.OIL.STOR.T. (S)", "NO.2 CYL.OIL.STOR.T. (P)", "GE L.O STOR.T. (S)", "TUR.L.O.STOR.T. (S)",
        "MAIN L.O SUMP T. (C)"
    ];
    private static string[] _freshWaterTanksNames = ["FWT P", "FWT S"];

    private static string[] _otherTanksNames =
    [
        "C.W.T. (С)", "ST L.O.DRAIN T. (S)", "SEP. BILGE OIL T. (P)",
        "BILGE HOLDING T. (P)", "F.O. OVERFLOW T. (C)", "PURIF. SLUDGE T. (S)", "BW (ER AFT,P)", "BW (ER FWD,P)",
        "BW (ER FWD,S)"
    ];

    private static SolidColorBrush _fuelOilBrush = new SolidColorBrush(Color.FromArgb(156, 229, 190, 182));
    private static SolidColorBrush _dieselOilBrush = new SolidColorBrush(Color.FromArgb(76, 229, 190, 47));
    private static SolidColorBrush _lubeOilBrush = new SolidColorBrush(Color.FromArgb(77, 241, 232, 0));
    private static SolidColorBrush _freshWaterBrush = new SolidColorBrush(Color.FromArgb(38, 33, 137, 248));
    private static SolidColorBrush _otherBrush = new SolidColorBrush(Color.FromArgb(10, 33, 6, 1));

    public Dictionary<string, CargoTank> CargoTanks { get; set; } = [];
    // public ObservableCollection<CargoTank> CargoTanks { get; } = [];

    public Dictionary<string, BallastTank> BallastTanks { get; set; } = [];

    public Dictionary<string,OtherTank> OtherTanks { get; set; } = [];


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
        foreach (var tankName in _fuelOilTanksNames)
        {
            OtherTanks.Add(tankName,new OtherTank(tankName,TypeOfLoadingConditionItem.FuelOilTank,_fuelOilBrush));
        }
        foreach (var tankName in _dieselOilTanksNames)
        {
            OtherTanks.Add(tankName,new OtherTank(tankName,TypeOfLoadingConditionItem.DieselOilTank,_dieselOilBrush));
        }

        foreach (var tankName in _lubeOilTanksNames)
        {
            OtherTanks.Add(tankName,new OtherTank(tankName,TypeOfLoadingConditionItem.LubeOilTank,_lubeOilBrush));
        }
        foreach (var tankName in _freshWaterTanksNames)
        {
            OtherTanks.Add(tankName,new OtherTank(tankName,TypeOfLoadingConditionItem.FreshWaterTank,_freshWaterBrush));
        }
        foreach (var tankName in _otherTanksNames)
        {
            OtherTanks.Add(tankName,new OtherTank(tankName,TypeOfLoadingConditionItem.Other,_otherBrush));
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
