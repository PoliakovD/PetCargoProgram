namespace PetCargoProgram.Models.CargoTables.Values;

/// <summary>
/// Hydrostatic table value
/// </summary>
public class ValueTableHydrostatic
{
    /// <summary>
    /// Displacement in tonnes in Salt Water
    /// </summary>
    public double Displacement { get; set; }
    /// <summary>
    /// Draft in meters
    /// </summary>
    public double Draft { get; set; }
    /// <summary>
    /// Tones per centimeter of draft
    /// </summary>
    public double TPC { get; set; }
    /// <summary>
    /// KM - Metacentre in meters
    /// </summary>
    public double MetacentrKM { get; set; }
    /// <summary>
    /// LCF Centre of flotation from L/2 in meters
    /// </summary>
    public double FloatationCenterLCF { get; set; }
    /// <summary>
    /// MCTC MOMENT TO CHANGE TRIM 1 cm (MCTC) midship
    /// </summary>
    public double MCTC { get; set; }
    /// <summary>
    /// LCB from L/2
    /// </summary>
    public double LCB { get; set; }
    /// <summary>
    /// CM
    /// </summary>
    public double CM { get; set; }
    public ValueTableHydrostatic(double disp, double draft, double tpc, double KM, double LCF, double mctc, double lCB, double cM)
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
