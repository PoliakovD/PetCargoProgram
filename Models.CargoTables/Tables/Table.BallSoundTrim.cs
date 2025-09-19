using System.Text;
using Model.CargoTables;
using PetCargoProgram.CargoTables.Values;

namespace PetCargoProgram.CargoTables.Tables;



public class Table_BallSoundTrim : ICargoTable
{
    public string Name { get; set; }
    public List<Value_Table_BallSoundTrim> Table { get; set; }

    public Table_BallSoundTrim(string name, List<Value_Table_BallSoundTrim> table)
    {
        Name = name;
        Table = table;
    }
}
