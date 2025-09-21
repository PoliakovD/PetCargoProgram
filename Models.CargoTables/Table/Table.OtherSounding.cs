using System.Collections.Generic;
using PetCargoProgram.Models.CargoTables.Values;

namespace PetCargoProgram.Models.CargoTables.Table;



public class Table_OtherSounding
{
    public string Name { get; set; }
    public List<Value_Table_OtherSounding> Table { get; set; }

    public Table_OtherSounding(string name, List<Value_Table_OtherSounding> table)
    {
        Name = name;
        Table = table;
    }
}
