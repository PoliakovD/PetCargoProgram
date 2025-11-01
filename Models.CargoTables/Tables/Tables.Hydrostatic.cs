using System.Collections.Generic;
using PetCargoProgram.Models.CargoTables.Values;
using PetCargoProgram.Models.CargoTables.Table;

namespace PetCargoProgram.Models.CargoTables.Tables;

/// <summary>
/// Incapsulates all <see cref="TableHydrostatic"/>
/// </summary>
public class TablesHydrostatic
{
    public List<TableHydrostatic> Tables { get; set; } = [];

    public void Add(TableHydrostatic table) => Tables.Add(table);
}
