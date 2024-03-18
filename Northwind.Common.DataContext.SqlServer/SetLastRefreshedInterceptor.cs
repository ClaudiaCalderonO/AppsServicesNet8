using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Northwind.EntityModels;

public class SetLastRefreshedInterceptor : IMaterializationInterceptor
{
    public object InitializedInstance(MaterializationInterceptionData
      materializationData, object entity)
    {
        if (entity is IHasLastRefresed entityWithLastRefreshed)
        {
            entityWithLastRefreshed.LastRefresed = DateTimeOffset.UtcNow;
        }
        return entity;
    }
}
