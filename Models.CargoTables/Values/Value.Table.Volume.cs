namespace PetCargoProgram.CargoTables.Values;

public class Value_Table_Volume
{
    public double Volume { get; set; }
    public double LCG { get; set; }
    public double TCG { get; set; }
    public double VCG { get; set; }
    public double IY { get; set; }

    public Value_Table_Volume(double vol, double lcg, double tcg, double vcg, double iy)
    {
        Volume = vol;
        LCG = lcg;
        TCG = tcg;
        VCG = vcg;
        IY = iy;

    }
    public override string ToString()
    {
        return Volume + "\t" + LCG + "\t" + TCG + "\t" + VCG +
               "\t" + IY;
    }
}
