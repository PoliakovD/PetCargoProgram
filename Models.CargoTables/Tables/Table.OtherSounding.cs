using System.Text;
using Model.CargoTables;
using PetCargoProgram.CargoTables.Values;


public class Table_OtherSounding : ICargoTable
{
    public string Name { get; set; }
    public List<Value_Table_OtherSounding> Table { get; set; }

    public Table_OtherSounding(string name, List<Value_Table_OtherSounding> table)
    {
        Name = name;
        Table = table;
    }
}
