using System.ComponentModel;
using PetCargoProgram.Models.LoadingCondition;
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
        double sumOther = 0.0;
        foreach (var item in Table)
        {
            if (item is BallastTank) sumBallast += item.Weight;
            if (item is CargoTank) sumCargo += item.Weight;
            if (item is OtherTank)
                switch (item.TypeOfItem)
            {
                case  TypeOfLoadingConditionItem.FuelOilTank:
                {
                    sumFuel+=item.Weight;
                    break;
                }
                case TypeOfLoadingConditionItem.DieselOilTank:
                {
                    sumDiesel+=item.Weight;
                    break;
                }
                case TypeOfLoadingConditionItem.LubeOilTank:
                {
                    sumLube+=item.Weight;
                    break;
                }
                case TypeOfLoadingConditionItem.FreshWaterTank:
                {
                    sumFW+=item.Weight;
                    break;
                }
                case TypeOfLoadingConditionItem.Other:
                {
                    sumOther += item.Weight;
                    break;
                }
            }; // TODO Добавить остальные типы танков
        }

        var totalSum = sumCargo + sumBallast + sumFuel + sumDiesel + sumLube + sumFW + sumOther;

        ShipCondition.CargoOnBoard = sumCargo;
        ShipCondition.BallastOnBoard = sumBallast;
        ShipCondition.FuelOilOnBoard = sumFuel;
        ShipCondition.DieselOilOnBoard = sumDiesel;
        ShipCondition.LubeOilOnBoard = sumLube;
        ShipCondition.FreshWaterOnBoard = sumFW;
        ShipCondition.OtherStoresOnBoard = sumOther;

        ShipCondition.Displacement =  totalSum + _shipCondition.LightWeight;
        ShipCondition.DeadWeight = totalSum;
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
