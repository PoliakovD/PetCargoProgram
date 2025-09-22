using System;
using System.Collections.Generic;
using System.Text;
using PetCargoProgram.Models.LoadingCondition;

namespace PetCargoProgram.Models.Tanks;

public partial class CargoTank : ILoadingConditionItem, IEquatable<CargoTank>
{
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine("CargoTank: {");

        var type = GetType();
        var properties = type.GetProperties();
        foreach (var propertyInfo in properties)
        {
            var name = propertyInfo.Name;
            var value = propertyInfo.GetValue(this);

            if (propertyInfo.PropertyType.IsGenericType)
            {
                var list = (List<string>)value;
                sb.AppendLine($"\t{name}: [{string.Join(", ", list)}]");
            }
            else
            {
                sb.AppendLine($"\t{name}: {value}");
            }
        }
        sb.AppendLine("}");
        return sb.ToString();
    }
}
