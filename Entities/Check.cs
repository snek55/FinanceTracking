namespace FinanceTracking.Entities
{
    using System;
    using Interfaces;

    /// <summary>
    /// Чек
    /// </summary>
    public class Check : IBaseEntity
    {
        /// <inheritdoc>
        public long Id { get; set; }

        /// <inheritdoc>
        public Shopping Shopping { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreateDate => DateTime.UtcNow;
    }
}
