﻿using DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUserDetailDal
    {

        List<UserDetailModelDC> GetUsers();

        UserDetailModelDC GetUserById(int id);

        void AddUser(UserDetailModelDC obj);

        void UpdateUser(int id, UserDetailModelDC obj);

        void DeleteUser(int id);
    }
}
