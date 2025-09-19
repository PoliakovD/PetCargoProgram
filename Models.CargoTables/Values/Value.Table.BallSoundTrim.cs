using Model.CargoTables;

namespace PetCargoProgram.CargoTables.Values;

public class Value_Table_BallSoundTrim : ICargoTableValue
{
    public double VolumeTrim5 {get; set; }
    public double VolumeTrim4{get;set;}
    public double VolumeTrim3{get;set;}
    public double VolumeTrim2{get;set;}
    public double VolumeTrim1{get;set;}
    public double VolumeTrim0{get;set;}
    public double Sound{get;set;}

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

