using System;
using PetCargoProgram.Services.CargoTables;

namespace PetCargoProgram.Models.ShipCondition;

public partial class ShipConditionClass
{
    private double _draftActual; // Берется из гидростатических таблиц(DRAFT_1025)
    private double _draftEquivalent; // Считается из солености воды
    private double _draftAft;
    private double _draftMean;
    private double _draftFore;

    private double _seaWaterDensity; //Cлёность воды
    public const double LengthBetweenPerpendiculars = 239.0; // Длинна между перпенднуларями

    private double _LCFForChart;
    public double LCFForChart
    {
        get => _LCFForChart;
        set => SetField(ref _LCFForChart, value);
    }

    public double DraftEquivalent
    {
        get => _draftEquivalent;
        set => SetField(ref _draftEquivalent, value);
    }

    public void CalcDraftsAndStability()
    {
        CalcDrafts();
        CalcStability();
    }

    public void CalcDrafts()
    {
        _draftActual = (_draftEquivalent + Displacement / (100.0 * _tpc) * ((1.025 - _seaWaterDensity) / _seaWaterDensity));
        OnPropertyChanged(nameof(DraftActual));

        _draftFore = (_draftActual - ((LengthBetweenPerpendiculars / 2 - LCF) / LengthBetweenPerpendiculars) *
            ((Displacement * (LCB - MomentX/Displacement)) / (MCTC * 100.0)));
        OnPropertyChanged(nameof(DraftFore));

        _draftAft =_draftFore+(Displacement*(LCB-MomentX/Displacement))/(MCTC*100.0);
        OnPropertyChanged(nameof(DraftAft));

        _draftMean = (_draftAft + _draftFore) / 2.0;
        OnPropertyChanged(nameof(DraftMean));

        _trim = _draftAft-_draftFore;
        OnPropertyChanged(nameof(Trim));

        TrimAngle=Math.Asin(Trim/LengthBetweenPerpendiculars)*-57.3;
        OnPropertyChanged(nameof(TrimAngle));

        _list=Math.Round(Math.Atan(MomentY/(Gom*Displacement))*57.3,2);
        OnPropertyChanged(nameof(List));
    }

    public double SeaWaterDensity
    {
        get => _seaWaterDensity;
        set
        {
            if (value < 0.990) value = 0.990;
            if (value > 1.030) value = 1.030;
            SetField(ref _seaWaterDensity, value);
            UpdateFromHydrostaticTable();

        }
    }


    private ServiceHydrostatic _hydrostatic=CargoTablesProvider.Hydrostatic;
    public void UpdateFromHydrostaticTable()
    {
        var value = _hydrostatic.GetValue(Displacement*(1.025/SeaWaterDensity));
        DraftEquivalent = value.Draft;
        TPC = value.TPC;
        KM = value.MetacentrKM;
        LCF = value.FloatationCenterLCF;
        LCFForChart = LCF + 119.5; // LBP/2
        MCTC= value.MCTC;
        LCB= value.LCB;
        CM = value.CM;
        CalcDraftsAndStability();

    }
}
