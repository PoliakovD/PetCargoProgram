using System.IO;
using PetCargoProgram.Models.CargoTables.Tables;
using PetCargoProgram.Models.CargoTables;

namespace PetCargoProgram.DataAccess.CargoTables.TablesWriters;

/// <summary>
/// This static class for writing Tables_BallSoundTrim
/// Contain method  <see cref="Write"/>
/// </summary>
public static class WriterBallSoundTrim
{
    /// <summary>
    /// Read Tables_BallSoundTrim in AllCargoTables object
    /// <param name="fs">Output  <see cref="FileStream"/></param>
    /// <param name="br">Output  <see cref="BinaryWriter"/> for writing all required rows from bin file</param>
    /// <param name="allCargoTables">reference on <see cref="AllCargoTables"/> to which object to save <see cref="TablesBallSoundTrim"/></param>
    /// <returns><see cref="FileStream"/> to continue to write other Tables</returns>
    /// </summary>
    public static FileStream Write(FileStream fs, BinaryWriter bw, TablesBallSoundTrim table)
    {
        // записываем  Tables_BallastTanksSounding
        bw.Write(table.Tables.Count); // кол-во таблиц
        foreach (var table_BTST in table.Tables)
        {
            bw.Write(table_BTST.Name); // имя таблицы
            bw.Write(table_BTST.Table.Count); // кол-во записей в таблице
            foreach (var value_BTST in table_BTST.Table)
            {
                // запись данных в файл
                bw.Write(value_BTST.VolumeTrim5);
                bw.Write(value_BTST.VolumeTrim4);
                bw.Write(value_BTST.VolumeTrim3);
                bw.Write(value_BTST.VolumeTrim2);
                bw.Write(value_BTST.VolumeTrim1);
                bw.Write(value_BTST.VolumeTrim0);
                bw.Write(value_BTST.Sound);
            }
        }

        return fs;
    }
}
