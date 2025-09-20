namespace PetCargoProgram.Models.LoadingCondition;

public class LoadingConditionTable
{
    List<ILoadingConditionItem> Table { get; set; }
    public void Add(ILoadingConditionItem item) => Table.Add(item);
}
