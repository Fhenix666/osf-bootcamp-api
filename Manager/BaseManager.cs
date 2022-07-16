using BootCamp.Adm.Filters.IFilters;
using BootCamp.Adm.Helpers;
using BootCamp.Adm.IManager;
using BootCamp.Adm.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootCamp.Adm.Manager
{
    /// <summary>
    /// BaseManager
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="RViewModel">The type of the view model.</typeparam>
    /// <typeparam name="UViewModel">The type of the view model.</typeparam>
    /// <seealso cref="IManager.IBaseManager{TEntity, RViewModel, UViewModel}" />
    /// <seealso cref="BootCamp.Adm.Manager.Interfaces.IBaseManager{TEntity, UViewModel}" />
    public class BaseManager<TEntity, RViewModel, UViewModel> : IBaseManager<TEntity, RViewModel, UViewModel> where TEntity : class where RViewModel : class where UViewModel : class
    {

        private readonly IBaseRepository<TEntity> _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseManager{TEntity, UViewModel}"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public BaseManager(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public virtual Tuple<List<UViewModel>, PagedResult<TEntity>> Get(QueryParameter pagingParameter, IFilter filter)
        {
            var source = _repository.Get().GetPaged(pagingParameter, filter);
            var resources = PrepareMultipleReturn(source.Results);

            source.Results = null;
            return new Tuple<List<UViewModel>, PagedResult<TEntity>>(resources, source);
        }
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public virtual async Task<UViewModel> GetById(int id)
        {
            var entity = await _repository.GetById(id);

            return PrepareSingleReturn(entity);
        }
        /// <summary>
        /// Posts the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public virtual async Task<UViewModel> Post(RViewModel model)
        {
            var entity = PrepareAddData(model);

            return PrepareSingleReturn(await _repository.Post(entity));
        }
        /// <summary>
        /// Patches the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        public virtual async Task Patch(int id, RViewModel model)
        {
            var entity = await _repository.GetById(id);

            var updatedEntity = PrepareUpdateData(entity, model);

            await _repository.Patch(updatedEntity);
        }
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public virtual async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
        /// <summary>
        /// Prepares the add data.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual TEntity PrepareAddData(RViewModel viewModel)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Prepares the update data.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="viewModel">The view model.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual TEntity PrepareUpdateData(TEntity entity, RViewModel viewModel)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Prepares the single return.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual UViewModel PrepareSingleReturn(TEntity entity)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Prepares the multiple return.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual List<UViewModel> PrepareMultipleReturn(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}
