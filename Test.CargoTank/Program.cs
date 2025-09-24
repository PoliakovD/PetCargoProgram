using System;

using PetCargoProgram.Models.Tanks;


string Name = "COT 1P";
CargoTank COT1P = new CargoTank(Name);
COT1P.Density = 0.9887;
COT1P.VolumePercent = 0.98;

Console.WriteLine(COT1P);

Console.ReadKey();
