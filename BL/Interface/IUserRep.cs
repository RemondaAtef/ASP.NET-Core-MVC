using ProjectExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectExample.BL.Interface
{
    interface IUserRep
    {
        IQueryable<UsersVM> Get();

        void Add(UsersVM dpt);

        UsersVM GetById(int id);

        void Edit(UsersVM dpt);

        void Delete(int id);
    }
}
