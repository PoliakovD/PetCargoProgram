namespace PetCargoProgram.Models.ShipCondition;

public class ShipCondition
{
    public double LightWeight {get; set;}
    public double DeadWeight{get; set;}
    public double Displacement{get; set;}
    public double DeadWeightRegistred{get; set;}

    public double CargoOnBoard{get; set;}
    public double BallasrOnBoard{get; set;}
    public double FuelOilOnBoard{get; set;}
    public double DieselOnBoard{get; set;}
    public double FreshWaterOnBoard{get; set;}
    public double LubeOilOnBoard{get; set;}

    public double DraftAft{get; set;}
    public double DraftAftPependicular{get; set;}
    public double DraftFwd{get; set;}
    public double DraftFwdPependicular{get; set;}
    public double DraftMean{get; set;}

    public double TCG{get; set;}
    public double LCG{get; set;}
    public double VCG{get; set;}
    public double Gm {get; set;}
    public double Gom {get; set;}

    public double ShearingForce{get; set;}
    public double BendingMoment{get; set;}
}
