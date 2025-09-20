using PetCargoProgram.DataAccess;
using PetCargoProgram.Models.CargoTables;
using PetCargoProgram.Models.CargoTables.Tables;

namespace PetCargoProgram.Services.CargoTables;

public class Services_CargoTables
{
    private  AllCargoTables _allCargoTables;

    public Services_CargoTables()
    {
        Init();
    }
    private void Init()
    {
        _allCargoTables = new AllCargoTables();
        BinaryCTService.Load(ref _allCargoTables);
    }
    public Tables_BallSoundTrim GetBallSoundTrimTables() => _allCargoTables.TablesBallSoundTrim;
    public Tables_CargoTankUllageTrim GetCargoTankUllageTables() => _allCargoTables.TablesCargoTankUllage;
    public Tables_Hydrostatic GetHydrostaticTables() => _allCargoTables.TablesHydrostatic;
    public Tables_OtherSounding GetOtherSoundingTables() => _allCargoTables.TablesOtherSounding;
    public Tables_Volume GetVolumeables() => _allCargoTables.TablesVolume;
}

