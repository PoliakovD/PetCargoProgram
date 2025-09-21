using System.IO;
using PetCargoProgram.Models.CargoTables.Tables;

namespace PetCargoProgram.DataAccess.CargoTables.TablesWriters;

public static class WriterBallSoundTrim
{
    public static FileStream Write(FileStream fs, BinaryWriter bw, Tables_BallSoundTrim table)
    {
        // записываем  Tables_BallastTanksSounding
        bw.Write(table.Tables.Count);// кол-во таблиц
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
