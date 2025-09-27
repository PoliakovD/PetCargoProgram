using System.Text;

namespace PetCargoProgram.Models.ShipCondition;

public partial class ShipConditionClass
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
            sb.AppendLine($"\t{name}: {value}");
        }
        sb.AppendLine("}");
        return sb.ToString();
    }
}
