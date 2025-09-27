using System.ComponentModel;
using PetCargoProgram.Models.Tanks;

namespace PetCargoProgram.Services.LoadingCondition;

public partial class ServiceLoadingCondition
{
    public void UpdateShipCondition(object sender, PropertyChangedEventArgs e)
    {
        UpdateOnBoard();
        UpdateFromHydrostaticTable();
    }

    private void UpdateOnBoard()
    {
        double sumCargo = 0.0;
        double sumBallast = 0.0;
        double sumFuel = 0.0;
        double sumDiesel = 0.0;
        double sumLube = 0.0;
        double sumFW = 0.0;
        foreach (var item in Table)
        {
            if (item is BallastTank) sumBallast += item.Weight;
            if (item is CargoTank) sumCargo += item.Weight;
            if (item is OtherTank) sumFuel += item.Weight; // TODO Добавить остальные типы танков
        }

        ShipCondition.CargoOnBoard = sumCargo;
        ShipCondition.BallastOnBoard = sumBallast;
        ShipCondition.FuelOilOnBoard = sumFuel;
        ShipCondition.Displacement =  _shipCondition.CargoOnBoard
                                      + _shipCondition.BallastOnBoard
                                      + _shipCondition.FuelOilOnBoard
                                      + _shipCondition.LubeOilOnBoard
                                      + _shipCondition.DieselOnBoard
                                      + _shipCondition.FreshWaterOnBoard
                                      + _shipCondition.LubeOilOnBoard
                                      + _shipCondition.LightWeight;
        ShipCondition.DeadWeight = _shipCondition.Displacement - _shipCondition.LightWeight;
    }

    private void UpdateFromHydrostaticTable()
    {
        var value = _hydrostatic.GetValue(_shipCondition.Displacement);
        ShipCondition.DraftMean = value.Draft;
        ShipCondition.TPC = value.TPC;
        ShipCondition.Gm = value.MetacentrKM;
        ShipCondition.LCG = value.FloatationCenterLCF;
        ShipCondition.MCTC= value.MCTC;
        ShipCondition.LCB= value.LCB;
        ShipCondition.CM = value.CM;

    }
}
