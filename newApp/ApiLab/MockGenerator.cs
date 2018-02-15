using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using ApiLab.Tests.Helpers;
using DAL;
using System.Runtime.Serialization;

namespace ApiLab.Tests
{
    /// <summary>
    /// Summary description for MockGenerator
    /// </summary>
    [TestClass]
    [DataContract(Namespace = "ApiLab")]
    public class MockGenerator
    {
        [TestMethod]
        public void GenerateSerializedMockDataFromRealDB()
        {
            /////////////////////////////////////////////////////////////////////////////////////////////////
            // Do not delete this code; use it as method to generate your mocks and undo it after you finish
            // After file is created include it into solution and make configure it so it will be copied to
            // output on build with other data
            /////////////////////////////////////////////////////////////////////////////////////////////////
            using (var dbContext = new APLABDatabaseEntities())
            {
                dbContext.Configuration.ProxyCreationEnabled = false;
                string mocksFolder = @"C:\DBMocks";
                string filePath = string.Empty;

                List<StateInfo> states = dbContext.StateInfoes.ToList();
                filePath = string.Format(@"{0}\{1}", mocksFolder, "StateInfo.xml");
                states.ForEach(x => x.Counties = null);
                MockHelper.CreateSerializedData<List<StateInfo>>(states, filePath);

                List<County> counties = dbContext.Counties.ToList();
                filePath = string.Format(@"{0}\{1}", mocksFolder, "County.xml");
                counties.ForEach(x => x.Cities = null);
                counties.ForEach(x => x.StateInfo = null);
                MockHelper.CreateSerializedData<List<County>>(counties, filePath);

                List<Zip> zips = dbContext.Zips.ToList();
                filePath = string.Format(@"{0}\{1}", mocksFolder, "Zip.xml");
                zips.ForEach(x => x.Addresses = null);
                zips.ForEach(x => x.City = null);
                MockHelper.CreateSerializedData<List<Zip>>(zips, filePath);

                List<City> cities = dbContext.Cities.ToList();
                filePath = string.Format(@"{0}\{1}", mocksFolder, "City.xml");
                cities.ForEach(x => x.County = null);
                cities.ForEach(x => x.Zips = null);
                MockHelper.CreateSerializedData<List<City>>(cities, filePath);

                List<Email> emails = dbContext.Emails.ToList();
                filePath = string.Format(@"{0}\{1}", mocksFolder, "Email.xml");
                emails.ForEach(x => x.UserDetail = null);
                MockHelper.CreateSerializedData<List<Email>>(emails, filePath);

                List<Address> addresses = dbContext.Addresses.ToList();
                filePath = string.Format(@"{0}\{1}", mocksFolder, "Address.xml");
                addresses.ForEach(x => x.UserDetail = null);
                addresses.ForEach(x => x.Zip = null);
                MockHelper.CreateSerializedData<List<Address>>(addresses, filePath);

                List<UserDetail> users = dbContext.UserDetails.ToList();
                filePath = string.Format(@"{0}\{1}", mocksFolder, "UserDetail.xml");
                users.ForEach(x => x.Emails = null);
                users.ForEach(x => x.Addresses = null);
                MockHelper.CreateSerializedData<List<UserDetail>>(users, filePath);
            }
        }
    }
}
