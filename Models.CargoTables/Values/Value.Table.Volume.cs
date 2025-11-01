namespace PetCargoProgram.Models.CargoTables.Values;

public class ValueTableVolume
{
    public double Volume { get; set; }
    public double LCG { get; set; }
    public double TCG { get; set; }
    public double VCG { get; set; }
    public double IY { get; set; }

    public ValueTableVolume(double vol, double lcg, double tcg, double vcg, double iy)
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
    public override int GetHashCode()
    {
        return this.ToString().GetHashCode();
    }
}
