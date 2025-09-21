using System.Collections.Generic;

namespace PetCargoProgram.Models.LoadingCondition;

public class LoadingConditionTable
{
    public List<ILoadingConditionItem> Table { get; set; }
    public void Add(ILoadingConditionItem item) => Table.Add(item);
}
