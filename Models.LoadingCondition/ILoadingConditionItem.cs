using System.ComponentModel;
using System.Windows.Media;

namespace PetCargoProgram.Models.LoadingCondition;
/// <summary>
/// Interface for Loading Condition Calculation
/// </summary>
public interface ILoadingConditionItem : INotifyPropertyChanged
{
    public string ItemName { get; set; }
    public double MaxVolume { get; set; }
    public double MaxUllage{ get; set; }
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
    public SolidColorBrush Color { get; set; }
    public TypeOfLoadingConditionItem TypeOfItem { get; set; }
}

public enum TypeOfLoadingConditionItem
{
    CargoTank,BallastTank,FuelOilTank,DieselOilTank,LubeOilTank,FreshWaterTank,Stores,Other
}
