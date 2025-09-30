namespace PetCargoProgram.Models.ShipCondition;

public partial class ShipConditionClass
{
    private double _draftForChart;
    private double _LCFForChart;

    public double DraftForChart
    {
        get => _draftForChart;
        set => SetField(ref _draftForChart, value);
    }
    public double LCFForChart
    {
        get => _LCFForChart;
        set => SetField(ref _LCFForChart, value);
    }


}
