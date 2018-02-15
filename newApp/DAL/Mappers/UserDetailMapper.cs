using DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDetailMapper { }
    public partial class UserDetailDal
    {        
        public UserDetailModelDC MapToUserDetailModelDC(UserDetail a)
        {
            return new UserDetailModelDC()
            {
                userId = a.UserId,
                firstName = a.FirstName,
                lastName = a.LastName,
                userName = a.UserName,
                isDeleted = a.IsDeleted
            };
        }
        public UserDetail MapToUser(UserDetailModelDC a)
        {
            return new UserDetail()
            {
                UserId = a.userId,
                FirstName = a.firstName,
                LastName = a.lastName,
                UserName = a.userName,
                IsDeleted = a.isDeleted
            };
        }

        public UserDetailModelDC MapAndSaveUserToUserDetailModelDC(UserDetailModelDC a, UserDetail b)
        {
            a.userId = b.UserId;
            a.firstName = b.FirstName;
            a.lastName = b.LastName;
            a.userName = b.UserName;
            a.isDeleted = b.IsDeleted;
            return a;
        }

        public UserDetail MapAndSaveUserDetailsModelDCToUser(UserDetail a, UserDetailModelDC b)
        {
            a.UserId = b.userId;
            a.FirstName = b.firstName;
            a.LastName = b.lastName;
            a.UserName = b.userName;
            a.IsDeleted = b.isDeleted;
            return a;
        }
    }
}
