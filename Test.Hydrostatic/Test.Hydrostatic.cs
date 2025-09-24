using System;
using System.Collections.Generic;
using PetCargoProgram.DataAccess;
using PetCargoProgram.Models.CargoTables;
using PetCargoProgram.Services.CargoTables;



var tableService = CargoTablesProvider.Hydrostatic;
var tableServiceTrim =CargoTablesProvider.HydrostaticTrim;

// гидростатистическая таблица на ровный киль (trim 0)

var testDisplacment = 99820.20;
var testTrim = 1.0;
Console.WriteLine(tableService.GetValue(testDisplacment));
Console.WriteLine(tableServiceTrim.GetValue(testDisplacment, testTrim));
Console.ReadKey();
