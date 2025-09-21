using System.IO;
using PetCargoProgram.Models.CargoTables.Tables;

namespace PetCargoProgram.DataAccess.CargoTables.TablesWriters;

public static class WriterVolume
{

        public static FileStream Write(FileStream fs, BinaryWriter bw, Tables_Volume table)
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
