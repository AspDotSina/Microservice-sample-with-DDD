using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagment.ApplicationService.Users.Dtos;
using UserManagment.Domain.Users.Entities;
using UserManagment.Domain.Users.Repositories;

namespace UserManagment.ApplicationService.Users
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> CreateCustomerAsync(string firstname, string lastname)
        {
            var user = User.CreateNewUser(firstname, lastname);
            var userid = await _userRepository.SaveAsync(user);
            return userid;
        }



        public async Task<Guid> UpdateCustomer(string userid, string firstname, string lastname)
        {
            var user = await _userRepository.FindByIdAsync(Guid.Parse(userid));
            user.ChangeName(firstname,lastname);
            await _userRepository.SaveAsync(user);  
            return user.Id;

        }


        public async Task<UserDto> GetUser(string userid)
        {
            var user = await _userRepository.FindByIdAsync(Guid.Parse(userid));
            if (user == null) return new UserDto();

            return new UserDto()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserId = user.Id.ToString(),
                UserAddress = user.UserAddress != null ? new AddressDto()
                {
                    City = user.UserAddress?.City,
                    Country = user.UserAddress?.Country,
                    Street = user.UserAddress?.Street,
                    ZipCode = user.UserAddress?.ZipCode
                } : null
            };
        }


        public async Task UpdaateAddress(string userid, string street, string country, string city, string zipcode)
        {
            var user = await _userRepository.FindByIdAsync(Guid.Parse(userid));
            user.ChangeAddress(street, country, city, zipcode);
            await _userRepository.SaveAsync(user);  
        }
    }
}
