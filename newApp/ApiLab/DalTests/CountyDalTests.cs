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
    /// Summary description for CountyDalTests
    /// </summary>
    [TestClass]
    public class CountyDalTests
    {
        CountyDal _countyDal;
        List<County> _listOfCounties;
        List<CountyModelDC> _listOfCountiesModelDC = new List<CountyModelDC>();
        Mock<APLABDatabaseEntities> _mockedEntities;

        [TestInitialize]
        public void InitialSetup()
        {
            _mockedEntities = MockHelper.GetMockedEntityModel();
            _countyDal = new CountyDal(_mockedEntities.Object);
            _listOfCounties = new List<County>(_mockedEntities.Object.Counties);
            foreach (var a in _listOfCounties)
            {
                _listOfCountiesModelDC.Add(_countyDal.MapToCountyModelDC(a));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "CountyId")]
        public void GetCountyById_InvalidArgument()
        {
            _countyDal.GetCounties();
            _countyDal.GetCountyById(-50);
        }

        [TestMethod]
        [TestCategory("GetCountyById method")]
        [ExpectedException(typeof(NullReferenceException), "CountyId")]
        public void GetCountyById_CountyDoesNotExist()
        {
            var result = _countyDal.GetCountyById(55);
            Assert.IsNull(result);
        }

        [TestMethod]
        [TestCategory("GetCountyById method")]
        public void GetCountyById_ValidCounty()
        {
            var result = _countyDal.GetCountyById(1);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        [TestCategory("AddCounty method")]
        public void AddCounty_Valid()
        {
            var length = _listOfCountiesModelDC.Count;
            _listOfCountiesModelDC.Add(new CountyModelDC(14, "dd", 1));
            var length1 = _listOfCountiesModelDC.Count;
            Assert.AreNotEqual(length, length1);
        }
        [TestMethod]
        [TestCategory("AddCounty method")]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "CountyId")]
        public void AddCounty_NullCounty()
        {
            var length = _listOfCountiesModelDC.Count;
            _listOfCountiesModelDC.Add(null);
            _countyDal.AddCounty(null);
            var length1 = _listOfCountiesModelDC.Count;
            Assert.AreEqual(length, length1);
        }
        [TestMethod]
        [TestCategory("UpdateCountyById method")]
        public void UpdateCountyById_ValidCounty()
        {
            var county1 = _countyDal.GetCountyById(1);
            var before = county1.countyName;
            county1.countyName = "Change county1";
            _countyDal.UpdateCounty(1, county1);
            var after = _countyDal.GetCountyById(1).countyName;
            Assert.AreNotEqual(before, after);
        }
        [TestMethod]
        [TestCategory("UpdateCountyById method")]
        [ExpectedException(typeof(NullReferenceException), "CountyId")]
        public void UpdateCountyById_InvalidCounty()
        {
            var county1 = _countyDal.GetCountyById(100);
            var before = county1.countyName;
            Console.WriteLine(county1.countyName);
            county1.countyName = "Change county1";
            _countyDal.UpdateCounty(1, county1);
            var after = _countyDal.GetCountyById(100).countyName;
            Assert.AreNotEqual(before, after);
        }
        [TestMethod]
        [TestCategory("DeleteCounty method")]
        public void DeleteCounty_ValidCounty()
        {
            var county1 = _countyDal.GetCountyById(1);
            int a = _listOfCountiesModelDC.Count;
            var county1ModelDC = _listOfCountiesModelDC.Find(x => x.countyId == county1.countyId);
            _countyDal.DeleteCounty(county1.countyId);
            _listOfCountiesModelDC.Remove(county1ModelDC);
            int b = _listOfCountiesModelDC.Count;
            Assert.AreNotEqual(a, b);
        }
        [TestMethod]
        [TestCategory("DeleteCounty method")]
        [ExpectedException(typeof(NullReferenceException), "CountyId")]
        public void DeleteCounty_InvalidCounty()
        {
            var county1 = _countyDal.GetCountyById(20);
            int a = _listOfCountiesModelDC.Count;
            _countyDal.DeleteCounty(county1.countyId);
            int b = _listOfCountiesModelDC.Count;
            Assert.AreNotEqual(a, b);
        }

    }
}
