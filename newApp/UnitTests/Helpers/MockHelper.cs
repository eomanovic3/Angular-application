using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DAL;
using DC;
using System.Data.Entity;
using System.Runtime.Serialization;
using System.Xml;

namespace UnitTests.Helpers
{
    public static class MockHelper
    {

        public static Mock<APLABDatabaseEntities> GetMockedEntityModel()
        {
            Mock<APLABDatabaseEntities> mockedApLabEntity = new Mock<APLABDatabaseEntities>();

            mockedApLabEntity.CallBase = false;

            List<UserDetail> users = GetDataAsList<UserDetail>("UserDetail.xml");
            List<StateInfo> states = GetDataAsList<StateInfo>("StateInfo.xml");
            List<County> counties = GetDataAsList<County>("County.xml");
            List<City> cities = GetDataAsList<City>("City.xml");
            List<Email> emails = GetDataAsList<Email>("Email.xml");
            List<Zip> zips = GetDataAsList<Zip>("Zip.xml");
            List<Address> addresses = GetDataAsList<Address>("Address.xml");

            states.ForEach(x => x.Counties = counties.Where(y => y.StateId == x.StateId).ToList());
            counties.ForEach(x => x.StateInfo = states.FirstOrDefault(y => y.StateId == x.StateId));
            counties.ForEach(x => x.Cities = cities.Where(y => y.CountyId == x.CountyId).ToList());
            cities.ForEach(x => x.County = counties.FirstOrDefault(y => y.CountyId == x.CountyId));
            cities.ForEach(x => x.Zips = zips.Where(y => y.CityId == x.CityId).ToList());
            users.ForEach(x => x.Addresses = addresses.Where(y => y.UserId == x.UserId).ToList());
            users.ForEach(x => x.Emails = emails.Where(y => y.UserId == x.UserId).ToList());
            zips.ForEach(x => x.City = cities.FirstOrDefault(y => y.CityId == x.CityId));
            emails.ForEach(x => x.UserDetail = users.FirstOrDefault(y => y.UserId == x.UserId));
            addresses.ForEach(x => x.Zip = zips.FirstOrDefault(y => y.ZipId == x.ZipId));
            addresses.ForEach(x => x.UserDetail = users.FirstOrDefault(y => y.UserId == x.UserId));

            mockedApLabEntity.Setup(x => x.StateInfoes).Returns(CreateDbSetMock(states.AsQueryable()).Object);
            mockedApLabEntity.Setup(x => x.Counties).Returns(CreateDbSetMock(counties.AsQueryable()).Object);
            mockedApLabEntity.Setup(x => x.Cities).Returns(CreateDbSetMock(cities.AsQueryable()).Object);
            mockedApLabEntity.Setup(x => x.Zips).Returns(CreateDbSetMock(zips.AsQueryable()).Object);
            mockedApLabEntity.Setup(x => x.UserDetails).Returns(CreateDbSetMock(users.AsQueryable()).Object);
            mockedApLabEntity.Setup(x => x.Emails).Returns(CreateDbSetMock(emails.AsQueryable()).Object);
            mockedApLabEntity.Setup(x => x.Addresses).Returns(CreateDbSetMock(addresses.AsQueryable()).Object);

            return mockedApLabEntity;
        }

        public static Mock<DbSet<T>> GetMockedData<T>(string fileName) where T : class
        {
            return CreateDbSetMock<T>(GetDataAsList<T>(fileName).AsQueryable());
        }

        public static Mock<AddressDAL> GetMockedAddressDal()
        {
            Mock<AddressDAL> addressDal = new Mock<AddressDAL>
            {
                CallBase = false
            };

            addressDal.Setup(x => x.GetAddressById(1)).Returns(new AddressModelDC());

            return addressDal;
        }

        public static List<T> GetDataAsList<T>(string fileName)
        {
            string dataPath = string.Format(@"{0}\DBMocks\{1}", System.Environment.CurrentDirectory, fileName);
            return GetObject<List<T>>(dataPath);
        }

        public static bool CreateSerializedData<T>(T data, string filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                throw new Exception("File Exists!");
            }

            string serializedObj = Serialize<T>(data);

            System.IO.File.AppendAllText(filePath, serializedObj);

            return true;
        }

        public static Mock<DbSet<T>> CreateDbSetMock<T>(IQueryable<T> data) where T : class
        {
            var mockedData = new Mock<DbSet<T>>();
            mockedData.As<IQueryable<T>>().Setup(x => x.Provider).Returns(data.Provider);
            mockedData.As<IQueryable<T>>().Setup(x => x.Expression).Returns(data.Expression);
            mockedData.As<IQueryable<T>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockedData.As<IQueryable<T>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());

            return mockedData;
        }

        private static T GetObject<T>(string filePath)
        {
            string objectSerialized = System.IO.File.ReadAllText(filePath);
            return Deserialize<T>(objectSerialized);
        }

        private static T Deserialize<T>(string data)
        {
            using (MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(data)))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                T obj = (T)serializer.ReadObject(memStream);
                return obj;
            }
        }

        public static string Serialize<T>(T data)
        {
            DataContractSerializer serializer = new DataContractSerializer(data.GetType());
            using (StringWriter backing = new System.IO.StringWriter())
            {
                using (XmlTextWriter writer = new XmlTextWriter(backing))
                {
                    serializer.WriteObject(writer, data);
                    return backing.ToString();
                }
            }
        }
    }
}
