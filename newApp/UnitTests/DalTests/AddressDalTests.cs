using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DAL;
using UnitTests.Helpers;

namespace UnitTests.DalTests
{
    /// <summary>
    /// Summary description for AddressDalTests
    /// </summary>
    [TestClass]
    public class AddressDalTests
    {
        AddressDAL _addressDal;
        Mock<APLABDatabaseEntities> _mockedEntities;

        [TestInitialize]
        public void InitialSetup()
        {
            _mockedEntities = MockHelper.GetMockedEntityModel();
            _addressDal = new AddressDAL(_mockedEntities.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "AddressId")]
        public void GetAddressById_InvalidArgument()
        {
            _addressDal.GetAddressById(-50);
        }

        [TestMethod]
        [TestCategory("GetAddressById method")]
        public void GetAddressById_AddressDoesNotExist()
        {
            var result = _addressDal.GetAddressById(4);
            Assert.IsNull(result);
        }

        [TestMethod]
        [TestCategory("GetAddressById method")]
        public void GetAddressById_ValidAddress()
        {
            var result = _addressDal.GetAddressById(4);
            Assert.IsNotNull(result);
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

    }
}
