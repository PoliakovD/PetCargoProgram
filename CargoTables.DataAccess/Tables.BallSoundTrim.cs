using System.Text;
using PetCargoProgram.CargoTables.Tables;
using PetCargoProgram.CargoTables.Values;

namespace PetCargoProgram.DataAccess;

public class Tables_BallSoundTrim
{
    private List<Table_BallSoundTrim> _tables = [];

    public void Add(Table_BallSoundTrim table) => _tables.Add(table);

    public FileStream WriteTables(FileStream fs, BinaryWriter bw)
    {
        // записываем  Tables_BallastTanksSounding
        bw.Write(_tables.Count);// кол-во таблиц
        foreach (var table_BTST in _tables)
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

    public FileStream ReadTables(FileStream fs, BinaryReader br)
    {
        _tables.Clear(); // Очищаем список
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
            _tables.Add(new Table_BallSoundTrim(Temp_Name, Temp_Table));
        }
        return fs;
    }
}
