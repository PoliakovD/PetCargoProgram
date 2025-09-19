using PetCargoProgram.CargoTables.Values;
using Model.CargoTables;
using System.Text;

namespace PetCargoProgram.CargoTables.Tables;

// TODO Перенести в сервис сурвисную часть
public class Table_CargoTankUllageTrim : ICargoTable
{
        public string Name { get; set; }
        public List<Value_Table_CargoTankUllageTrim> Table;
        public Table_CargoTankUllageTrim(string name, List<Value_Table_CargoTankUllageTrim> table)
        {
            Name = name;
            Table = table;
        }

        static public void TempSaveAll()
        {
            string[] input = { "cot1P.txt", "cot1S.txt", "cot2P.txt", "cot2S.txt", "cot3P.txt", "cot3S.txt", "cot4P.txt",
                "cot4S.txt","cot5P.txt","cot5S.txt","cot6P.txt","cot6S.txt", "SlopP.txt","SlopS.txt" };
            string[] output = { "UllageTrimTableCOT1P.bin", "UllageTrimTableCOT1S.bin", "UllageTrimTableCOT2P.bin", "UllageTrimTableCOT2S.bin",
                "UllageTrimTableCOT3P.bin","UllageTrimTableCOT3S.bin","UllageTrimTableCOT4P.bin","UllageTrimTableCOT4S.bin","UllageTrimTableCOT5P.bin",
                "UllageTrimTableCOT5S.bin","UllageTrimTableCOT6P.bin","UllageTrimTableCOT6S.bin","UllageTrimTableSlopP.bin","UllageTrimTableSlopS.bin"};

            for (int i = 0; i < input.Length; ++i)
            {
                Table_CargoTankUllageTrim.Save_to_file(input[i], output[i]);
                List<Value_Table_CargoTankUllageTrim> cot1 = Table_CargoTankUllageTrim.Read_from_file(output[i]);


            }

        }
        static public void Save_to_file(string initialPath, string finalPath)
        {
            List<Value_Table_CargoTankUllageTrim> cot = new List<Value_Table_CargoTankUllageTrim> { };

            string temp = File.ReadAllText(initialPath);
            string[] temparr = temp.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < temparr.Length; ++i)
            {
                string[] tempUllage = temparr[i].Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                cot.Add(new Value_Table_CargoTankUllageTrim(Convert.ToDouble(tempUllage[0]), Convert.ToDouble(tempUllage[1]), Convert.ToDouble(tempUllage[2]),
                    Convert.ToDouble(tempUllage[3]), Convert.ToDouble(tempUllage[4]), Convert.ToDouble(tempUllage[5]), Convert.ToDouble(tempUllage[6])));

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
                        bw.Write(item.Ullage);
                        bw.Write(item.CargoVolumeTrim4);
                        bw.Write(item.CargoVolumeTrim3);
                        bw.Write(item.CargoVolumeTrim2);
                        bw.Write(item.CargoVolumeTrim1);
                        bw.Write(item.CargoVolumeTrim0);
                        bw.Write(item.CargoVolumeTrim_1);
                    }


                }
            }

        }
        static public List<Value_Table_CargoTankUllageTrim> Read_from_file(string Path)
        {
            List<Value_Table_CargoTankUllageTrim> temp_Table = new List<Value_Table_CargoTankUllageTrim> { };

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
                        temp_Table.Add(new Value_Table_CargoTankUllageTrim(br.ReadDouble(), br.ReadDouble(),
                            br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble()));
                    }
                    // получаем данные из файла
                }
            }
            return temp_Table;
        }
        static public List<Table_CargoTankUllageTrim> ReadAllTables()
        {
            var result = new List<Table_CargoTankUllageTrim> { };

            string[] output = { "COT 1P.bin", "COT 1S.bin", "COT 2P.bin", "COT 2S.bin",
                "COT 3P.bin","COT 3S.bin","COT 4P.bin","COT 4S.bin","COT 5P.bin",
                "COT 5S.bin","COT 6P.bin","COT 6S.bin","SLOP P.bin","SLOP S.bin"};
            foreach (var item in output)
            {
                result.Add(new Table_CargoTankUllageTrim(item.Replace(".bin", ""), Table_CargoTankUllageTrim.Read_from_file(item)));
            }


            return result;
        }

}
