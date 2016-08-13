using Microsoft.VisualStudio.TestTools.UnitTesting;
using HangrySoT.ApiClient.Zomato;
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

            PAssert.IsTrue(() => zomatoObject.restaurants.Any());
            PAssert.IsTrue(() => zomatoObject.restaurants.First().restaurant.location.longitude != null);

        }
    }
}
