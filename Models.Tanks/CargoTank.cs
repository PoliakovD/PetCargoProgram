using PetCargoProgram.Models.LoadingCondition;

namespace PetCargoProgram.Models.Tanks;


public class CargoTank : ILoadingConditionItem
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

    // TODO Добавить свойства для грузового танка (вес груза в вакууме, обьем в баррелях и тд)
}
