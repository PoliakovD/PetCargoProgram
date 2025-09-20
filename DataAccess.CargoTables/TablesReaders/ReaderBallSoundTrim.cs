using PetCargoProgram.Models.CargoTables;
using PetCargoProgram.Models.CargoTables.Table;
using PetCargoProgram.Models.CargoTables.Tables;
using PetCargoProgram.Models.CargoTables.Values;

namespace PetCargoProgram.DataAccess.CargoTables.TablesReaders;

public static class ReaderBallSoundTrim
{
    public static FileStream Read(FileStream fs, BinaryReader br,  ref AllCargoTables allCargoTables)
    {
        if( allCargoTables.TablesBallSoundTrim.Tables is not null)
            allCargoTables.TablesBallSoundTrim.Tables.Clear(); // Очищаем список


         // считываем кол-во Tables_BallastTanksSounding
         int count_tablesBTST = br.ReadInt32();

         for (int i = 0; i < count_tablesBTST; ++i)
         {
             var Temp_Name = br.ReadString(); // записываем имя таблицы
             var Temp_Table = new List<Value_Table_BallSoundTrim> { };

             // считываем кол-во значений в Table_BallastTankSoundingTrim
             int count_TableValues = br.ReadInt32();
             for (int j = 0; j < count_TableValues; ++j)
             {
                 Temp_Table.Add(new Value_Table_BallSoundTrim(br.ReadDouble(), br.ReadDouble(),
                     br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble()));
             }
             // Добавляем таблицу в список таблиц
             allCargoTables.TablesBallSoundTrim.Tables.Add(new Table_BallSoundTrim(Temp_Name, Temp_Table));
         }
         return fs;
    }
}
