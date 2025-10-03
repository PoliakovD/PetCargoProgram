namespace PetCargoProgram.Models.ShipCondition;

public partial class ShipConditionClass
{
    private double _LCFForChart;
    public double LCFForChart
    {
        get => _LCFForChart;
        set => SetField(ref _LCFForChart, value);
    }


}
