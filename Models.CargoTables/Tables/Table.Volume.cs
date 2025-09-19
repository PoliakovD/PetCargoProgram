using System.Text;
using Model.CargoTables;
using PetCargoProgram.CargoTables.Values;


public class Table_Volume:ICargoTable
{
     public string Name { get; set; }
        public List<Value_Table_Volume> Table{ get; set; }
        public Table_Volume(string name, List<Value_Table_Volume> table)
        {
            Name = name;
            Table = table;
        }

}
