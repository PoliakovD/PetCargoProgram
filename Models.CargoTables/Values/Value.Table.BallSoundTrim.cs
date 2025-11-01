namespace PetCargoProgram.Models.CargoTables.Values;

/// <summary>
/// Ballast Sound Trim Table Value
/// </summary>
public class ValueTableBallSoundTrim
{
    /// <summary>
    /// Volume in m3 for Trim 5 meters
    /// </summary>
    public double VolumeTrim5 { get; set; }

    /// <summary>
    /// Volume in m3 for Trim 4 meters
    /// </summary>
    public double VolumeTrim4 { get; set; }

    /// <summary>
    /// Volume in m3 for Trim 3 meters
    /// </summary>
    public double VolumeTrim3 { get; set; }

    /// <summary>
    /// Volume in m3 for Trim 2 meters
    /// </summary>
    public double VolumeTrim2 { get; set; }

    /// <summary>
    /// Volume in m3 for Trim 1 meters
    /// </summary>
    public double VolumeTrim1 { get; set; }

    /// <summary>
    /// Volume in m3 for Trim 0 meters
    /// </summary>
    public double VolumeTrim0 { get; set; }

    /// <summary>
    /// Sound in meters
    /// </summary>
    public double Sound { get; set; }

    public ValueTableBallSoundTrim(double volumeTrim5, double volumeTrim4, double volumeTrim3, double volumeTrim2,
        double volumeTrim1, double volumeTrim0, double sound)
    {
        VolumeTrim5 = volumeTrim5;
        VolumeTrim4 = volumeTrim4;
        VolumeTrim3 = volumeTrim3;
        VolumeTrim2 = volumeTrim2;
        VolumeTrim1 = volumeTrim1;
        VolumeTrim0 = volumeTrim0;
        Sound = sound;
    }

    public override string ToString()
    {
        return VolumeTrim5 + "\t" + VolumeTrim4 + "\t" + VolumeTrim3 + "\t" + VolumeTrim2 +
               "\t" + VolumeTrim1 + "\t" + VolumeTrim0 + "\t" + Sound;
    }

    public override int GetHashCode()
    {
        return this.ToString().GetHashCode();
    }
}
