using System.IO;
using System.Text;

namespace PetCargoProgram.CargoTables
{
    public class Table_BallastTankSoundingTrim
    {
        public string Name { get; set; }
        public List<Value_Table_BallastSoundingTrim> Table;

        public Table_BallastTankSoundingTrim(string name, List<Value_Table_BallastSoundingTrim> table)
        {
            Name = name;
            Table = table;
        }
        public class Value_Table_BallastSoundingTrim
        {
            public double VolumeTrim5 { get; set; }
            public double VolumeTrim4 { get; set; }
            public double VolumeTrim3 { get; set; }
            public double VolumeTrim2 { get; set; }
            public double VolumeTrim1 { get; set; }
            public double VolumeTrim0 { get; set; }
            public double sound { get; set; }
            public Value_Table_BallastSoundingTrim(double Trim5, double Trim4, double Trim3, double Trim2, double Trim1, double Trim0, double Sound)
            {
                VolumeTrim5 = Trim5;
                VolumeTrim4 = Trim4;
                VolumeTrim3 = Trim3;
                VolumeTrim2 = Trim2;
                VolumeTrim1 = Trim1;
                VolumeTrim0 = Trim0;
                sound = Sound;

            }
            public override string ToString()
            {
                return VolumeTrim5 + "\t" + VolumeTrim4 + "\t" + VolumeTrim3 + "\t" + VolumeTrim2 +
                    "\t" + VolumeTrim1 + "\t" + VolumeTrim0 + "\t" + sound;
            }
        }
        static public void Save_to_file(string initialPath, string finalPath)
        {
            List<Value_Table_BallastSoundingTrim> cot = new List<Value_Table_BallastSoundingTrim> { };

            string temp = File.ReadAllText(initialPath);
            string[] temparr = temp.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < temparr.Length; ++i)
            {
                string[] tempUllage = temparr[i].Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                cot.Add(new Value_Table_BallastSoundingTrim(Convert.ToDouble(tempUllage[0]), Convert.ToDouble(tempUllage[1]), Convert.ToDouble(tempUllage[2]),
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
                        bw.Write(item.VolumeTrim5);
                        bw.Write(item.VolumeTrim4);
                        bw.Write(item.VolumeTrim3);
                        bw.Write(item.VolumeTrim2);
                        bw.Write(item.VolumeTrim1);
                        bw.Write(item.VolumeTrim0);
                        bw.Write(item.sound);
                    }

                }
            }
        }
        static public List<Value_Table_BallastSoundingTrim> Read_from_file(string Path)
        {
            List<Value_Table_BallastSoundingTrim> cot1 = new List<Value_Table_BallastSoundingTrim> { };

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
                        cot1.Add(new Value_Table_BallastSoundingTrim(br.ReadDouble(), br.ReadDouble(),
                            br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble()));
                    }
                    // получаем данные из файла
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
                Table_CargoTankUllageTrim.Save_to_file(input[i], output[i]);
                List<Table_BallastTankSoundingTrim.Value_Table_BallastSoundingTrim> cot1 = Table_BallastTankSoundingTrim.Read_from_file(output[i]);

            }
        }
        static public List<Table_BallastTankSoundingTrim> ReadAllTables()
        {
            var result = new List<Table_BallastTankSoundingTrim> { };

            string[] output = {"FPT.bin" , "BWT 1P.bin", "BWT 1S.bin" , "BWT 2P.bin" , "BWT 2S.bin" , "BWT 3P.bin"
            , "BWT 3S.bin" , "BWT 4P.bin" , "BWT 4S.bin", "BWT 5P.bin" , "BWT 5S.bin", "BWT 6P.bin", "BWT 6S.bin" , "APT.bin" };
            foreach (var item in output)
            {
                result.Add(new Table_BallastTankSoundingTrim(item.Replace(".bin", ""), Table_BallastTankSoundingTrim.Read_from_file(item)));
            }


            return result;
        }
    }
}
