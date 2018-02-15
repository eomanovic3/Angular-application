using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApiLab.Tests.Helpers;
using DAL;
using DC;
using Moq;
using System.Collections.Generic;

namespace ApiLab.Tests.DalTests
{
    /// <summary>
    /// Summary description for AddressDalTests
    /// </summary>
    [TestClass]
    public class AddressDalTests
    {
        AddressDal _addressDal;
        List<Address> _listOfAddresses;
        List<AddressModelDC>_listOfAddressesModelDC = new List<AddressModelDC>();
        Mock<APLABDatabaseEntities> _mockedEntities;
       
        [TestInitialize]
        public void InitialSetup()
        { 
            _mockedEntities = MockHelper.GetMockedEntityModel();
            _addressDal = new AddressDal(_mockedEntities.Object);
            _listOfAddresses = new List<Address>(_mockedEntities.Object.Addresses);
            foreach(var a in _listOfAddresses)
            {
                _listOfAddressesModelDC.Add(_addressDal.MapToAddressModelDC(a));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "AddressId")]
        public void GetAddressById_InvalidArgument()
        {
            _addressDal.GetAddresses();
            _addressDal.GetAddressById(-50);
        }

        [TestMethod]
        [TestCategory("GetAddressById method")]
        [ExpectedException(typeof(NullReferenceException),"AddressId")]
        public void GetAddressById_AddressDoesNotExist()
        {
            var result = _addressDal.GetAddressById(55);
            Assert.IsNull(result);
        }

        [TestMethod]
        [TestCategory("GetAddressById method")]
        public void GetAddressById_ValidAddress()
        {
            var result = _addressDal.GetAddressById(1);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        [TestCategory("AddAddress method")]
        public void AddAddress_Valid()
        {
            var length = _listOfAddressesModelDC.Count;
            _listOfAddressesModelDC.Add(new AddressModelDC(0, "dd", "d", 10, 1, false));
            var length1 = _listOfAddressesModelDC.Count;
             Assert.AreNotEqual(length,length1);
        }
        [TestMethod]
        [TestCategory("AddAddress method")]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "AddressId")]
        public void AddAddress_NullAddress()
        {
            var length = _listOfAddressesModelDC.Count;
            _listOfAddressesModelDC.Add(null);
            _addressDal.AddAddress(null);
            var length1 = _listOfAddressesModelDC.Count;
            Assert.AreEqual(length, length1);
        }
        [TestMethod]
        [TestCategory("UpdateAddressById method")]
        public void UpdateAddressById_ValidAddress()
        {
            var addr = _addressDal.GetAddressById(1);
            var before = addr.address1;
            addr.address1 = "Change address1";
            _addressDal.UpdateAddress(1, addr);
            var after = _addressDal.GetAddressById(1).address1;
            Assert.AreNotEqual(before,after);
        }
        [TestMethod]
        [TestCategory("UpdateAddressById method")]
        [ExpectedException(typeof(NullReferenceException), "AddressId")]
        public void UpdateAddressById_InvalidAddress()
        {
            var addr = _addressDal.GetAddressById(4);
            var before = addr.address1;
            Console.WriteLine(addr.address1);
            addr.address1 = "Change address1";
            _addressDal.UpdateAddress(1, addr);
            var after = _addressDal.GetAddressById(4).address1;
            Assert.AreNotEqual(before, after);
        }
        [TestMethod]
        [TestCategory("DeleteAddress method")]
        public void DeleteAddress_ValidAddress()
        {
            var addr = _addressDal.GetAddressById(2057);
            int a = _listOfAddressesModelDC.Count;
            var addrModelDC = _listOfAddressesModelDC.Find(x => x.addressId == addr.addressId);
            _addressDal.DeleteAddress(addr.addressId);
            _listOfAddressesModelDC.Remove(addrModelDC);
            int b = _listOfAddressesModelDC.Count;
            Assert.AreNotEqual(a,b);
        }
        [TestMethod]
        [TestCategory("DeleteAddress method")]
        [ExpectedException(typeof(NullReferenceException), "AddressId")]
        public void DeleteAddress_InvalidAddress()
        {
            var addr = _addressDal.GetAddressById(20);
            int a = _listOfAddressesModelDC.Count;
            _addressDal.DeleteAddress(addr.addressId);
            int b = _listOfAddressesModelDC.Count;
            Assert.AreNotEqual(a, b);
        }

    }
}
