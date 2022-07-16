using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootCamp.Adm.IRepository;

public interface IBaseRepository<TEntity>
{
    /// <summary>
    /// Gets this instance.
    /// </summary>
    /// <returns></returns>
    IQueryable<TEntity> Get();
    /// <summary>
    /// Gets the by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>
    ///   <br />
    /// </returns>
    Task<TEntity> GetById(int id);
    /// <summary>
    /// Posts the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns></returns>
    Task<TEntity> Post(TEntity entity);
    /// <summary>
    /// Patches the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns></returns>
    Task Patch(TEntity entity);
    /// <summary>
    /// Deletes the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    Task Delete(int id);
}
