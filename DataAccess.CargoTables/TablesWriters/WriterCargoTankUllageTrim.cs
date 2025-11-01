using System.IO;
using PetCargoProgram.Models.CargoTables.Tables;

namespace PetCargoProgram.DataAccess.CargoTables.TablesWriters;

/// <summary>
/// This static class for writing Tables_CargoTankUllageTrim
/// Contain method  <see cref="Write"/>
/// </summary>
public class WriterCargoTankUllageTrim
{
    /// <summary>
    /// Read Tables_CargoTankUllageTrim in AllCargoTables object
    /// <param name="fs">Output  <see cref="FileStream"/></param>
    /// <param name="br">Output  <see cref="BinaryWriter"/> for writing all required rows from bin file</param>
    /// <param name="allCargoTables">reference on <see cref="AllCargoTables"/> to which object to save <see cref="TablesCargoTankUllageTrim"/></param>
    /// <returns><see cref="FileStream"/> to continue to write other Tables</returns>
    /// </summary>
    public static FileStream Write(FileStream fs, BinaryWriter bw, TablesCargoTankUllageTrim table)
    {
        // записываем  Table_CargoTankUllageTrim
        bw.Write(table.Tables.Count); // кол-во таблиц
        foreach (var table_BTST in table.Tables)
        {
            bw.Write(table.Tables.Count); // кол-во таблиц
            foreach (var table_CTU in table.Tables)
            {
                bw.Write(table_CTU.Name); // имя таблицы
                bw.Write(table_CTU.Table.Count); // кол-во записей в таблице
                foreach (var value_CTU in table_CTU.Table)
                {
                    // запись данных в файл
                    bw.Write(value_CTU.Ullage);
                    bw.Write(value_CTU.CargoVolumeTrim4);
                    bw.Write(value_CTU.CargoVolumeTrim3);
                    bw.Write(value_CTU.CargoVolumeTrim2);
                    bw.Write(value_CTU.CargoVolumeTrim1);
                    bw.Write(value_CTU.CargoVolumeTrim0);
                    bw.Write(value_CTU.CargoVolumeTrim_1);
                }
            }
        }

        return fs;
    }
}
