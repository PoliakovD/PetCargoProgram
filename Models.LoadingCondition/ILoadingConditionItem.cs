namespace PetCargoProgram.Models.LoadingCondition;

public interface ILoadingConditionItem
{
    public string Name { get; init; }
    public double MaxVolume { get; init; }
    public double MaxUllage{ get; init; }
    public double Sound { get; set; }
    public double Ullage { get; set; }
    public double Volume { get; set; }
    public double VolumePercent { get; set; }
    public double Density { get; set; }
    public double Weight { get; set; }
    public double LCG { get; set; }
    public double VCG { get; set; }
    public double TCG { get; set; }
    public double IY { get; set; }

}
