using BootCamp.Adm.Entities;
using BootCamp.Adm.Filters;
using BootCamp.Adm.Helpers;
using BootCamp.Adm.IManager;
using BootCamp.Adm.ViewModels;
using BootCamp.Adm.ViewModels.Input;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BootCamp.Adm.Manager.Interfaces
{
    public interface IUserManager : IBaseManager<User, InputUserViewModel, OutputUserViewModel>
    {

        Task PatchPassword(int id, string password);

        Tuple<List<OutputUserViewModel>, PagedResult<OutputUserViewModel>> GetUsers(QueryParameter pagingParameter, UserFilter filter);

		Task<bool> GeneratePassword(string email);
        Task<List<User>> GetAll();
        Task<User> GetBymail(string mail);
    }
}
