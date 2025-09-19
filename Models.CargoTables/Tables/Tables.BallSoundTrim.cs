using System.Text;
using Model.CargoTables;
using PetCargoProgram.CargoTables.Values;

namespace PetCargoProgram.CargoTables.Tables;

public class Table_BallSoundTrim : ICargoTable
{
        public string Name { get; set; }
        public List<Value_Table_BallSoundTrim> Table;

        public Table_BallSoundTrim(string name, List<Value_Table_BallSoundTrim> table)
        {
            Name = name;
            Table = table;
        }

        static public void Save_to_file(string initialPath, string finalPath)
        {
            List<Value_Table_BallSoundTrim> cot = new List<Value_Table_BallSoundTrim> { };

            string temp = File.ReadAllText(initialPath);
            string[] temparr = temp.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < temparr.Length; ++i)
            {
                string[] tempUllage = temparr[i].Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                cot.Add(new Value_Table_BallSoundTrim
                {
                    VolumeTrim5 = Convert.ToDouble(tempUllage[0]),
                    VolumeTrim4 = Convert.ToDouble(tempUllage[1]),
                    VolumeTrim3 = Convert.ToDouble(tempUllage[2]),
                    VolumeTrim2 = Convert.ToDouble(tempUllage[3]),
                    VolumeTrim1 = Convert.ToDouble(tempUllage[4]),
                    VolumeTrim0 = Convert.ToDouble(tempUllage[5]),
                    Sound = Convert.ToDouble(tempUllage[6])
                });

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
                        bw.Write(item.VolumeTrim5);
                        bw.Write(item.VolumeTrim4);
                        bw.Write(item.VolumeTrim3);
                        bw.Write(item.VolumeTrim2);
                        bw.Write(item.VolumeTrim1);
                        bw.Write(item.VolumeTrim0);
                        bw.Write(item.Sound);
                    }

                }
            }
        }
        static public List<Value_Table_BallSoundTrim> Read_from_file(string Path)
        {
            List<Value_Table_BallSoundTrim> cot1 = new List<Value_Table_BallSoundTrim> { };

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
                        cot1.Add(new Value_Table_BallSoundTrim
                        {
                            VolumeTrim5 = br.ReadDouble(),
                            VolumeTrim4 = br.ReadDouble(),
                            VolumeTrim3 = br.ReadDouble(),
                            VolumeTrim2 = br.ReadDouble(),
                            VolumeTrim1 = br.ReadDouble(),
                            VolumeTrim0 = br.ReadDouble(),
                            Sound = br.ReadDouble()
                        });
                    }
                }
            }
            return cot1;
        }
        static public void savealltemp()
        {
            string[] input = { "FPT.txt","BWT1P.txt", "BWT1S.txt", "BWT2P.txt", "BWT2S.txt", "BWT3P.txt", "BWT3S.txt"
                              ,"BWT4P.txt","BWT4S.txt","BWT5P.txt","BWT5S.txt","BWT6P.txt","BWT6S.txt","APT.txt"};
            string[] output = {"FPT.bin" , "BWT 1P.bin", "BWT 1S.bin" , "BWT 2P.bin" , "BWT 2S.bin" , "BWT 3P.bin"
            , "BWT 3S.bin" , "BWT 4P.bin" , "BWT 4S.bin", "BWT 5P.bin" , "BWT 5S.bin", "BWT 6P.bin", "BWT 6S.bin" , "APT.bin" };

            for (int i = 0; i < input.Length; ++i)
            {
                Table_BallSoundTrim.Save_to_file(input[i], output[i]);
                var  ResultTable = Table_BallSoundTrim.Read_from_file(output[i]);

            }
        }
        static public List<Table_BallSoundTrim> ReadAllTables()
        {
            var result = new List<Table_BallSoundTrim> { };

            string[] output = {"FPT.bin" , "BWT 1P.bin", "BWT 1S.bin" , "BWT 2P.bin" , "BWT 2S.bin" , "BWT 3P.bin"
            , "BWT 3S.bin" , "BWT 4P.bin" , "BWT 4S.bin", "BWT 5P.bin" , "BWT 5S.bin", "BWT 6P.bin", "BWT 6S.bin" , "APT.bin" };
            foreach (var item in output)
            {
                result.Add(new Table_BallSoundTrim(item.Replace(".bin", ""), Table_BallSoundTrim.Read_from_file(item)));
            }


            return result;
        }
    }
