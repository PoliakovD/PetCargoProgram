using System.Text;
using Model.CargoTables;
using PetCargoProgram.Models.CargoTables.Values;

namespace PetCargoProgram.Models.CargoTables.Table;



public class Table_BallSoundTrim
{
    public string Name { get; set; }
    public List<Value_Table_BallSoundTrim> Table { get; set; }

    public Table_BallSoundTrim(string name, List<Value_Table_BallSoundTrim> table)
    {
        Name = name;
        Table = table;
    }
}
