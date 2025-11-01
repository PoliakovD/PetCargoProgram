namespace PetCargoProgram.Models.CargoTables.Values;

public class ValueTableOtherSounding
{
    public double Volume { get; set; }
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
