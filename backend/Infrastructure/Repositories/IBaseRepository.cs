using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using gerdisc.Models.Entities;

namespace gerdisc.Infrastructure.Repositories
{
    /// <summary>
    /// Defines the contract for a repository that provides basic CRUD operations and querying capabilities for a given entity type.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity that the repository provides operations for.</typeparam>
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Gets all entities of type TEntity in the repository.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{TEntity}"/> containing all entities of type TEntity in the repository.</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Gets the total count of entities of type TEntity in the repository.
        /// </summary>
        /// <returns>The total count of entities of type TEntity in the repository.</returns>
        Task<int> CountAsync();

        /// <summary>
        /// Gets all entities of type TEntity in the repository, including any related entities specified by the provided include expressions.
        /// </summary>
        /// <param name="includeProperties">One or more expressions that specify related entities to include in the query.</param>
        /// <returns>An <see cref="IEnumerable{TEntity}"/> containing all entities of type TEntity in the repository, including any related entities specified by the provided include expressions.</returns>
        Task<IEnumerable<TEntity>> AllIncludingAsync(params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        /// Gets a single entity of type TEntity from the repository by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <returns>The entity of type TEntity with the specified ID, or null if no such entity exists in the repository.</returns>
        Task<TEntity?> GetSingleAsync(int id);

        /// <summary>
        /// Gets a single entity of type TEntity from the repository that satisfies the specified predicate.
        /// </summary>
        /// <param name="predicate">A predicate that specifies the conditions that the entity must satisfy.</param>
        /// <returns>The first entity of type TEntity that satisfies the specified predicate, or null if no such entity exists in the repository.</returns>
        Task<TEntity?> GetSingleAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Gets a single entity of type TEntity from the repository that satisfies the specified predicate, including any related entities specified by the provided include expressions.
        /// </summary>
        /// <param name="predicate">A predicate that specifies the conditions that the entity must satisfy.</param>
        /// <param name="includeProperties">One or more expressions that specify related entities to include in the query.</param>
        /// <returns>The first entity of type TEntity that satisfies the specified predicate, including any related entities specified by the provided include expressions, or null if no such entity exists in the repository.</returns>
        Task<TEntity?> GetSingleAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        /// Finds all entities of type TEntity in the repository that satisfy the specified predicate.
        /// </summary>
        /// <param name="predicate">A predicate that specifies the conditions that the entities must satisfy.</param>
        /// <returns>An <see cref="IEnumerable{TEntity}"/> containing all entities of type TEntity in the repository that satisfy the specified predicate.</returns>
        Task<IEnumerable<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Adds a new entity to the database asynchronously.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// If the entity is already attached to the context, it will be marked as added.
        /// Otherwise, it will be attached to the context and marked as added.
        /// The changes will be saved to the database immediately.
        /// </remarks>
        public Task AddAsync(TEntity entity);

        /// <summary>
        /// Updates an existing entity in the repository.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        void Update(TEntity entity);

        /// <summary>
        /// Deletes an entity from the repository.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Deletes all entities matching the specified predicate from the repository.
        /// </summary>
        /// <param name="predicate">The predicate used to filter the entities to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task DeleteWhereAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Saves all changes made to entities in the repository to the database.
        /// </summary>
        /// <returns>The number of entities written to the database.</returns>
        Task<int> CommitAsync();
    }
}