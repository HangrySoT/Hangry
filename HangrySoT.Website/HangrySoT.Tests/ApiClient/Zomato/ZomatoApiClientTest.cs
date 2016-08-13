using Microsoft.VisualStudio.TestTools.UnitTesting;
using HangrySoT.ApiClient.Zomato;
using HangrySoT.Website.Services;
using System.Threading.Tasks;
using PowerAssert;
using System.Linq;

namespace HangrySoT.Tests.ApiClient.Zomato
{
    [TestClass]
    public class ZomatoApiClientTest
    {
        [TestMethod]
        public async Task MakeRequestToZomatoApi()
        {
            ZomatoClient client = new ZomatoClient();
            var zomatoObject = await client.SearchByLatLon(-36.8441547,174.7576598);
            //var xizheZomatoObject = await client.SearchByLatLon(-36.842676m, 174.757502m);
            //var service = new SuperSecretSauceService();
            //var restaurantID = service.GetBestRestaurantID(xizheZomatoObject, -36.842676, 174.757502);

            PAssert.IsTrue(() => zomatoObject.restaurants.Any());
            PAssert.IsTrue(() => zomatoObject.restaurants.First().restaurant.location.longitude != null);
        }
    }
}
