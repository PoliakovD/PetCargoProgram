using System.IO;
using PetCargoProgram.Models.CargoTables.Tables;

namespace PetCargoProgram.DataAccess.CargoTables.TablesWriters;

/// <summary>
/// This static class for writing Tables_OtherSounding
/// Contain method  <see cref="Write"/>
/// </summary>
public static class WriterOtherSounding
{
    /// <summary>
    /// Read Tables_OtherSounding in AllCargoTables object
    /// <param name="fs">Output  <see cref="FileStream"/></param>
    /// <param name="br">Output  <see cref="BinaryWriter"/> for writing all required rows from bin file</param>
    /// <param name="allCargoTables">reference on <see cref="AllCargoTables"/> to which object to save <see cref="TablesOtherSounding"/></param>
    /// <returns><see cref="FileStream"/> to continue to write other Tables</returns>
    /// </summary>
    public static FileStream Write(FileStream fs, BinaryWriter bw, TablesOtherSounding table)
    {
        // записываем  Tables_OtherSounding
        bw.Write(table.Tables.Count); // кол-во таблиц
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
