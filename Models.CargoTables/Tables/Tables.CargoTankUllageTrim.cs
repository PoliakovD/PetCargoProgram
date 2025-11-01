using System.Collections.Generic;
using PetCargoProgram.Models.CargoTables.Values;
using PetCargoProgram.Models.CargoTables.Table;

namespace PetCargoProgram.Models.CargoTables.Tables;

/// <summary>
/// Incapsulates all <see cref="TableCargoTankUllageTrim"/>
/// </summary>
public class TablesCargoTankUllageTrim
{
    public List<TableCargoTankUllageTrim> Tables { get; set; } = [];

    public void Add(TableCargoTankUllageTrim table) => Tables.Add(table);
}
