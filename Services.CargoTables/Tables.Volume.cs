using System.Text;
using PetCargoProgram.CargoTables.Tables;
using PetCargoProgram.CargoTables.Values;

namespace Services.CargoTables;

public class Tables_Volume
{
    private List<Table_Volume> _tables = [];
    public FileStream WriteTables(FileStream fs, BinaryWriter bw)
    {
        // записываем  Tables_Volume
        bw.Write(this._tables.Count);// кол-во таблиц
        foreach (var table_Vol in this._tables)
        {
            bw.Write(table_Vol.Name); // имя таблицы
            bw.Write(table_Vol.Table.Count); // кол-во записей в таблице
            foreach (var value_Vol in table_Vol.Table)
            {
                // запись данных в файл
                bw.Write(value_Vol.Volume);
                bw.Write(value_Vol.LCG);
                bw.Write(value_Vol.TCG);
                bw.Write(value_Vol.VCG);
                bw.Write(value_Vol.IY);
            }
        }
        return fs;
    }
}
