namespace PetCargoProgram.CargoTables.Values;

public class Value_Table_OtherSounding
{
    public double volume { get; set; }
    public double sound { get; set; }
    public Value_Table_OtherSounding(double Volume, double Sound)
    {
        volume = Volume;
        sound = Sound;

    }
    public override string ToString()
    {
        return volume + "\t" + sound;
    }
}
