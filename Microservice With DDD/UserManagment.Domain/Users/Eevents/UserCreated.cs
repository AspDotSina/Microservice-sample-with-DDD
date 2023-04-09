using Sample.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagment.Domain.Users.Eevents
{
    public class UserCreated : IDomainEvent
    {
        public string UserId { get; }

        public string FirstName { get; }
        public string LastName { get; }

        public UserCreated(string userid, string firstname, string lastname)
        {
            UserId = userid;
            FirstName = firstname;
            LastName = lastname;
        }
    }

    public class UserChangedName : IDomainEvent
    {
        public string UserId { get; }

        public string FirstName { get; }
        public string LastName { get; }

        public UserChangedName(string userid, string firstname, string lastname)
        {
            UserId = userid;
            FirstName = firstname;
            LastName = lastname;
        }
    }



    public class AddressChanged : IDomainEvent
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string UserId { get; }



        public AddressChanged(string userid, string street, string country, string city, string zipcode)
        {
            UserId = userid;
            Street = street;
            City = city;
            Country = country;
            ZipCode = zipcode;

        }
    }

}
