using ProjectExample.BL.Interface;
using ProjectExample.DAL.Database;
using ProjectExample.DAL.Entities;
using ProjectExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectExample.BL.Repository
{
    public class UserRep : IUserRep
    {
        private DbContainer db = new DbContainer();

        public IQueryable<UsersVM> Get()
        {
            var data = db.Users.Select(a => new UsersVM { Id = a.Id, UserName = a.UserName, UserCode = a.UserCode });
            return data;
        }

        public void Add(UsersVM dpt)
        {
            Users U = new Users();
            U.UserName = dpt.UserName;
            U.UserCode = dpt.UserCode;

            db.Users.Add(U);
            db.SaveChanges();
        }

        public UsersVM GetById(int id)
        {
            var data = db.Users.Where(a => a.Id == id)
                               .Select(a => new UsersVM { Id = a.Id, UserName = a.UserName, UserCode = a.UserCode })
                               .FirstOrDefault();
            return data;
        }

       public void Edit(UsersVM dpt)
        {
            var OldData = db.Users.Find(dpt.Id);

            OldData.UserName = dpt.UserName;
            OldData.UserCode = dpt.UserCode;

            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var DeletedObject = db.Users.Find(id);

            db.Users.Remove(DeletedObject);

            db.SaveChanges();
        }
    }
}
