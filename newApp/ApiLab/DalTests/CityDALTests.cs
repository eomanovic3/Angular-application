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
    /// Summary description for CityDalTests
    /// </summary>
    [TestClass]
    public class CityDalTests
    {
        CityDal _cityDal;
        List<City> _listOfCities;
        List<CityModelDC> _listOfCitiesModelDC = new List<CityModelDC>();
        Mock<APLABDatabaseEntities> _mockedEntities;

        [TestInitialize]
        public void InitialSetup()
        {
            _mockedEntities = MockHelper.GetMockedEntityModel();
            _cityDal = new CityDal(_mockedEntities.Object);
            _listOfCities = new List<City>(_mockedEntities.Object.Cities);
            foreach (var a in _listOfCities)
            {
                _listOfCitiesModelDC.Add(_cityDal.MapToCityModelDC(a));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "CityId")]
        public void GetCityById_InvalidArgument()
        {
            _cityDal.GetCities();
            _cityDal.GetCityById(-50);
        }

        [TestMethod]
        [TestCategory("GetCityById method")]
        [ExpectedException(typeof(NullReferenceException), "CityId")]
        public void GetCityById_CityDoesNotExist()
        {
            var result = _cityDal.GetCityById(55);
            Assert.IsNull(result);
        }

        [TestMethod]
        [TestCategory("GetCityById method")]
        public void GetCityById_ValidCity()
        {
            var result = _cityDal.GetCityById(1);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        [TestCategory("AddCity method")]
        public void AddCity_Valid()
        {
            var length = _listOfCitiesModelDC.Count;
            _listOfCitiesModelDC.Add(new CityModelDC(14, "dd", 1));
            var length1 = _listOfCitiesModelDC.Count;
            Assert.AreNotEqual(length, length1);
        }
        [TestMethod]
        [TestCategory("AddCity method")]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "CityId")]
        public void AddCity_NullCity()
        {
            var length = _listOfCitiesModelDC.Count;
            _listOfCitiesModelDC.Add(null);
            _cityDal.AddCity(null);
            var length1 = _listOfCitiesModelDC.Count;
            Assert.AreEqual(length, length1);
        }
        [TestMethod]
        [TestCategory("UpdateCityById method")]
        public void UpdateCityById_ValidCity()
        {
            var city1 = _cityDal.GetCityById(1);
            var before = city1.cityName;
            city1.cityName = "Change city1";
            _cityDal.UpdateCity(1, city1);
            var after = _cityDal.GetCityById(1).cityName;
            Assert.AreNotEqual(before, after);
        }
        [TestMethod]
        [TestCategory("UpdateCityById method")]
        [ExpectedException(typeof(NullReferenceException), "CityId")]
        public void UpdateCityById_InvalidCity()
        {
            var city1 = _cityDal.GetCityById(100);
            var before = city1.cityName;
            Console.WriteLine(city1.cityName);
            city1.cityName = "Change city1";
            _cityDal.UpdateCity(1, city1);
            var after = _cityDal.GetCityById(100).cityName;
            Assert.AreNotEqual(before, after);
        }
        [TestMethod]
        [TestCategory("DeleteCity method")]
        public void DeleteCity_ValidCity()
        {
            var city1 = _cityDal.GetCityById(1);
            int a = _listOfCitiesModelDC.Count;
            var city1ModelDC = _listOfCitiesModelDC.Find(x => x.cityId == city1.cityId);
            _cityDal.DeleteCity(city1.cityId);
            _listOfCitiesModelDC.Remove(city1ModelDC);
            int b = _listOfCitiesModelDC.Count;
            Assert.AreNotEqual(a, b);
        }
        [TestMethod]
        [TestCategory("DeleteCity method")]
        [ExpectedException(typeof(NullReferenceException), "CityId")]
        public void DeleteCity_InvalidCity()
        {
            var city1 = _cityDal.GetCityById(20);
            int a = _listOfCitiesModelDC.Count;
            _cityDal.DeleteCity(city1.cityId);
            int b = _listOfCitiesModelDC.Count;
            Assert.AreNotEqual(a, b);
        }

    }
}
