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
            var zomatoObject = await client.SearchByLatLon();
            //var xizheZomatoObject = await client.SearchByLatLon(-36.934186m, 174.939321m);
            //var service = new SuperSecretSauceService();
            //var updatedZomatoObject = service.GetBestRestaurant(xizheZomatoObject, -36.934186, 174.939321);

            PAssert.IsTrue(() => zomatoObject.restaurants.Any());
            PAssert.IsTrue(() => zomatoObject.restaurants.First().restaurant.location.longitude != null);
            //PAssert.IsTrue(() => updatedZomatoObject.restaurants.First().restaurant.average_cost_for_two > 38);
            //PAssert.IsTrue(() => updatedZomatoObject.restaurants.First().restaurant.average_cost_for_two < 41);
        }
    }
}
