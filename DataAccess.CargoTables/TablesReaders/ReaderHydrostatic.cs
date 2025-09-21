using System.Collections.Generic;
using System.IO;
using PetCargoProgram.Models.CargoTables;
using PetCargoProgram.Models.CargoTables.Table;
using PetCargoProgram.Models.CargoTables.Tables;
using PetCargoProgram.Models.CargoTables.Values;

namespace PetCargoProgram.DataAccess.CargoTables.TablesReaders;

public static class ReaderHydrostatic
{
    public static FileStream Read(FileStream fs, BinaryReader br,  ref AllCargoTables allCargoTables)
    {
        allCargoTables.TablesHydrostatic.Tables.Clear(); // Очищаем список

        // считываем кол-во Tables_Hydrostatic
        int count_tablesHydro = br.ReadInt32();

        for (int i = 0; i < count_tablesHydro; ++i)
        {
            var Temp_Name = br.ReadString(); // записываем имя таблицы
            var Temp_Table = new List<Value_Table_Hydrostatic> { };

            // считываем кол-во значений в Table_Hydrostatic
            int count_TableValues = br.ReadInt32();
            for (int j = 0; j < count_TableValues; ++j)
            {
                Temp_Table.Add(new Value_Table_Hydrostatic(br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble()));
            }
            // Добавляем таблицу в список таблиц
            allCargoTables.TablesHydrostatic.Tables.Add(new Table_Hydrostatic(Temp_Name, Temp_Table));
        }
        return fs;
    }

}
