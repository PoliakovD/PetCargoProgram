namespace PetCargoProgram.Models.CargoTables.Values;

public class Value_Table_CargoTankUllageTrim
{
    public double Ullage { get; set; }
    public double CargoVolumeTrim4 { get; set; }
    public double CargoVolumeTrim3 { get; set; }
    public double CargoVolumeTrim2 { get; set; }
    public double CargoVolumeTrim1 { get; set; }
    public double CargoVolumeTrim0 { get; set; }
    public double CargoVolumeTrim_1 { get; set; }


    public Value_Table_CargoTankUllageTrim(double ull, double Trim4, double Trim3, double Trim2, double Trim1, double Trim0, double Trim_1)
    {
        Ullage = ull;
        CargoVolumeTrim4 = Trim4;
        CargoVolumeTrim3 = Trim3;
        CargoVolumeTrim2 = Trim2;
        CargoVolumeTrim1 = Trim1;
        CargoVolumeTrim0 = Trim0;
        CargoVolumeTrim_1 = Trim_1;

    }
    public override string ToString()
    {
        return Ullage + "\t" + CargoVolumeTrim4 + "\t" + CargoVolumeTrim3 + "\t" + CargoVolumeTrim2 + "\t"
               + CargoVolumeTrim1 + "\t" + CargoVolumeTrim0 + "\t" + CargoVolumeTrim_1;
    }
    public override int GetHashCode()
    {
        return this.ToString().GetHashCode();
    }
}
