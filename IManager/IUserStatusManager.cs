using BootCamp.Adm.Entities;
using BootCamp.Adm.IManager;
using BootCamp.Adm.ViewModels;

namespace BootCamp.Adm.Manager.Interfaces
{
    /// <summary>
    /// IUserStatusManager
    /// </summary>
    /// <seealso cref="BootCamp.Adm.Manager.Interfaces.IBaseManager{BootCamp.Adm.Entities.UserStatus, BootCamp.Adm.ViewModels.UserStatusViewModel}" />
    public interface IUserStatusManager : IBaseManager<UserStatus, ViewModels.Output.UserStatusViewModel, ViewModels.Output.UserStatusViewModel>
    {
    }
}
