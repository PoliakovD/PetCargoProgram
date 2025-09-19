namespace PetCargoProgram.CargoTables.Values;

public class Value_Table_Hydrostatic
{
    //DISPLACEMENT MT in SW
    public double displacement { get; set; }
    public double draft { get; set; }
    public double tpc { get; set; }
    //METACENTRE (KM)
    public double metacentrKM { get; set; }
    //CENTRE OF FLOTATION (LCF) Xf from L/2
    public double FloatationCenterLCF { get; set; }
    //MOMENT TO CHANGE TRIM 1 cm (MCTC) midship
    public double MCTC { get; set; }
    // LCB from L/2
    public double LCB { get; set; }

    public double CM { get; set; }
    public Value_Table_Hydrostatic(double disp, double draf, double TPC, double KM, double LCF, double mctc, double lCB, double cM)
    {
        displacement = disp;
        draft = draf;
        tpc = TPC;
        metacentrKM = KM;
        FloatationCenterLCF = LCF;
        MCTC = mctc;
        LCB = lCB;
        CM = cM;
    }
    public override string ToString()
    {
        return displacement + "\t" + draft + "\t" + tpc + "\t" + metacentrKM + "\t" + FloatationCenterLCF + "\t" + MCTC + "\t" + LCB + "\t" + CM;
    }
    public override int GetHashCode()
    {
        return this.ToString().GetHashCode();
    }
}
