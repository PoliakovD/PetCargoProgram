using System.Collections.Generic;
using PetCargoProgram.Models.CargoTables.Values;
using PetCargoProgram.Models.CargoTables.Table;

namespace PetCargoProgram.Models.CargoTables.Tables;

/// <summary>
/// Incapsulates all <see cref="TableOtherSounding"/>
/// </summary>
public class TablesOtherSounding
{
    public List<TableOtherSounding> Tables { get; set; } = [];

    public void Add(TableOtherSounding table) => Tables.Add(table);

}
