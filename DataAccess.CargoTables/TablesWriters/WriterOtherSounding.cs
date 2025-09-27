using System.IO;
using PetCargoProgram.Models.CargoTables.Tables;

namespace PetCargoProgram.DataAccess.CargoTables.TablesWriters;

public static class WriterOtherSounding
{
    public static FileStream Write(FileStream fs, BinaryWriter bw, Tables_OtherSounding table)
    {
        // записываем  Tables_OtherSounding
        bw.Write(table.Tables.Count);// кол-во таблиц
        foreach (var table_OS in table.Tables)
        {
            bw.Write(table_OS.Name); // имя таблицы
            bw.Write(table_OS.Table.Count); // кол-во записей в таблице
            foreach (var value_OS in table_OS.Table)
            {
                // запись данных в файл
                bw.Write(value_OS.Volume);
                bw.Write(value_OS.Sound);
            }
        }
        return fs;
    }
}
