namespace PetCargoProgram.Models.CargoTables.Values;

public class ValueTableKN
{
    /// <summary>
    /// Draft Actual in m
    /// </summary>
    public double Draft { get; set; }

    //HEELING ANGLE 0.1
    public double KNonHeelingAngle0_1 { get; set; }
    // HEELING ANGLE 5
    public double KNonHeelingAngle5 { get; set; }
    // HEELING ANGLE 10
    public double KNonHeelingAngle10 { get; set; }
    // HEELING ANGLE 15
    public double KNonHeelingAngle15 { get; set; }
    // HEELING ANGLE 20
    public double KNonHeelingAngle20 { get; set; }
    // HEELING ANGLE 30
    public double KNonHeelingAngle30 { get; set; }
    // HEELING ANGLE 40
    public double KNonHeelingAngle40 { get; set; }
    // HEELING ANGLE 50
    public double KNonHeelingAngle50 { get; set; }
    // HEELING ANGLE 60
    public double KNonHeelingAngle60 { get; set; }
    // HEELING ANGLE 70
    public double KNonHeelingAngle70 { get; set; }
    // HEELING ANGLE 80
    public double KNonHeelingAngle80 { get; set; }
    // HEELING ANGLE 90
    public double KNonHeelingAngle90 { get; set; }

    public ValueTableKN(double draft, double kNonHeelingAngle01, double kNonHeelingAngle5,
        double kNonHeelingAngle10, double kNonHeelingAngle15, double kNonHeelingAngle20, double kNonHeelingAngle30,
        double kNonHeelingAngle40, double kNonHeelingAngle50, double kNonHeelingAngle60, double kNonHeelingAngle70,
        double kNonHeelingAngle80, double kNonHeelingAngle90)
    {
        Draft = draft;
        KNonHeelingAngle0_1 = kNonHeelingAngle01;
        KNonHeelingAngle5 = kNonHeelingAngle5;
        KNonHeelingAngle10 = kNonHeelingAngle10;
        KNonHeelingAngle15 = kNonHeelingAngle15;
        KNonHeelingAngle20 = kNonHeelingAngle20;
        KNonHeelingAngle30 = kNonHeelingAngle30;
        KNonHeelingAngle40 = kNonHeelingAngle40;
        KNonHeelingAngle50 = kNonHeelingAngle50;
        KNonHeelingAngle60 = kNonHeelingAngle60;
        KNonHeelingAngle70 = kNonHeelingAngle70;
        KNonHeelingAngle80 = kNonHeelingAngle80;
        KNonHeelingAngle90 = kNonHeelingAngle90;
    }

}
