namespace FinanceTracking.Entities.Interfaces
{
    /// <summary>
    /// Базовый интерфейс для основных сущностей программы
    /// </summary>
    public interface IBaseEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }
    }
}