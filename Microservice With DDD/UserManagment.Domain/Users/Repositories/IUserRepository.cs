using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagment.Domain.Users.Entities;

namespace UserManagment.Domain.Users.Repositories
{
    public interface IUserRepository
    {
        Task<Guid> SaveAsync(User user);
        Task<User> FindByIdAsync(Guid id);      
    }
}
