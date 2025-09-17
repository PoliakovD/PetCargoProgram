namespace PetCargoProgram.LoadingCondition
{
    internal interface ILoadingConditionObject
    {
        string Name { get; set; }
        double MaxVolume { get; set; }
        double Level { get; set; }
        double Volume { get; set; }
        double Percents { get; set; }
        double? Density { get; set; }
        double Weight { get; set; }
        double LCG { get; set; }
        double VCG { get; set; }
        double TCG { get; set; }

    }
}
