using System.Collections.Generic;
using PetCargoProgram.Models.CargoTables.Values;

namespace PetCargoProgram.Models.CargoTables.Table;

/// <summary>
/// BallSoundTrim Table Realised by List of <see cref="ValueTableHydrostatic"/>
/// </summary>
public class TableHydrostatic
{
    public string Name { get; set; }
    public List<ValueTableHydrostatic> Table { get; set; }

    public TableHydrostatic(string name, List<ValueTableHydrostatic> table)
    {
        Name = name;
        Table = table;
    }
}
