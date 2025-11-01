using System.IO;
using System.Text;
using PetCargoProgram.Models.CargoTables;
using PetCargoProgram.DataAccess.CargoTables.TablesWriters;
using PetCargoProgram.DataAccess.CargoTables.TablesReaders;

namespace PetCargoProgram.DataAccess;

/// <summary>
/// Class for saving and loading cargo tables
/// </summary>
public static class BinaryCTService
{
    /// <summary>
    /// Save all cargo tables to binary file
    /// </summary>
    /// <param name="allCargoTables"> receive reference to object <see cref="AllCargoTables"/></param>
    /// <param name="path"><see cref="string"/> type path to save file</param>
    public static void Save(ref AllCargoTables allCargoTables, string path = "CargoTables.bin")
    {
        using (FileStream fs = new FileStream(path,
                   FileMode.Create))
        {
            using (BinaryWriter bw =
                   new BinaryWriter(fs,
                       Encoding.Unicode))
            {
                WriterBallSoundTrim.Write(fs, bw, allCargoTables.TablesBallSoundTrim);
                WriterCargoTankUllageTrim.Write(fs, bw, allCargoTables.TablesCargoTankUllage);
                WriterHydrostatic.Write(fs, bw, allCargoTables.TablesHydrostatic);
                WriterOtherSounding.Write(fs, bw, allCargoTables.TablesOtherSounding);
                WriterVolume.Write(fs, bw, allCargoTables.TablesVolume);
            }
        }
    }

    /// <summary>
    /// Load all cargo tables from binary file
    /// </summary>
    /// <param name="path"><see cref="string"/> type  path from load file default value is "CargoTables.bin"</param>
    /// <returns><see cref="AllCargoTables"/> not null</returns>
    public static AllCargoTables? Load(string path = "CargoTables.bin")
    {
        if (File.Exists(path))
        {
            var resultAllTables = new AllCargoTables();
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                using (BinaryReader br = new BinaryReader(fs, Encoding.Unicode))
                {
                    ReaderBallSoundTrim.Read(fs, br, ref resultAllTables);
                    ReaderCargoTankUllageTrim.Read(fs, br, ref resultAllTables);
                    ReaderHydrostatic.Read(fs, br, ref resultAllTables);
                    ReaderOtherSounding.Read(fs, br, ref resultAllTables);
                    ReaderVolume.Read(fs, br, ref resultAllTables);
                }
            }

            return resultAllTables;
        }

        return null;
    }
}
