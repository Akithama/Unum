using System;
using System.Collections.Generic;
using System.Text;
using Unum.Data.Infrastructure.Repository;
using Unum.Data.Models;
using Unum.DataAccess.Infrastructure.Interfaces;

namespace Unum.DataAccess.Infrastructure.Repository
{
    public class UserRepository : Repository<User>, IUser
    {
        public UserRepository(ApplicationDBContext context) : base(context) { }
    }
}
