namespace PetCargoProgram.Models.CargoTables.Values;

/// <summary>
/// Volume table value
/// </summary>
public class ValueTableVolume
{
    /// <summary>
    /// Volume in m3
    /// </summary>
    public double Volume { get; set; }

    /// <summary>
    /// LCG in meters
    /// </summary>
    public double LCG { get; set; }

    /// <summary>
    /// TCG in meters
    /// </summary>
    public double TCG { get; set; }

    /// <summary>
    /// VCG in meters
    /// </summary>
    public double VCG { get; set; }

    /// <summary>
    /// about square of freesurface
    /// </summary>
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
