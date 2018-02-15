using DAL;
using DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserDetailLogic : IUserDetail
    {
        private readonly UserDetailDal _users;

        public UserDetailLogic(UserDetailDal users)
        {
            _users = users;
        }
        public List<UserDetailModelDC> GetUsers()
        {
            return _users.GetUsers();
        }

        public UserDetailModelDC GetUserById(int id)
        {
            if (id < 0)
                throw new ArgumentException(Messages.UserExceptionGetById);
            return _users.GetUserById(id);
        }

        public void AddUser(UserDetailModelDC obj)
        {
            foreach (UserDetailModelDC user in _users.GetUsers())
            {
                if (user.userId == obj.userId)
                {
                    throw new ArgumentException(Messages.UserExceptionAdd);
                }
            }
            this._users.AddUser(obj);
        }

        public void UpdateUser(int id, UserDetailModelDC obj)
        {
            if(id < 0)
                throw new ArgumentException(Messages.UserExceptionUpdateById);
            this._users.UpdateUser(id, obj);
        }

        public void DeleteUser(int id)
        {
            if (id < 0)
                throw new ArgumentException(Messages.UserExceptionDelete);
            foreach (UserDetailModelDC user in _users.GetUsers())
            {
                if (user.userId == id)
                {
                    _users.DeleteUser(id);
                }
            }
        }
    }
}
