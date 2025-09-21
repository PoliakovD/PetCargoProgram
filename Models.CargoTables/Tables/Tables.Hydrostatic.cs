using System.Collections.Generic;
using PetCargoProgram.Models.CargoTables.Values;
using PetCargoProgram.Models.CargoTables.Table;

namespace PetCargoProgram.Models.CargoTables.Tables;

public class Tables_Hydrostatic
{
    public  List<Table_Hydrostatic> Tables { get; set; } = [];

    public void Add(Table_Hydrostatic table) => Tables.Add(table);

}
