using System.Text;

namespace PetCargoProgram.Models.Tanks;

public partial class BallastTank
{
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine("Ballast Tank: {");

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
