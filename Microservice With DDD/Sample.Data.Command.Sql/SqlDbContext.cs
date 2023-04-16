using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagment.Domain.Users.Entities;

namespace Sample.Data.Sql
{
    public class SqlDbContext:DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options):base(options) 
        {
                
        }
        public DbSet<User> Users { get; set; }

    }
}
