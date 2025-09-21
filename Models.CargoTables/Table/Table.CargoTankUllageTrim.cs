using System.Collections.Generic;
using PetCargoProgram.Models.CargoTables.Values;

namespace PetCargoProgram.Models.CargoTables.Table;



public class Table_CargoTankUllageTrim
{
        public string Name { get; set; }
        public List<Value_Table_CargoTankUllageTrim> Table{ get; set; }
        public Table_CargoTankUllageTrim(string name, List<Value_Table_CargoTankUllageTrim> table)
        {
            Name = name;
            Table = table;
        }

}
