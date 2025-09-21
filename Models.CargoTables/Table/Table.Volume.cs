using System.Collections.Generic;
using PetCargoProgram.Models.CargoTables.Values;

namespace PetCargoProgram.Models.CargoTables.Table;



public class Table_Volume
{
     public string Name { get; set; }
        public List<Value_Table_Volume> Table{ get; set; }
        public Table_Volume(string name, List<Value_Table_Volume> table)
        {
            Name = name;
            Table = table;
        }

}
