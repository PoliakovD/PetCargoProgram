using PetCargoProgram.Models.CargoTables.Tables;

namespace PetCargoProgram.DataAccess.CargoTables.TablesWriters;


public class WriterCargoTankUllageTrim
{
    public static FileStream Write(FileStream fs, BinaryWriter bw, Tables_CargoTankUllageTrim table)
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
