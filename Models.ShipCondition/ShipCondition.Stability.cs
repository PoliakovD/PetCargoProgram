namespace PetCargoProgram.Models.ShipCondition;

public partial class ShipConditionClass
{
    private double _freeSurface;
    private double _momentX;
    private double _momentY;
    private double _momentZ;
    private double _fluidZg;

    private const short columnsInStabilityTables = 22;

    private readonly double[] colimnsAngleStablityTables = new double[]
        {-40.0, -30.0, -20.0, -15.0, -10.0, -5.0, -0.1, 0, 0.1, 5.0, 10.0, 15.0, 20.0, 30.0, 40.0, 50.0, 60.0, 70.0, 80.0, 90};

    private double[] StaticStabilityTable = new double[columnsInStabilityTables];
    private double[] DynamicStabilityTable = new double[columnsInStabilityTables];

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
    public double FreeSurface
    {
        get => _freeSurface;
        set =>SetField(ref _freeSurface, value);
    }

    public double FluidZg
    {
        get => _fluidZg;
        set => SetField(ref _fluidZg, value);
    }
    public void CalcStability()
    {
        Gm = KM - MomentZ / Displacement;
        OnPropertyChanged(nameof(Gm));

        Gom = Gm - (FreeSurface / Displacement);
        OnPropertyChanged(nameof(Gom));

        FluidZg = KM + (FreeSurface / Displacement);
        OnPropertyChanged(nameof(Gom));


    }


}
