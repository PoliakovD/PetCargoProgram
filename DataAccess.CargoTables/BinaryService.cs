using System.Text;
using PetCargoProgram.Models.CargoTables;
using PetCargoProgram.DataAccess.CargoTables.TablesWriters;
using PetCargoProgram.DataAccess.CargoTables.TablesReaders;

namespace PetCargoProgram.DataAccess;

public static class BinaryService
{
    public static void Save(AllCargoTables allCargoTables, string path = "CargoTables.bin")
    {

        using (FileStream fs = new FileStream(path,
                   FileMode.Create))
        {
            using (BinaryWriter bw =
                   new BinaryWriter(fs,
                       Encoding.Unicode))
            {
                WriterBallSoundTrim.Write(fs, bw, allCargoTables.TablesBallSoundTrim);
                WriterCargoTankUllageTrim.Write(fs, bw,allCargoTables.TablesCargoTankUllage);
                WriterHydrostatic.Write(fs, bw, allCargoTables.TablesHydrostatic);
                WriterOtherSounding.Write(fs, bw, allCargoTables.TablesOtherSounding);
                WriterVolume.Write(fs, bw, allCargoTables.TablesVolume);
            }
        }
    }
    public static void BinaryLoad(ref AllCargoTables allCargoTables, string path = "CargoTables.bin")
    {
        if (File.Exists(path))
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                using (BinaryReader br = new BinaryReader(fs, Encoding.Unicode))
                {
                    ReaderBallSoundTrim.Read(fs,br, ref allCargoTables);
                    ReaderCargoTankUllageTrim.Read(fs,br, ref allCargoTables);
                    ReaderHydrostatic.Read(fs,br, ref allCargoTables);
                    ReaderOtherSounding.Read(fs,br, ref allCargoTables);
                    ReaderVolume.Read(fs,br, ref allCargoTables);
                }
            }
        }
    }
}
