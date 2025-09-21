using System.Collections.Generic;
using System.IO;
using PetCargoProgram.Models.CargoTables;
using PetCargoProgram.Models.CargoTables.Table;
using PetCargoProgram.Models.CargoTables.Tables;
using PetCargoProgram.Models.CargoTables.Values;

namespace PetCargoProgram.DataAccess.CargoTables.TablesReaders;

public class ReaderCargoTankUllageTrim
{
    public static FileStream Read(FileStream fs, BinaryReader br,  ref AllCargoTables allCargoTables)
    {
        allCargoTables.TablesCargoTankUllage.Tables.Clear(); // Очищаем список

        // считываем кол-во Tables_CargoTanksUllage
        int count_tablesCTU = br.ReadInt32();

        for (int i = 0; i < count_tablesCTU; ++i)
        {
            var Temp_Name = br.ReadString(); // записываем имя таблицы
            var Temp_Table = new List<Value_Table_CargoTankUllageTrim> { };

            // считываем кол-во значений в Table_CargoTankUllageTrim
            int count_TableValues = br.ReadInt32();
            for (int j = 0; j < count_TableValues; ++j)
            {
                Temp_Table.Add(new Value_Table_CargoTankUllageTrim(br.ReadDouble(), br.ReadDouble(),
                    br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble()));
            }
            // Добавляем таблицу в список таблиц
            allCargoTables.TablesCargoTankUllage.Tables.Add(new Table_CargoTankUllageTrim(Temp_Name, Temp_Table));
        }
        return fs;
    }
}
