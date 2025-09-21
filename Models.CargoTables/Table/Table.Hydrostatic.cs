using System.Collections.Generic;
using PetCargoProgram.Models.CargoTables.Values;

namespace PetCargoProgram.Models.CargoTables.Table;



public class Table_Hydrostatic
{
    public string Name { get; set; }
    public List<Value_Table_Hydrostatic> Table { get; set; }

    public Table_Hydrostatic(string name, List<Value_Table_Hydrostatic> table)
    {
        Name = name;
        Table = table;
    }

    public Table_Hydrostatic(Table_Hydrostatic table)
    {
        this.Name = table.Name;;
        this.Table = table.Table;

    }
}
