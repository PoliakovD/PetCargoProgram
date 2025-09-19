using PetCargoProgram.CargoTables.Values;
using Model.CargoTables;
using System.Text;

namespace PetCargoProgram.CargoTables.Tables;

// TODO Перенести в сервис сурвисную часть
public class Table_CargoTankUllageTrim : ICargoTable
{
        public string Name { get; set; }
        public List<Value_Table_CargoTankUllageTrim> Table{ get; set; }
        public Table_CargoTankUllageTrim(string name, List<Value_Table_CargoTankUllageTrim> table)
        {
            Name = name;
            Table = table;
        }

}
