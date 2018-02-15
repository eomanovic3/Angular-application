﻿using DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IAddressDal
    {

        List<AddressModelDC> GetAddresses();
        
        AddressModelDC GetAddressById(int id);

        void AddAddress(AddressModelDC obj);

        void UpdateAddress(int id, AddressModelDC obj);

        void DeleteAddress(int id);
    }
}
