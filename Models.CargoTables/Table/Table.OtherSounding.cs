using System.Collections.Generic;
using PetCargoProgram.Models.CargoTables.Values;

namespace PetCargoProgram.Models.CargoTables.Table;

/// <summary>
/// BallSoundTrim Table Realised by List of <see cref="ValueTableOtherSounding"/>
/// </summary>
public class TableOtherSounding
{
    public string Name { get; set; }
    public List<ValueTableOtherSounding> Table { get; set; }

    public TableOtherSounding(string name, List<ValueTableOtherSounding> table)
    {
        Name = name;
        Table = table;
    }
}
