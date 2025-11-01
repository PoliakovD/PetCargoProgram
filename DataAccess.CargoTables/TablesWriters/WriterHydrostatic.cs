using System.IO;
using PetCargoProgram.Models.CargoTables.Tables;

namespace PetCargoProgram.DataAccess.CargoTables.TablesWriters;

/// <summary>
/// This static class for writing Tables_Hydrostatic
/// Contain method  <see cref="Write"/>
/// </summary>
public static class WriterHydrostatic
{
    /// <summary>
    /// Read Tables_Hydrostatic in AllCargoTables object
    /// <param name="fs">Output  <see cref="FileStream"/></param>
    /// <param name="br">Output  <see cref="BinaryWriter"/> for writing all required rows from bin file</param>
    /// <param name="allCargoTables">reference on <see cref="AllCargoTables"/> to which object to save <see cref="TablesHydrostatic"/></param>
    /// <returns><see cref="FileStream"/> to continue to write other Tables</returns>
    /// </summary>
    public static FileStream Write(FileStream fs, BinaryWriter bw, TablesHydrostatic table)
    {
        // записываем  Tables_Hydrostatic
        bw.Write(table.Tables.Count); // кол-во таблиц
        foreach (var table_Hydro in table.Tables)
        {
            bw.Write(table_Hydro.Name); // имя таблицы
            bw.Write(table_Hydro.Table.Count); // кол-во записей в таблице
            foreach (var value_Hydro in table_Hydro.Table)
            {
                // запись данных в файл
                bw.Write(value_Hydro.Displacement);
                bw.Write(value_Hydro.Draft);
                bw.Write(value_Hydro.TPC);
                bw.Write(value_Hydro.MetacentrKM);
                bw.Write(value_Hydro.FloatationCenterLCF);
                bw.Write(value_Hydro.MCTC);
                bw.Write(value_Hydro.LCB);
                bw.Write(value_Hydro.CM);
            }
        }

        return fs;
    }
}
