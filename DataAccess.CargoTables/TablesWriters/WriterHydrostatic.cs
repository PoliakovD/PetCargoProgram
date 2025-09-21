using System.IO;
using PetCargoProgram.Models.CargoTables.Tables;

namespace PetCargoProgram.DataAccess.CargoTables.TablesWriters;

public static class WriterHydrostatic
{
    public static FileStream Write(FileStream fs, BinaryWriter bw, Tables_Hydrostatic table)
    {
        // записываем  Tables_Hydrostatic
        bw.Write(table.Tables.Count);// кол-во таблиц
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
