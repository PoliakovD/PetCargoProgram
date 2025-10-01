using System;

namespace PetCargoProgram.Models.ShipCondition;

public partial class ShipConditionClass
{
    private double _draftActual; // Берется из гидростатических таблиц(DRAFT_1025)
    private double _draftEquivalent; // Считается из солености воды
    private double _seaWaterDensity; //Cлёность воды
    public const double LengthBetweenPerpendiculars = 239.0; // Длинна между перпенднуларями

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


    private double _freeSurface;


    public double DraftEquivalent
    {
        get => _draftEquivalent;
        set => SetField(ref _draftEquivalent, value);
    }

    // Расчет актуальной осадки от солнеситости воды
    //=(DRAFT_1025+DISPLACEMENT/(100*TPC)*((1.025-SWD)/SWD))

    //Расчет носовой  осадки

    //(DRAFT_ACT-((Lpp/2-Xf)/Lpp)*((DISPLACEMENT*(Xc-Xg))/(MCTC*100)))*
    //(xf - lcf from lpp/2)
    // xc- LCB
    // Xg - момент по х

    // Расчет кормовой осадки

    //=(Dfp+((DISPLACEMENT*(Xc-Xg))/(MCTC*100)))*figa

    // Расчет угла крена
    // ((ATAN(My/((Zm-Zg-(FSM_FACT/DISPLACEMENT))*DISPLACEMENT)))*57.3)
    // My - момент по Y
    // Zm - KM из гидростатических таблиц
    // Zg - MomentZ/Displacement
    public void CalcDrafts()
    {
        _draftActual = (_draftEquivalent + Displacement / (100.0 * _tpc) * ((1.025 - _seaWaterDensity) / _seaWaterDensity));
        OnPropertyChanged(nameof(DraftActual));

        DraftForChart = -_draftActual;

        _draftFore = (_draftActual - ((LengthBetweenPerpendiculars / 2 - LCF) / LengthBetweenPerpendiculars) *
            ((Displacement * (LCB - MomentX/Displacement)) / (MCTC * 100.0)));
        OnPropertyChanged(nameof(DraftFore));

        _draftAft = (_draftActual + ((LengthBetweenPerpendiculars / 2 - LCF) / LengthBetweenPerpendiculars) *
            ((Displacement * (LCB - MomentX/Displacement)) / (MCTC * 100.0)));
        OnPropertyChanged(nameof(DraftAft));

        _draftMean = (_draftAft + _draftFore) / 2.0;
        OnPropertyChanged(nameof(DraftMean));

        _trim = _draftAft-_draftFore;
        OnPropertyChanged(nameof(Trim));



        TrimAngle=Math.Asin(Trim/LengthBetweenPerpendiculars)*-57.3;
        OnPropertyChanged(nameof(TrimAngle));

        Gm = KM - MomentZ / Displacement;
        OnPropertyChanged(nameof(Gm));

        Gom = KM - (MomentZ / Displacement) - (FreeSurface / Displacement);
        OnPropertyChanged(nameof(Gom));

        _list=Math.Round(Math.Atan(MomentY/(Gom*Displacement))*57.3,2);
        OnPropertyChanged(nameof(List));
    }

    public double SeaWaterDensity
    {
        get => _seaWaterDensity;
        set
        {
            SetField(ref _seaWaterDensity, value);
            CalcDrafts();
        }
    }

    public double FreeSurface
    {
        get => _freeSurface;
        set =>SetField(ref _freeSurface, value);
    }
}
