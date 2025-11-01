using System.Collections.Generic;
using PetCargoProgram.Models.CargoTables.Values;
using PetCargoProgram.Models.CargoTables.Table;

namespace PetCargoProgram.Models.CargoTables.Tables;

/// <summary>
/// Incapsulates all <see cref="TableBallSoundTrim"/>
/// </summary>
public class TablesBallSoundTrim
{
    public List<TableBallSoundTrim> Tables { get; set; } = [];
    public void Add(TableBallSoundTrim table) => Tables.Add(table);
}
