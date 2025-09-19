using PetCargoProgram.Models.CargoTables.Values;
using PetCargoProgram.Models.CargoTables.Table;

namespace PetCargoProgram.Models.CargoTables.Tables;

public class Tables_OtherSounding
{
    private List<Table_OtherSounding> _tables = [];
    public void Add(Table_OtherSounding table) => _tables.Add(table);
    public FileStream WriteTables(FileStream fs, BinaryWriter bw)
    {
        // записываем  Tables_OtherSounding
        bw.Write(_tables.Count);// кол-во таблиц
        foreach (var table_OS in _tables)
        {
            bw.Write(table_OS.Name); // имя таблицы
            bw.Write(table_OS.Table.Count); // кол-во записей в таблице
            foreach (var value_OS in table_OS.Table)
            {
                // запись данных в файл
                bw.Write(value_OS.volume);
                bw.Write(value_OS.sound);
            }
        }
        return fs;
    }
    public FileStream ReadTables(FileStream fs, BinaryReader br)
    {
        _tables.Clear(); // Очищаем список

        // считываем кол-во Tables_OtherSounding
        int count_OS = br.ReadInt32();

        for (int i = 0; i < count_OS; ++i)
        {
            var Temp_Name = br.ReadString(); // записываем имя таблицы
            var Temp_Table = new List<Value_Table_OtherSounding> { };

            // считываем кол-во значений в Table_OtherSounding
            int count_TableValues = br.ReadInt32();
            for (int j = 0; j < count_TableValues; ++j)
            {
                Temp_Table.Add(new Value_Table_OtherSounding(br.ReadDouble(), br.ReadDouble()));
            }
            // Добавляем таблицу в список таблиц
            _tables.Add(new Table_OtherSounding(Temp_Name, Temp_Table));
        }
        return fs;
    }
}
