using PetCargoProgram.Models.Tanks;

namespace PetCargoProgram.Services.LoadingCondition;

public partial class ServiceLoadingCondition
{
    public void UpdateShipCondition()
    {
        UpdateOnBoard();
        _shipCondition.Displacement = _shipCondition.CargoOnBoard
                                      + _shipCondition.BallastOnBoard
                                      + _shipCondition.FuelOilOnBoard
                                      + _shipCondition.LubeOilOnBoard
                                      + _shipCondition.DieselOnBoard
                                      + _shipCondition.FreshWaterOnBoard
                                      + _shipCondition.LubeOilOnBoard
                                      + _shipCondition.LightWeight;

        _shipCondition.DeadWeight = _shipCondition.Displacement - _shipCondition.LightWeight;
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

        _shipCondition.CargoOnBoard = sumCargo;
        _shipCondition.BallastOnBoard = sumBallast;
        _shipCondition.FuelOilOnBoard = sumFuel;
    }

    private void UpdateFromHydrostaticTable()
    {
        var value = _hydrostatic.GetValue(_shipCondition.Displacement);
        _shipCondition.DraftMean = value.Draft;
        _shipCondition.TPC = value.TPC;
        _shipCondition.Gm = value.MetacentrKM;
        _shipCondition.LCG = value.FloatationCenterLCF;
        _shipCondition.MCTC= value.MCTC;
        _shipCondition.LCB= value.LCB;
        _shipCondition.CM = value.CM;

    }
}
