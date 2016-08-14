using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Linq;
using PowerAssert;
using HangrySoT.ApiClient.Models;

namespace HangrySoT.Tests.Models
{
    [TestClass]
    public class ZomatoDeserialiseTest
    {

        const string rawResponse = @"{
	""results_found"": 3463,
	""results_start"": 0,
	""results_shown"": 20,
	""restaurants"": [{
		""restaurant"": {
			""R"": {
				""res_id"": 7000845

            },
			""apikey"": ""585d38cc23efda0e246ba9cc052fdcfa"",
			""id"": ""7000845"",
			""name"": ""21 Viaduct Cafe - Sofitel Auckland Viaduct Harbour"",
			""url"": ""https:\/\/www.zomato.com\/auckland\/21-viaduct-cafe-sofitel-auckland-viaduct-harbour-viaduct-harbour?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
			""location"": {
				""address"": ""Sofitel, 21 Viaduct Harbour, Viaduct Harbour, Auckland CBD, Auckland 1010"",
				""locality"": ""Viaduct Harbour"",
				""city"": ""Auckland"",
				""city_id"": 70,
				""latitude"": ""-36.8444440000"",
				""longitude"": ""174.7575650000"",
				""zipcode"": ""1010"",
				""country_id"": 148
			},
			""cuisines"": ""Cafe, French, European"",
			""average_cost_for_two"": 50,
			""price_range"": 3,
			""currency"": ""NZ$"",
			""offers"": [],
			""thumb"": ""https:\/\/b.zmtcdn.com\/data\/pictures\/5\/7000845\/c4ad2f75581bcb0967ef9b88fe01bf17_featured_v2.jpg"",
			""user_rating"": {
				""aggregate_rating"": ""3.4"",
				""rating_text"": ""Good"",
				""rating_color"": ""9ACD32"",
				""votes"": ""14""
			},
			""photos_url"": ""https:\/\/www.zomato.com\/auckland\/21-viaduct-cafe-sofitel-auckland-viaduct-harbour-viaduct-harbour\/photos#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
			""menu_url"": ""https:\/\/www.zomato.com\/auckland\/21-viaduct-cafe-sofitel-auckland-viaduct-harbour-viaduct-harbour\/menu#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
			""featured_image"": ""https:\/\/b.zmtcdn.com\/data\/pictures\/5\/7000845\/c4ad2f75581bcb0967ef9b88fe01bf17_featured_v2.jpg"",
			""has_online_delivery"": 0,
			""is_delivering_now"": 0,
			""deeplink"": ""zomato:\/\/r\/7000845"",
			""events_url"": ""https:\/\/www.zomato.com\/auckland\/21-viaduct-cafe-sofitel-auckland-viaduct-harbour-viaduct-harbour\/events#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
			""establishment_types"": []
		}
	},
	{
		""restaurant"": {
			""R"": {
				""res_id"": 7001684
			},
			""apikey"": ""585d38cc23efda0e246ba9cc052fdcfa"",
			""id"": ""7001684"",
			""name"": ""Sabrage Bar - Sofitel Auckland Viaduct Harbour"",
			""url"": ""https:\/\/www.zomato.com\/auckland\/sabrage-bar-sofitel-auckland-viaduct-harbour-viaduct-harbour?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
			""location"": {
				""address"": ""Sofitel, Viaduct Harbour, Auckland CBD, Auckland 1010 1010"",
				""locality"": ""Viaduct Harbour"",
				""city"": ""Auckland"",
				""city_id"": 70,
				""latitude"": ""-36.8444440000"",
				""longitude"": ""174.7575650000"",
				""zipcode"": ""1010"",
				""country_id"": 148
			},
			""cuisines"": ""European"",
			""average_cost_for_two"": 80,
			""price_range"": 4,
			""currency"": ""NZ$"",
			""offers"": [],
			""thumb"": ""https:\/\/b.zmtcdn.com\/data\/pictures\/4\/7001684\/36bcf012e61159495ca1d98f67d7c057_featured_v2.jpg"",
			""user_rating"": {
				""aggregate_rating"": ""3.3"",
				""rating_text"": ""Good"",
				""rating_color"": ""9ACD32"",
				""votes"": ""8""
			},
			""photos_url"": ""https:\/\/www.zomato.com\/auckland\/sabrage-bar-sofitel-auckland-viaduct-harbour-viaduct-harbour\/photos#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
			""menu_url"": ""https:\/\/www.zomato.com\/auckland\/sabrage-bar-sofitel-auckland-viaduct-harbour-viaduct-harbour\/menu#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
			""featured_image"": ""https:\/\/b.zmtcdn.com\/data\/pictures\/4\/7001684\/36bcf012e61159495ca1d98f67d7c057_featured_v2.jpg"",
			""has_online_delivery"": 0,
			""is_delivering_now"": 0,
			""deeplink"": ""zomato:\/\/r\/7001684"",
			""events_url"": ""https:\/\/www.zomato.com\/auckland\/sabrage-bar-sofitel-auckland-viaduct-harbour-viaduct-harbour\/events#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
			""establishment_types"": []
		}	
	}]
}";

        [TestMethod]
        public void WhenDeserialisingZomatoResponseSelectedPropertiesAreCorrect()
        {

            var thing = JsonConvert.DeserializeObject<ZomatoResponse>(rawResponse);
            PAssert.IsTrue(() => thing.restaurants.Any());
            PAssert.IsTrue(() => thing.restaurants.First().restaurant.location.latitude == "-36.8444440000" );


        }
    }
}
