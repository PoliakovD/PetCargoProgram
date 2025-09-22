using System;
using PetCargoProgram.Models.LoadingCondition;

namespace PetCargoProgram.Models.Tanks;


public partial class CargoTank : ILoadingConditionItem, IEquatable<CargoTank>
{
    public string Name { get; set; }
    public double MaxVolume { get; set; }
    public double Level { get; set; }
    public double Ullage { get; set; }
    public double Volume { get; set; }
    public double VolumePercent { get; set; }
    public double Density { get; set; }
    public double Weight { get; set; }
    public double LCG { get; set; }
    public double VCG { get; set; }
    public double TCG { get; set; }

    public double TempCelsius{ get; set; }
    public double TempFaringates{ get; set; }
    public double API { get; set; }
    public double VolumeCorrectionFactorBBLS { get; set; }
    public double VolumeCorrectionFactor { get; set; }

    public double ObservedVolume{ get; set; }
    public double GrossVolume{ get; set; }

    public void Clear()
    {
        Name = null;
        MaxVolume = 0;
        Level = 0;
        Ullage = 0;
        Volume = 0;
        VolumePercent = 0;
        Density = 0;
        Weight = 0;
        LCG = 0;
        VCG = 0;
        VCG = 0;
        TCG = 0;
        TempCelsius = 0;
        TempFaringates = 0;
        API = 0;
        VolumeCorrectionFactorBBLS = 0;
        VolumeCorrectionFactor = 0;
        ObservedVolume = 0;
        GrossVolume = 0;
    }
    // TODO Добавить свойства для грузового танка (вес груза в вакууме, обьем в баррелях и тд)
}

