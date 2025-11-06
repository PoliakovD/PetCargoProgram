using PetCargoProgram.Models.CargoTables.Tables;

namespace PetCargoProgram.Models.CargoTables;

/// <summary>
/// Encapsulate all cargo tables in one class
/// </summary>
public class AllCargoTables
{
    public TablesBallSoundTrim TablesBallSoundTrim { get; set; }
    public TablesCargoTankUllageTrim TablesCargoTankUllage { get; set; }
    public TablesHydrostatic TablesHydrostatic { get; set; }
    public TablesOtherSounding TablesOtherSounding { get; set; }
    public TablesVolume TablesVolume { get; set; }
    public TableKN TableKn{ get; set; }

    public AllCargoTables()
    {
        TablesBallSoundTrim = new TablesBallSoundTrim();
        TablesCargoTankUllage = new TablesCargoTankUllageTrim();
        TablesHydrostatic = new TablesHydrostatic();
        TablesOtherSounding = new TablesOtherSounding();
        TablesVolume = new TablesVolume();
        TableKn = new TableKN();
    }
}
