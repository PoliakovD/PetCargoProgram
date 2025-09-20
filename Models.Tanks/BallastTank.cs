using PetCargoProgram.Models.LoadingCondition;

namespace PetCargoProgram.Models.Tanks;


public class BallastTank : ILoadingConditionItem
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
    // TODO Добавить свойства для балластного танка
    // TODO +возможно добавить функционал для учета седиментов
}
