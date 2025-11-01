using System.Collections.Generic;
using PetCargoProgram.Models.CargoTables.Values;
using PetCargoProgram.Models.CargoTables.Table;

namespace PetCargoProgram.Models.CargoTables.Tables;

/// <summary>
/// Incapsulates all <see cref="TableVolume"/>
/// </summary>
public class TablesVolume
{
    public List<TableVolume> Tables { get; set; } = [];

    public void Add(TableVolume table) => Tables.Add(table);
}
