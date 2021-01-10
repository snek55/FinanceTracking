namespace FinanceTracking.Entities
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    /// <summary>
    /// Чек
    /// </summary>
    public class Check : IBaseEntity
    {
        /// <inheritdoc>
        public long Id { get; set; }

        /// <summary>
        /// Лист покупок
        /// </summary>
        public List<Shopping> Shopping { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
