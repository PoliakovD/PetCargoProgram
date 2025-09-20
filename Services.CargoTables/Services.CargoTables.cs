using PetCargoProgram.Models.CargoTables.Tables;

namespace Services.CargoTables;

public class Services_CargoTables
{
    public Tables_BallSoundTrim? TablesBallSoundTrim { get; set; }
    public Tables_CargoTankUllageTrim? TablesCargoTankUllage { get; set; }
    public Tables_Hydrostatic? TablesHydrostatic { get; set; }
    public Tables_OtherSounding? TablesOtherSounding { get; set; }
    public Tables_Volume? TablesVolume { get; set; }
}
