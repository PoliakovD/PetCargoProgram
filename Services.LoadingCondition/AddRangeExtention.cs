using System.Collections.Generic;
using System.ComponentModel;

namespace PetCargoProgram.Services.LoadingCondition;

public static class AddRangeExtention
{
    public static void AddRange<T>(this BindingList<T> collection, IEnumerable<T> range)
    {
        foreach (var item in range) collection.Add(item);
    }
}
