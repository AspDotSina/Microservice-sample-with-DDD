using Sample.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagment.Domain.Users.Eevents;
using UserManagment.Domain.Users.ValueObjects;

namespace UserManagment.Domain.Users.Entities
{
    public class User : AggregateRoot
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address UserAddress { get; set; }

        public User(IEnumerable<IDomainEvent> domainEvents) : base(domainEvents)
        {

        }
        protected User()
        {

        }




        #region Behavior


        public static User CreateNewUser(string firstName, string lastName)
        {
            var user = new User();
            user.Apply(new UserCreated(Guid.NewGuid().ToString(), firstName, lastName));
            return user;
        }



        public void ChangeName(string firstName, string lastName)
        {
            Apply(new UserChangedName(Id.ToString(), firstName, lastName)); 
        }



        public void ChangeAddress(string street, string country,string city,string zipcode)
        {
            Apply(new AddressChanged(Id.ToString(), street, country,city,zipcode));
        }

        public void On(UserCreated @event)
        {
            Id = Guid.Parse(@event.UserId); FirstName = @event.FirstName; LastName = @event.LastName;


        }

        public void On(UserChangedName @event)
        {
            Id = Guid.Parse(@event.UserId); FirstName = @event.FirstName; LastName = @event.LastName;


        }
        public void On(AddressChanged @event)
        {
            UserAddress = new Address()
            {
                Street = @event.Street,
                Country = @event.Country,
                City = @event.City,
                ZipCode = @event.ZipCode,
            };

        }
        #endregion
    }
}
