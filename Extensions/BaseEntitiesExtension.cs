namespace FinanceTracking.Extensions
{
    using System.Text.Json;
    using Entities.Interfaces;

    public static class BaseEntitiesExtension
    {
        public static T Clone<T>(this IBaseEntities baseEntities)
        {
            var str = JsonSerializer.Serialize(baseEntities, typeof(T));

            return (T) JsonSerializer.Deserialize(str, typeof(T));
        }
    }
}