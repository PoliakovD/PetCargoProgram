using System.Collections.Generic;
using PetCargoProgram.Models.CargoTables.Values;

namespace PetCargoProgram.Models.CargoTables.Table;

/// <summary>
/// BallSoundTrim Table Realised by List of <see cref="ValueTableCargoTankUllageTrim"/>
/// </summary>
public class TableCargoTankUllageTrim
{
    public string Name { get; set; }
    public List<ValueTableCargoTankUllageTrim> Table { get; set; }

    public TableCargoTankUllageTrim(string name, List<ValueTableCargoTankUllageTrim> table)
    {
        Name = name;
        Table = table;
    }
}
