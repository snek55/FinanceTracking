﻿namespace FinanceTracking.Extensions
{
    using System.Text.Json;
    using Entities.Interfaces;

    public static class BaseEntityExtension
    {
        public static T Clone<T>(this T baseEntity) 
            where T : class, IBaseEntity
        {
            var str = JsonSerializer.Serialize(baseEntity, typeof(T));

            return (T) JsonSerializer.Deserialize(str, typeof(T));
        }
    }
}