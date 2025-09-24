using PetCargoProgram.Models.CargoTables.Tables;

namespace PetCargoProgram.Models.CargoTables;

public class AllCargoTables
{
    public Tables_BallSoundTrim TablesBallSoundTrim { get; set; }
    public Tables_CargoTankUllageTrim TablesCargoTankUllage { get; set; }
    public Tables_Hydrostatic TablesHydrostatic { get; set; }
    public Tables_OtherSounding TablesOtherSounding { get; set; }
    public Tables_Volume TablesVolume { get; set; }

    public AllCargoTables()
    {

        TablesBallSoundTrim = new Tables_BallSoundTrim();
        TablesCargoTankUllage = new Tables_CargoTankUllageTrim();
        TablesHydrostatic = new Tables_Hydrostatic();
        TablesOtherSounding = new Tables_OtherSounding();
        TablesVolume = new Tables_Volume();
    }
}

