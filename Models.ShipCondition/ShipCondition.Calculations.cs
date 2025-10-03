using System;

namespace PetCargoProgram.Models.ShipCondition;

public partial class ShipConditionClass
{
    private double _draftActual; // Берется из гидростатических таблиц(DRAFT_1025)
    private double _draftEquivalent; // Считается из солености воды
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
            CalcDrafts();
        }
    }

    public double FreeSurface
    {
        get => _freeSurface;
        set =>SetField(ref _freeSurface, value);
    }
}
