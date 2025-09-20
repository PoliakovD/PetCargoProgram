using PetCargoProgram.Models.CargoTables;
using PetCargoProgram.Models.CargoTables.Table;
using PetCargoProgram.Models.CargoTables.Tables;
using PetCargoProgram.Models.CargoTables.Values;

namespace PetCargoProgram.DataAccess.CargoTables.TablesReaders;

public static class ReaderVolume
{
    public static FileStream Read(FileStream fs, BinaryReader br,  ref AllCargoTables allCargoTables)
    {
        allCargoTables.TablesVolume.Tables.Clear(); // Очищаем список
        // считываем кол-во Tables_Volume
         int count_Vol = br.ReadInt32();

         for (int i = 0; i < count_Vol; ++i)
         {
             var Temp_Name = br.ReadString(); // записываем имя таблицы
             var Temp_Table = new List<Value_Table_Volume> { };

             // считываем кол-во значений в Table_OtherSounding
             int count_TableValues = br.ReadInt32();
             for (int j = 0; j < count_TableValues; ++j)
             {
                 Temp_Table.Add(new Value_Table_Volume(br.ReadDouble(), br.ReadDouble(),
                     br.ReadDouble(), br.ReadDouble(), br.ReadDouble()));
             }
             // Добавляем таблицу в список таблиц
             allCargoTables.TablesVolume.Tables.Add(new Table_Volume(Temp_Name, Temp_Table));
         }
         return fs;
    }
}
