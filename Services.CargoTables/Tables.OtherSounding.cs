using System.Text;
using PetCargoProgram.CargoTables.Tables;
using PetCargoProgram.CargoTables.Values;

namespace Services.CargoTables;

public class Tables_OtherSounding
{
    private List<Table_OtherSounding> _tables = [];
    public FileStream WriteTables(FileStream fs, BinaryWriter bw)
    {
        // записываем  Tables_OtherSounding
        bw.Write(_tables.Count);// кол-во таблиц
        foreach (var table_OS in _tables)
        {
            bw.Write(table_OS.Name); // имя таблицы
            bw.Write(table_OS.Table.Count); // кол-во записей в таблице
            foreach (var value_OS in table_OS.Table)
            {
                // запись данных в файл
                bw.Write(value_OS.volume);
                bw.Write(value_OS.sound);
            }
        }
        return fs;
    }
}
