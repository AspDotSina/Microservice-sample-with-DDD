using Sample.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagment.Domain.Users.Entities;
using UserManagment.Domain.Users.Repositories;

namespace UserManagment.Infrastructure.Users
{
    public class UserRepository : IUserRepository
    {

        private readonly IEventStore _eventStore;
        public UserRepository(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }
    
        public async Task<User> FindByIdAsync(Guid id)
        {
            var customerEvents = await _eventStore.LoadAsync(id, typeof(User).Name);
            return new User(customerEvents);
        }

        public async Task<Guid> SaveAsync(User user)
        {
            await _eventStore.SaveAsync(user.Id,user.GetType().Name,user.Version,user.domainEvents);
            return user.Id;
        }
    }
}
