namespace PetCargoProgram.Models.CargoTables.Values;

public class Value_Table_OtherSounding
{
    public double Volume { get; set; }
    public double Sound { get; set; }
    public Value_Table_OtherSounding(double volume, double sound)
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
