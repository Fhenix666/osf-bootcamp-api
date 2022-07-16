using BootCamp.Adm.Commons;
using BootCamp.Adm.Data;
using BootCamp.Adm.Entities;
using BootCamp.Adm.IRepository;
using BootCamp.Adm.ViewModels;
using BootCamp.Adm.ViewModels.Output;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootCamp.Adm.Repository;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    readonly DBContext _context;

    public UserRepository(DBContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User> GetByEmail(string mail)
    {
        return await _context.User.Where(e=>e.Email == mail).FirstOrDefaultAsync();
    }

    public async Task<List<User>> GetAll()
    {
        return await _context.User.Where(e => e.IsDeleted == false).ToListAsync();
    }
}
