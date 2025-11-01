namespace PetCargoProgram.Models.CargoTables.Values;

/// <summary>
/// Other Sounding table value
/// </summary>
public class ValueTableOtherSounding
{
    /// <summary>
    /// Volume in m3
    /// </summary>
    public double Volume { get; set; }

    /// <summary>
    /// Sound in meters
    /// </summary>
    public double Sound { get; set; }

    public ValueTableOtherSounding(double volume, double sound)
    {
        this.Volume = volume;
        this.Sound = sound;
    }

    public override string ToString()
    {
        return Volume + "\t" + Sound;
    }

    public override int GetHashCode()
    {
        return this.ToString().GetHashCode();
    }
}
