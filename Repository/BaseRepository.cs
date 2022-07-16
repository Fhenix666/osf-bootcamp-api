using BootCamp.Adm.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BootCamp.Adm.Helpers;
using BootCamp.Adm.Data;
using BootCamp.Adm.IRepository;

namespace BootCamp.Adm.Repository
{
    /// <summary>
    /// BaseRepository
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="BootCamp.Adm.Repository.Interface.IBaseRepository{TEntity}" />
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly DBContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public BaseRepository(DBContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<TEntity> Get()
        {
            return _context.Set<TEntity>().AsQueryable();
        }
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// <br />
        /// </returns>
        public virtual async Task<TEntity> GetById(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
        /// <summary>
        /// Posts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<TEntity> Post(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);

            await _context.SaveChangesAsync();

            return entity;
        }
        /// <summary>
        /// Patches the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public async Task Patch(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);

            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public async Task Delete(int id)
        {
            var entity = _context.Set<TEntity>().Find(id);

            GenericObject.TrySetProperty(entity, "Active", false);

            await _context.SaveChangesAsync();
        }
    }
}
