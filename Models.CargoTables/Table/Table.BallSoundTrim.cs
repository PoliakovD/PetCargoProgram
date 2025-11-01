using System.Collections.Generic;
using PetCargoProgram.Models.CargoTables.Values;

namespace PetCargoProgram.Models.CargoTables.Table;

/// <summary>
/// BallSoundTrim Table Realised by List of <see cref="ValueTableBallSoundTrim"/>
/// </summary>
public class TableBallSoundTrim
{
    public string Name { get; set; }
    public List<ValueTableBallSoundTrim> Table { get; set; }

    public TableBallSoundTrim(string name, List<ValueTableBallSoundTrim> table)
    {
        Name = name;
        Table = table;
    }
}
