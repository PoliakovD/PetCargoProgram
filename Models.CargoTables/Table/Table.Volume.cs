using System.Collections.Generic;
using PetCargoProgram.Models.CargoTables.Values;

namespace PetCargoProgram.Models.CargoTables.Table;

/// <summary>
/// BallSoundTrim Table Realised by List of <see cref="ValueTableVolume"/>
/// </summary>
public class TableVolume
{
    public string Name { get; set; }
    public List<ValueTableVolume> Table { get; set; }

    public TableVolume(string name, List<ValueTableVolume> table)
    {
        Name = name;
        Table = table;
    }
}
