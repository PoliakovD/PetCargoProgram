namespace PetCargoProgram.Models.CargoTables.Values;

public class Value_Table_Hydrostatic
{
    //DISPLACEMENT MT in SW
    public double Displacement { get; set; }
    public double Draft { get; set; }
    public double TPC { get; set; }
    //METACENTRE (KM)
    public double MetacentrKM { get; set; }
    //CENTRE OF FLOTATION (LCF) Xf from L/2
    public double FloatationCenterLCF { get; set; }
    //MOMENT TO CHANGE TRIM 1 cm (MCTC) midship
    public double MCTC { get; set; }
    // LCB from L/2
    public double LCB { get; set; }

    public double CM { get; set; }
    public Value_Table_Hydrostatic(double disp, double draft, double tpc, double KM, double LCF, double mctc, double lCB, double cM)
    {
        Displacement = disp;
        Draft = draft;
        TPC = tpc;
        MetacentrKM = KM;
        FloatationCenterLCF = LCF;
        MCTC = mctc;
        LCB = lCB;
        CM = cM;
    }
    public override string ToString()
    {
        return Displacement + "\t" + Draft + "\t" + TPC + "\t" + MetacentrKM + "\t" + FloatationCenterLCF + "\t" + MCTC + "\t" + LCB + "\t" + CM;
    }
    public override int GetHashCode()
    {
        return this.ToString().GetHashCode();
    }
}
