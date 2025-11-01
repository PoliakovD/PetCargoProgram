using System.IO;
using PetCargoProgram.Models.CargoTables.Tables;

namespace PetCargoProgram.DataAccess.CargoTables.TablesWriters;

/// <summary>
/// This static class for writing Tables_Volume
/// Contain method  <see cref="Write"/>
/// </summary>
public static class WriterVolume
{
    /// <summary>
    /// Read Tables_Volume in AllCargoTables object
    /// <param name="fs">Output  <see cref="FileStream"/></param>
    /// <param name="br">Output  <see cref="BinaryWriter"/> for writing all required rows from bin file</param>
    /// <param name="allCargoTables">reference on <see cref="AllCargoTables"/> to which object to save <see cref="TablesVolume"/></param>
    /// <returns><see cref="FileStream"/> to continue to write other Tables</returns>
    /// </summary>
    public static FileStream Write(FileStream fs, BinaryWriter bw, TablesVolume table)
    {
        // записываем  Tables_Volume
        bw.Write(table.Tables.Count); // кол-во таблиц
        foreach (var table_Vol in table.Tables)
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
