using BootCamp.Adm.Filters.IFilters;
using BootCamp.Adm.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootCamp.Adm.IManager
{
    /// <summary>
    /// IBaseManager
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="RViewModel">The type of the view model.</typeparam>
    /// <typeparam name="UViewModel">The type of the view model.</typeparam>
    public interface IBaseManager<TEntity, RViewModel, UViewModel> where TEntity : class where RViewModel : class where UViewModel : class
    {
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        Tuple<List<UViewModel>, PagedResult<TEntity>> Get(QueryParameter pagingParameter, IFilter filter);
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<UViewModel> GetById(int id);
        /// <summary>
        /// Posts the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task<UViewModel> Post(RViewModel model);
        /// <summary>
        /// Patches the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task Patch(int id, RViewModel model);
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        Task Delete(int id);
        /// <summary>
        /// Prepares the add data.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns></returns>
        TEntity PrepareAddData(RViewModel viewModel);
        /// <summary>
        /// Prepares the update data.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="viewModel">The view model.</param>
        /// <returns></returns>
        TEntity PrepareUpdateData(TEntity entity, RViewModel viewModel);
        /// <summary>
        /// Prepares the single return.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        UViewModel PrepareSingleReturn(TEntity entity);
        /// <summary>
        /// Prepares the multiple return.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        List<UViewModel> PrepareMultipleReturn(IEnumerable<TEntity> entities);
    }
}
