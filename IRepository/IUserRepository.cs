using BootCamp.Adm.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BootCamp.Adm.IRepository
{

    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmail(string mail);
        Task<List<User>> GetAll();
        //Task<bool> ValidateEmailToAdd(string email);
        //Task<bool> ValidateEmailToUpdate(int id, string email);
    }
}
