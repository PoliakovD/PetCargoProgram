using System.Text;
using Model.CargoTables;
using PetCargoProgram.CargoTables.Values;

namespace PetCargoProgram.CargoTables.Tables;


public class Table_Hydrostatic : ICargoTable
{
    public string Name { get; set; }
    public List<Value_Table_Hydrostatic> Table { get; set; }

    public Table_Hydrostatic(string name, List<Value_Table_Hydrostatic> table)
    {
        Name = name;
        Table = table;
    }
}
