using System.Collections.Generic;
using PetCargoProgram.Models.LoadingCondition;

namespace PetCargoProgram.Services.LoadingCondition;

public class Service_LoadingCondition
{
    private List<ILoadingConditionItem> _table=[];

    public Service_LoadingCondition();
    public void Add(ILoadingConditionItem item) => _table.Add(item);

}
