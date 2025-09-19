using System.Text;
using Model.CargoTables;
using PetCargoProgram.CargoTables.Values;

// TODO Перенести в сервис сурвисную часть
public class Table_OtherSounding : ICargoTable
{
     public string Name { get; set; }
        public List<Value_Table_OtherSounding> Table{ get; set; }
        public Table_OtherSounding(string name, List<Value_Table_OtherSounding> table)
        {
            Name = name;
            Table = table;
        }
        static public void Save_to_file(string initialPath, string finalPath)
        {
            List<Value_Table_OtherSounding> cot = new List<Value_Table_OtherSounding> { };

            string temp = File.ReadAllText(initialPath);
            string[] temparr = temp.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < temparr.Length; ++i)
            {
                string[] tempUllage = temparr[i].Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                cot.Add(new Value_Table_OtherSounding(Convert.ToDouble(tempUllage[0]), Convert.ToDouble(tempUllage[1])));

            }


            using (FileStream fs = new FileStream(finalPath,
            FileMode.Create))
            {
                using (BinaryWriter bw =
                new BinaryWriter(fs,
                Encoding.Unicode))
                {
                    bw.Write(cot.Count);
                    foreach (var item in cot)
                    {
                        // запись данных в файл
                        bw.Write(item.volume);
                        bw.Write(item.sound);
                    }
                }
            }
        }
        static public List<Value_Table_OtherSounding> Read_from_file(string Path)
        {
            List<Value_Table_OtherSounding> cot1 = new List<Value_Table_OtherSounding> { };

            using (FileStream fs = new FileStream(Path,
            FileMode.Open))
            {
                using (BinaryReader br =
                new BinaryReader(fs,
                Encoding.Unicode))
                {
                    int count = br.ReadInt32();
                    for (int i = 0; i < count; ++i)
                    {
                        cot1.Add(new Value_Table_OtherSounding(br.ReadDouble(), br.ReadDouble()));
                    }
                    // получаем данные из файла
                }
            }
            return cot1;
        }
        static public void savealltemp()
        {
            string[] input = { "FWTP.txt", "FWTS.txt", "DWTS.txt", "FOTP.txt", "FOTS.txt", "DOTS.txt" };
            string[] output = { "FWTP.bin", "FWTS.bin", "DWTS.bin", "FOTP.bin", "FOTS.bin", "DOTS.bin", };

            for (int i = 0; i < input.Length; ++i)
            {
                Table_OtherSounding.Save_to_file(input[i], output[i]);
                List<Value_Table_OtherSounding> cot1 = Table_OtherSounding.Read_from_file(output[i]);

            }
        }
        static public List<Table_OtherSounding> ReadAllTables()
        {
            var result = new List<Table_OtherSounding> { };

            string[] output = { "FWT P.bin", "FWT S.bin", "DWT S.bin", "FOT P.bin", "FOT S.bin", "DOT S.bin", };

            foreach (var item in output)
            {
                result.Add(new Table_OtherSounding(item.Replace(".bin", ""), Table_OtherSounding.Read_from_file(item)));
            }


            return result;
        }
}
