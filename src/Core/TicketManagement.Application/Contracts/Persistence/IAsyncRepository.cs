namespace TicketManagement.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T: class
    {
        /// <summary>
        /// Returns T
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Type of T</returns>
        Task<T> GetByIdAsync(Guid id);

        /// <summary>
        /// Returns a readonly list of events
        /// </summary>
        /// <returns>A List of T types</returns>
        Task<IReadOnlyList<T>> ListAllAsync();

        /// <summary>
        /// Creates a new entity T
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}