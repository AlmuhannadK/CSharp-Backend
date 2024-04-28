using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendTeamwork.Abstractions;
using BackendTeamwork.Databases;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        public IEnumerable<User> FindMany()
        {
            return new DatabaseContext().Users;
        }
    }
}