using BootCamp.Adm.Commons;
using BootCamp.Adm.Entities;
using BootCamp.Adm.Manager.Interfaces;
using BootCamp.Adm.Repository.Interfaces;
using BootCamp.Adm.ViewModels;
using BootCamp.Adm.ViewModels.Output;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BootCamp.Adm.Manager
{
    /// <summary>
    /// UserStatusManager
    /// </summary>
    /// <seealso cref="BootCamp.Adm.Manager.BaseManager{BootCamp.Adm.Entities.UserStatus, BootCamp.Adm.ViewModels.UserStatusViewModel}" />
    /// <seealso cref="BootCamp.Adm.Manager.Interfaces.IUserStatusManager" />
    public class UserStatusManager : BaseManager<UserStatus, ViewModels.Output.UserStatusViewModel, ViewModels.Output.UserStatusViewModel>, IUserStatusManager
    {
        private readonly IUserStatusRepository _repository;
        private const bool Active = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserStatusManager"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public UserStatusManager(IUserStatusRepository repository) : base(repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Prepares the add data.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns></returns>
        public override UserStatus PrepareAddData(ViewModels.Output.UserStatusViewModel viewModel)
        {
            return new UserStatus()
            {
                Name = viewModel.Name,
                Active = Constants.Active,
                CreatedAt = DateTime.Now
            };
        }
        /// <summary>
        /// Prepares the update data.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="viewModel">The view model.</param>
        /// <returns></returns>
        public override UserStatus PrepareUpdateData(UserStatus entity, ViewModels.Output.UserStatusViewModel viewModel)
        {
            entity.Name = viewModel.Name;
            entity.Active = viewModel.Active;
            entity.UpdatedAt = viewModel.UpdatedAt;

            return entity;
        }
        /// <summary>
        /// Prepares the single return.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public override UserStatusViewModel PrepareSingleReturn(UserStatus entity)
        {
            return new UserStatusViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Active = entity.Active,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }
        /// <summary>
        /// Prepares the multiple return.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        public override List<UserStatusViewModel> PrepareMultipleReturn(IEnumerable<UserStatus> entities)
        {
            return entities.Select(p => new UserStatusViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                Active = p.Active,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt
            }).ToList();
        }
    }
}
