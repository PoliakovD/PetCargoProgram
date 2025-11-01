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

    private double _freeSurface;
    private double _momentX;
    private double _momentY;
    private double _momentZ;

    public double MomentX
    {
        get => _momentX;
        set => SetField(ref _momentX, value);
    }

    public double MomentY
    {
        get => _momentY;
        set => SetField(ref _momentY, value);
    }

    public double MomentZ
    {
        get => _momentZ;
        set => SetField(ref _momentZ, value);
    }

    public double DraftEquivalent
    {
        get => _draftEquivalent;
        set => SetField(ref _draftEquivalent, value);
    }

    public void CalcDrafts()
    {
        _draftActual = (_draftEquivalent + Displacement / (100.0 * _tpc) * ((1.025 - _seaWaterDensity) / _seaWaterDensity));
        OnPropertyChanged(nameof(DraftActual));

        var drafForeBeforeCorected =(_draftActual - ((LengthBetweenPerpendiculars / 2 - LCF) / LengthBetweenPerpendiculars) *
            ((Displacement * (LCB - MomentX/Displacement)) / (MCTC * 100.0)));
        var drafAftBeforeCorected = drafForeBeforeCorected+(Displacement*(LCB-MomentX/Displacement))/(MCTC*100.0);


        //
        // double meanedDraft = (drafAftBeforeCorected + _draftActual*6 + drafForeBeforeCorected) / 8.0;
        // double LcfOnDraft = CargoTablesProvider.Hydrostatic.GetLCF(meanedDraft);
        // double trimCorrection = (LcfOnDraft*(drafAftBeforeCorected-drafForeBeforeCorected))/LengthBetweenPerpendiculars;
        // double equivalentdraft = _draftActual + trimCorrection;
        // double equivalentDisplacement = CargoTablesProvider.Hydrostatic.GetDisplacement(equivalentdraft);
        // double displacementForCalculation = equivalentDisplacement * (SeaWaterDensity / 1.025);
        // var valueHydrostaticForCalc = CargoTablesProvider.Hydrostatic.GetValue(displacementForCalculation);
        // double freshWaterAllowance = (displacementForCalculation/(100.0*valueHydrostaticForCalc.TPC)*((1.025-1.0)/1.0))*1000.0;
        // double draftWaterAllowance=displacementForCalculation/(100.0*valueHydrostaticForCalc.TPC)*((1.025-SeaWaterDensity)/SeaWaterDensity);

        // double truedraft = equivalentdraft - draftWaterAllowance;

        double correction = 0.0;

        // _draftFore = (_draftActual - ((LengthBetweenPerpendiculars / 2 - LCF) / LengthBetweenPerpendiculars) *
        //     ((Displacement * (LCB - MomentX/Displacement)) / (MCTC * 100.0)));
        // OnPropertyChanged(nameof(DraftFore));

        _draftFore = drafForeBeforeCorected + correction;
        OnPropertyChanged(nameof(DraftFore));

        // _draftAft = (_draftActual + ((LengthBetweenPerpendiculars / 2 - LCF) / LengthBetweenPerpendiculars) *
        //     ((Displacement * (LCB - MomentX/Displacement)) / (MCTC * 100.0)));
        // OnPropertyChanged(nameof(DraftAft));
        //=(Dfp+((DISPLACEMENT*(Xc-Xg))/(MCTC*100)))*figa

        _draftAft = drafAftBeforeCorected + correction;
        OnPropertyChanged(nameof(DraftAft));

        _draftMean = (_draftAft + _draftFore) / 2.0;
        OnPropertyChanged(nameof(DraftMean));

        _trim = _draftAft-_draftFore;
        OnPropertyChanged(nameof(Trim));

        TrimAngle=Math.Asin(Trim/LengthBetweenPerpendiculars)*-57.3;
        OnPropertyChanged(nameof(TrimAngle));

        Gm = KM - MomentZ / Displacement;
        OnPropertyChanged(nameof(Gm));

        Gom = Gm - (FreeSurface / Displacement);
        OnPropertyChanged(nameof(Gom));

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

    public double FreeSurface
    {
        get => _freeSurface;
        set =>SetField(ref _freeSurface, value);
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
        CalcDrafts();

    }
}
