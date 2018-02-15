using DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class UserDetailDal : IUserDetailDal
    {
        private APLABDatabaseEntities _db;

        public UserDetailDal(APLABDatabaseEntities entities)
        {
            _db = entities;
        }

        public List<UserDetailModelDC> GetUsers()
        {
            List<UserDetailModelDC> list = new List<UserDetailModelDC>();
            foreach (UserDetail user in _db.UserDetails)
            {
                if (user.IsDeleted == false)
                {
                    list.Add(MapToUserDetailModelDC(user));
                }
            }
            return list;
        }

        public UserDetailModelDC GetUserById(int id)
        {
            UserDetail obj = _db.UserDetails.FirstOrDefault(x => x.UserId == id);

            if (obj == null)
            {
                throw new ArgumentException(Messages.UserExceptionGetById);
            }
            else
            {
                return MapToUserDetailModelDC(obj);
            }

        }

        public void AddUser(UserDetailModelDC obj)
        {
            if (obj == null)
                throw new ArgumentException(Messages.UserExceptionAdd);

            _db.UserDetails.Add(MapToUser(obj));
            _db.SaveChanges();
        }

        public void UpdateUser(int id, UserDetailModelDC obj)
        {
            UserDetail user = _db.UserDetails.FirstOrDefault(x => x.UserId == id);

            if (user == null)
            {
                throw new ArgumentException(Messages.UserExceptionUpdateById);
            }

            user = MapAndSaveUserDetailsModelDCToUser(user, obj);
            _db.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            UserDetail user = _db.UserDetails.FirstOrDefault(x => x.UserId == id);

            if (user == null)
            {
                throw new ArgumentException(Messages.UserExceptionDelete);
            }

            foreach (var i in _db.UserDetails)
            {
                if (i.UserId == id)
                {
                    _db.UserDetails.Remove(i);
                }
            }

            _db.SaveChanges();
        }
    }
}
