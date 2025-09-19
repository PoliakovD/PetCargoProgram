namespace PetCargoProgram.Models.CargoTables.Values;

public class Value_Table_BallSoundTrim
{
    public double VolumeTrim5 {get; set; }
    public double VolumeTrim4{get;set;}
    public double VolumeTrim3{get;set;}
    public double VolumeTrim2{get;set;}
    public double VolumeTrim1{get;set;}
    public double VolumeTrim0{get;set;}
    public double Sound{get;set;}

    public Value_Table_BallSoundTrim(double volumeTrim5, double volumeTrim4, double volumeTrim3, double volumeTrim2,
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

