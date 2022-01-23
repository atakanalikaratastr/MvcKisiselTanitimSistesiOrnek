using NTier.Bussines.Abstract;
using NTier.DataAccess.Abstract;
using NTier.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Bussines.Concrete
{
    public class UserManager : IUserService
    {
        IUserDAL _userDAL;
        public UserManager(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }
        public void Add(User user)
        {
            _userDAL.Add(user);
        }

        public void Delete(User user)
        {
            _userDAL.Delete(user);
        }

        public User GetUserByUserId(int? id)
        {
            return _userDAL.Get(x => x.UserId == id);

        }

        public List<User> GetUserList()
        {
            return _userDAL.GetAll();
        }

        public void Update(User user)
        {
            _userDAL.Update(user);
        }
    }
}
