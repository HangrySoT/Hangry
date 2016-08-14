using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using HangrySoT.Website.Models;
using System.Linq;
using PowerAssert;
using HangrySoT.ApiClient.Models;
using Microsoft.ProjectOxford.Emotion.Contract;
using HangrySoT.Website.Services;

namespace HangrySoT.Tests.Hangry
{
    [TestClass]
    public class EmotionEngineTestts
    {
        #region Response String
        const string rawResponse = @"{
  ""results_found"": 2054,
  ""results_start"": 0,
  ""results_shown"": 20,
  ""restaurants"": [
    {
      ""restaurant"": {
        ""R"": {
          ""res_id"": 7000170
        },
        ""apikey"": ""13ad8f24c1e8ba215d919ac0899dff61"",
        ""id"": ""7000170"",
        ""name"": ""Stark's"",
        ""url"": ""https://www.zomato.com/auckland/starks-queen-street?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""location"": {
          ""address"": ""The Civic Theatre, 269-273   CBD, Auckland, Queen Street, Auckland"",
          ""locality"": ""Queen Street"",
          ""city"": ""Auckland"",
          ""city_id"": 70,
          ""latitude"": ""-36.8510000000"",
          ""longitude"": ""174.7645000000"",
          ""zipcode"": """",
          ""country_id"": 148
        },
        ""cuisines"": ""Cafe"",
        ""average_cost_for_two"": 45,
        ""price_range"": 3,
        ""currency"": ""NZ$"",
        ""offers"": [],
        ""thumb"": ""https://b.zmtcdn.com/data/pictures/0/7000170/2b8d767b3d627fbef15dcd2a3d50d41d_featured_v2.jpg"",
        ""user_rating"": {
          ""aggregate_rating"": ""2.9"",
          ""rating_text"": ""Average"",
          ""rating_color"": ""EDD614"",
          ""votes"": ""9""
        },
        ""photos_url"": ""https://www.zomato.com/auckland/starks-queen-street/photos#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""menu_url"": ""https://www.zomato.com/auckland/starks-queen-street/menu#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""featured_image"": ""https://b.zmtcdn.com/data/pictures/0/7000170/2b8d767b3d627fbef15dcd2a3d50d41d_featured_v2.jpg"",
        ""has_online_delivery"": 0,
        ""is_delivering_now"": 0,
        ""deeplink"": ""zomato://r/7000170"",
        ""events_url"": ""https://www.zomato.com/auckland/starks-queen-street/events#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""establishment_types"": []
      }
    },
    {
      ""restaurant"": {
        ""R"": {
          ""res_id"": 7001341
        },
        ""apikey"": ""13ad8f24c1e8ba215d919ac0899dff61"",
        ""id"": ""7001341"",
        ""name"": ""Bangkok Restaurant & Bar"",
        ""url"": ""https://www.zomato.com/auckland/bangkok-restaurant-bar-wellesley-street-west?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""location"": {
          ""address"": ""2/49-55 Anzac Avenue, Auckland CBD, Auckland 1010"",
          ""locality"": ""Wellesley Street West"",
          ""city"": ""Auckland"",
          ""city_id"": 70,
          ""latitude"": ""-36.8507912575"",
          ""longitude"": ""174.7644279152"",
          ""zipcode"": ""1010"",
          ""country_id"": 148
        },
        ""cuisines"": ""Thai"",
        ""average_cost_for_two"": 60,
        ""price_range"": 3,
        ""currency"": ""NZ$"",
        ""offers"": [],
        ""thumb"": ""https://b.zmtcdn.com/data/pictures/1/7001341/d762bc536d6888388a222367604865aa_featured_v2.jpg"",
        ""user_rating"": {
          ""aggregate_rating"": ""3.7"",
          ""rating_text"": ""Very Good"",
          ""rating_color"": ""5BA829"",
          ""votes"": ""70""
        },
        ""photos_url"": ""https://www.zomato.com/auckland/bangkok-restaurant-bar-wellesley-street-west/photos#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""menu_url"": ""https://www.zomato.com/auckland/bangkok-restaurant-bar-wellesley-street-west/menu#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""featured_image"": ""https://b.zmtcdn.com/data/pictures/1/7001341/d762bc536d6888388a222367604865aa_featured_v2.jpg"",
        ""has_online_delivery"": 0,
        ""is_delivering_now"": 0,
        ""deeplink"": ""zomato://r/7001341"",
        ""events_url"": ""https://www.zomato.com/auckland/bangkok-restaurant-bar-wellesley-street-west/events#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""establishment_types"": []
      }
    },
    {
      ""restaurant"": {
        ""R"": {
          ""res_id"": 7000176
        },
        ""apikey"": ""13ad8f24c1e8ba215d919ac0899dff61"",
        ""id"": ""7000176"",
        ""name"": ""Kebabs On Queen"",
        ""url"": ""https://www.zomato.com/auckland/kebabs-queen-queen-street?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""location"": {
          ""address"": ""300 Queen Street, Auckland CBD, Auckland"",
          ""locality"": ""Queen Street"",
          ""city"": ""Auckland"",
          ""city_id"": 70,
          ""latitude"": ""-36.8510240000"",
          ""longitude"": ""174.7647180000"",
          ""zipcode"": """",
          ""country_id"": 148
        },
        ""cuisines"": ""Turkish, Fast Food"",
        ""average_cost_for_two"": 30,
        ""price_range"": 2,
        ""currency"": ""NZ$"",
        ""offers"": [],
        ""thumb"": ""https://b.zmtcdn.com/data/pictures/chains/6/7000176/e27ae99066850b1666341cf60aba3ae2_featured_v2.jpg"",
        ""user_rating"": {
          ""aggregate_rating"": ""3.6"",
          ""rating_text"": ""Very Good"",
          ""rating_color"": ""5BA829"",
          ""votes"": ""38""
        },
        ""photos_url"": ""https://www.zomato.com/auckland/kebabs-queen-queen-street/photos#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""menu_url"": ""https://www.zomato.com/auckland/kebabs-queen-queen-street/menu#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""featured_image"": ""https://b.zmtcdn.com/data/pictures/chains/6/7000176/e27ae99066850b1666341cf60aba3ae2_featured_v2.jpg"",
        ""has_online_delivery"": 0,
        ""is_delivering_now"": 0,
        ""deeplink"": ""zomato://r/7000176"",
        ""events_url"": ""https://www.zomato.com/auckland/kebabs-queen-queen-street/events#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""establishment_types"": []
      }
    },
    {
      ""restaurant"": {
        ""R"": {
          ""res_id"": 7000409
        },
        ""apikey"": ""13ad8f24c1e8ba215d919ac0899dff61"",
        ""id"": ""7000409"",
        ""name"": ""Nol Bu Ne"",
        ""url"": ""https://www.zomato.com/auckland/nol-bu-ne-wellesley-street-east?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""location"": {
          ""address"": ""Choice Plaza, Level 1 & 2, 10 CBD, Wellesley Street East, Auckland 1010"",
          ""locality"": ""Wellesley Street East"",
          ""city"": ""Auckland"",
          ""city_id"": 70,
          ""latitude"": ""-36.8507810626"",
          ""longitude"": ""174.7648027539"",
          ""zipcode"": ""1010"",
          ""country_id"": 148
        },
        ""cuisines"": ""Korean"",
        ""average_cost_for_two"": 50,
        ""price_range"": 3,
        ""currency"": ""NZ$"",
        ""offers"": [],
        ""thumb"": ""https://b.zmtcdn.com/data/pictures/9/7000409/55f308ce3806ec465d69b5d4475b0960_featured_v2.jpg"",
        ""user_rating"": {
          ""aggregate_rating"": ""3.9"",
          ""rating_text"": ""Very Good"",
          ""rating_color"": ""5BA829"",
          ""votes"": ""117""
        },
        ""photos_url"": ""https://www.zomato.com/auckland/nol-bu-ne-wellesley-street-east/photos#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""menu_url"": ""https://www.zomato.com/auckland/nol-bu-ne-wellesley-street-east/menu#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""featured_image"": ""https://b.zmtcdn.com/data/pictures/9/7000409/55f308ce3806ec465d69b5d4475b0960_featured_v2.jpg"",
        ""has_online_delivery"": 0,
        ""is_delivering_now"": 0,
        ""deeplink"": ""zomato://r/7000409"",
        ""events_url"": ""https://www.zomato.com/auckland/nol-bu-ne-wellesley-street-east/events#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""establishment_types"": []
      }
    },
    {
      ""restaurant"": {
        ""R"": {
          ""res_id"": 7003939
        },
        ""apikey"": ""13ad8f24c1e8ba215d919ac0899dff61"",
        ""id"": ""7003939"",
        ""name"": ""Yoghurt Story"",
        ""url"": ""https://www.zomato.com/auckland/yoghurt-story-1-queen-street?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""location"": {
          ""address"": ""Civic Theatre, 277 Queen Street, Auckland CBD, Auckland 1010"",
          ""locality"": ""Queen Street"",
          ""city"": ""Auckland"",
          ""city_id"": 70,
          ""latitude"": ""-36.8509340000"",
          ""longitude"": ""174.7641960000"",
          ""zipcode"": ""1010"",
          ""country_id"": 148
        },
        ""cuisines"": ""Desserts"",
        ""average_cost_for_two"": 20,
        ""price_range"": 1,
        ""currency"": ""NZ$"",
        ""offers"": [],
        ""thumb"": ""https://b.zmtcdn.com/data/pictures/chains/6/7000906/fd091518adf22f317c0e04533b34d00c_featured_v2.png"",
        ""user_rating"": {
          ""aggregate_rating"": ""3.3"",
          ""rating_text"": ""Good"",
          ""rating_color"": ""9ACD32"",
          ""votes"": ""22""
        },
        ""photos_url"": ""https://www.zomato.com/auckland/yoghurt-story-1-queen-street/photos#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""menu_url"": ""https://www.zomato.com/auckland/yoghurt-story-1-queen-street/menu#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""featured_image"": ""https://b.zmtcdn.com/data/pictures/chains/6/7000906/fd091518adf22f317c0e04533b34d00c_featured_v2.png"",
        ""has_online_delivery"": 0,
        ""is_delivering_now"": 0,
        ""deeplink"": ""zomato://r/7003939"",
        ""events_url"": ""https://www.zomato.com/auckland/yoghurt-story-1-queen-street/events#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""establishment_types"": []
      }
    },
    {
      ""restaurant"": {
        ""R"": {
          ""res_id"": 7000688
        },
        ""apikey"": ""13ad8f24c1e8ba215d919ac0899dff61"",
        ""id"": ""7000688"",
        ""name"": ""Yogoberry Cafe"",
        ""url"": ""https://www.zomato.com/auckland/yogoberry-cafe-queen-street?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""location"": {
          ""address"": ""290 Queen Street, Auckland CBD, Auckland"",
          ""locality"": ""Queen Street"",
          ""city"": ""Auckland"",
          ""city_id"": 70,
          ""latitude"": ""-36.8510000000"",
          ""longitude"": ""174.7648333333"",
          ""zipcode"": """",
          ""country_id"": 148
        },
        ""cuisines"": ""Desserts, Ice Cream, Beverages"",
        ""average_cost_for_two"": 25,
        ""price_range"": 1,
        ""currency"": ""NZ$"",
        ""offers"": [],
        ""thumb"": ""https://b.zmtcdn.com/data/pictures/8/7000688/16ed709f8ebf3cfe898856f34448e92c_featured_v2.jpg"",
        ""user_rating"": {
          ""aggregate_rating"": ""3.8"",
          ""rating_text"": ""Very Good"",
          ""rating_color"": ""5BA829"",
          ""votes"": ""39""
        },
        ""photos_url"": ""https://www.zomato.com/auckland/yogoberry-cafe-queen-street/photos#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""menu_url"": ""https://www.zomato.com/auckland/yogoberry-cafe-queen-street/menu#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""featured_image"": ""https://b.zmtcdn.com/data/pictures/8/7000688/16ed709f8ebf3cfe898856f34448e92c_featured_v2.jpg"",
        ""has_online_delivery"": 0,
        ""is_delivering_now"": 0,
        ""deeplink"": ""zomato://r/7000688"",
        ""events_url"": ""https://www.zomato.com/auckland/yogoberry-cafe-queen-street/events#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""establishment_types"": []
      }
    },
    {
      ""restaurant"": {
        ""R"": {
          ""res_id"": 7006912
        },
        ""apikey"": ""13ad8f24c1e8ba215d919ac0899dff61"",
        ""id"": ""7006912"",
        ""name"": ""St. James Cafe"",
        ""url"": ""https://www.zomato.com/auckland/st-james-theatre-cafe-queen-street?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""location"": {
          ""address"": ""312 Queen Street, Auckland CBD, Auckland"",
          ""locality"": ""Queen Street"",
          ""city"": ""Auckland"",
          ""city_id"": 70,
          ""latitude"": ""-36.8511220000"",
          ""longitude"": ""174.7643150000"",
          ""zipcode"": """",
          ""country_id"": 148
        },
        ""cuisines"": ""Cafe"",
        ""average_cost_for_two"": 0,
        ""price_range"": 1,
        ""currency"": ""NZ$"",
        ""offers"": [],
        ""thumb"": """",
        ""user_rating"": {
          ""aggregate_rating"": ""0"",
          ""rating_text"": ""Not rated"",
          ""rating_color"": ""CBCBC8"",
          ""votes"": ""0""
        },
        ""photos_url"": ""https://www.zomato.com/auckland/st-james-theatre-cafe-queen-street/photos#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""menu_url"": ""https://www.zomato.com/auckland/st-james-theatre-cafe-queen-street/menu#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""featured_image"": """",
        ""has_online_delivery"": 0,
        ""is_delivering_now"": 0,
        ""deeplink"": ""zomato://r/7006912"",
        ""events_url"": ""https://www.zomato.com/auckland/st-james-theatre-cafe-queen-street/events#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""establishment_types"": []
      }
    },
    {
      ""restaurant"": {
        ""R"": {
          ""res_id"": 7000710
        },
        ""apikey"": ""13ad8f24c1e8ba215d919ac0899dff61"",
        ""id"": ""7000710"",
        ""name"": ""Jax Munster Inn"",
        ""url"": ""https://www.zomato.com/auckland/jax-munster-inn-wellesley-street-west?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""location"": {
          ""address"": ""1  Wellesley Street West, Auckland CBD, Auckland 1010"",
          ""locality"": ""Wellesley Street West"",
          ""city"": ""Auckland"",
          ""city_id"": 70,
          ""latitude"": ""-36.8506666667"",
          ""longitude"": ""174.7643333333"",
          ""zipcode"": ""1010"",
          ""country_id"": 148
        },
        ""cuisines"": ""European, Kiwi, Finger Food"",
        ""average_cost_for_two"": 75,
        ""price_range"": 4,
        ""currency"": ""NZ$"",
        ""offers"": [],
        ""thumb"": ""https://b.zmtcdn.com/data/pictures/0/7000710/e20908f1743df17d7de33f930b4bd8e9_featured_v2.jpg"",
        ""user_rating"": {
          ""aggregate_rating"": ""2.9"",
          ""rating_text"": ""Average"",
          ""rating_color"": ""EDD614"",
          ""votes"": ""5""
        },
        ""photos_url"": ""https://www.zomato.com/auckland/jax-munster-inn-wellesley-street-west/photos#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""menu_url"": ""https://www.zomato.com/auckland/jax-munster-inn-wellesley-street-west/menu#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""featured_image"": ""https://b.zmtcdn.com/data/pictures/0/7000710/e20908f1743df17d7de33f930b4bd8e9_featured_v2.jpg"",
        ""has_online_delivery"": 0,
        ""is_delivering_now"": 0,
        ""deeplink"": ""zomato://r/7000710"",
        ""events_url"": ""https://www.zomato.com/auckland/jax-munster-inn-wellesley-street-west/events#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""establishment_types"": []
      }
    },
    {
      ""restaurant"": {
        ""R"": {
          ""res_id"": 7000715
        },
        ""apikey"": ""13ad8f24c1e8ba215d919ac0899dff61"",
        ""id"": ""7000715"",
        ""name"": ""Father Ted's Irish Bar"",
        ""url"": ""https://www.zomato.com/auckland/father-teds-irish-bar-wellesley-street-west?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""location"": {
          ""address"": ""1   CBD, Auckland, Wellesley Street West, Auckland 1010"",
          ""locality"": ""Wellesley Street West"",
          ""city"": ""Auckland"",
          ""city_id"": 70,
          ""latitude"": ""-36.8508333333"",
          ""longitude"": ""174.7641666667"",
          ""zipcode"": ""1010"",
          ""country_id"": 148
        },
        ""cuisines"": ""Steakhouse, Irish"",
        ""average_cost_for_two"": 75,
        ""price_range"": 4,
        ""currency"": ""NZ$"",
        ""offers"": [],
        ""thumb"": ""https://b.zmtcdn.com/data/pictures/5/7000715/aeba700c96eae6c21dd7d8ac5851b428_featured_v2.jpg"",
        ""user_rating"": {
          ""aggregate_rating"": ""3.6"",
          ""rating_text"": ""Very Good"",
          ""rating_color"": ""5BA829"",
          ""votes"": ""41""
        },
        ""photos_url"": ""https://www.zomato.com/auckland/father-teds-irish-bar-wellesley-street-west/photos#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""menu_url"": ""https://www.zomato.com/auckland/father-teds-irish-bar-wellesley-street-west/menu#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""featured_image"": ""https://b.zmtcdn.com/data/pictures/5/7000715/aeba700c96eae6c21dd7d8ac5851b428_featured_v2.jpg"",
        ""has_online_delivery"": 0,
        ""is_delivering_now"": 0,
        ""deeplink"": ""zomato://r/7000715"",
        ""events_url"": ""https://www.zomato.com/auckland/father-teds-irish-bar-wellesley-street-west/events#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""establishment_types"": []
      }
    },
    {
      ""restaurant"": {
        ""R"": {
          ""res_id"": 7000144
        },
        ""apikey"": ""13ad8f24c1e8ba215d919ac0899dff61"",
        ""id"": ""7000144"",
        ""name"": ""BBQ Duck Cafe"",
        ""url"": ""https://www.zomato.com/auckland/bbq-duck-cafe-queen-street?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""location"": {
          ""address"": ""304 Queen Street, Auckland CBD, Auckland"",
          ""locality"": ""Queen Street"",
          ""city"": ""Auckland"",
          ""city_id"": 70,
          ""latitude"": ""-36.8510000000"",
          ""longitude"": ""174.7641666667"",
          ""zipcode"": """",
          ""country_id"": 148
        },
        ""cuisines"": ""Chinese"",
        ""average_cost_for_two"": 40,
        ""price_range"": 2,
        ""currency"": ""NZ$"",
        ""offers"": [],
        ""thumb"": ""https://b.zmtcdn.com/data/pictures/4/7000144/fe325ebb73015b214396d3bec1a6a7d3_featured_v2.jpg"",
        ""user_rating"": {
          ""aggregate_rating"": ""3.7"",
          ""rating_text"": ""Very Good"",
          ""rating_color"": ""5BA829"",
          ""votes"": ""92""
        },
        ""photos_url"": ""https://www.zomato.com/auckland/bbq-duck-cafe-queen-street/photos#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""menu_url"": ""https://www.zomato.com/auckland/bbq-duck-cafe-queen-street/menu#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""featured_image"": ""https://b.zmtcdn.com/data/pictures/4/7000144/fe325ebb73015b214396d3bec1a6a7d3_featured_v2.jpg"",
        ""has_online_delivery"": 0,
        ""is_delivering_now"": 0,
        ""deeplink"": ""zomato://r/7000144"",
        ""events_url"": ""https://www.zomato.com/auckland/bbq-duck-cafe-queen-street/events#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""establishment_types"": []
      }
    },
    {
      ""restaurant"": {
        ""R"": {
          ""res_id"": 7000120
        },
        ""apikey"": ""13ad8f24c1e8ba215d919ac0899dff61"",
        ""id"": ""7000120"",
        ""name"": ""Sal's"",
        ""url"": ""https://www.zomato.com/auckland/sals-queen-street?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""location"": {
          ""address"": ""265   CBD, Auckland, Queen Street, Auckland"",
          ""locality"": ""Queen Street"",
          ""city"": ""Auckland"",
          ""city_id"": 70,
          ""latitude"": ""-36.8506666667"",
          ""longitude"": ""174.7648333333"",
          ""zipcode"": """",
          ""country_id"": 148
        },
        ""cuisines"": ""Pizza, Fast Food"",
        ""average_cost_for_two"": 40,
        ""price_range"": 2,
        ""currency"": ""NZ$"",
        ""offers"": [],
        ""thumb"": ""https://b.zmtcdn.com/data/pictures/0/7000120/35756c1228484015b27ffc63b60c0c6e_featured_v2.jpg"",
        ""user_rating"": {
          ""aggregate_rating"": ""3.8"",
          ""rating_text"": ""Very Good"",
          ""rating_color"": ""5BA829"",
          ""votes"": ""74""
        },
        ""photos_url"": ""https://www.zomato.com/auckland/sals-queen-street/photos#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""menu_url"": ""https://www.zomato.com/auckland/sals-queen-street/menu#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""featured_image"": ""https://b.zmtcdn.com/data/pictures/0/7000120/35756c1228484015b27ffc63b60c0c6e_featured_v2.jpg"",
        ""has_online_delivery"": 0,
        ""is_delivering_now"": 0,
        ""deeplink"": ""zomato://r/7000120"",
        ""events_url"": ""https://www.zomato.com/auckland/sals-queen-street/events#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""establishment_types"": []
      }
    },
    {
      ""restaurant"": {
        ""R"": {
          ""res_id"": 7001352
        },
        ""apikey"": ""13ad8f24c1e8ba215d919ac0899dff61"",
        ""id"": ""7001352"",
        ""name"": ""Bentto"",
        ""url"": ""https://www.zomato.com/auckland/bentto-queen-street?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""location"": {
          ""address"": ""Shop 8, 290 Queen Street, Auckland CBD, Auckland"",
          ""locality"": ""Queen Street"",
          ""city"": ""Auckland"",
          ""city_id"": 70,
          ""latitude"": ""-36.8511666667"",
          ""longitude"": ""174.7648333333"",
          ""zipcode"": """",
          ""country_id"": 148
        },
        ""cuisines"": ""Japanese, Sushi"",
        ""average_cost_for_two"": 40,
        ""price_range"": 2,
        ""currency"": ""NZ$"",
        ""offers"": [],
        ""thumb"": ""https://b.zmtcdn.com/data/pictures/2/7001352/f77be37f79fd6dc1ff3fe4b8415e1172_featured_v2.jpg"",
        ""user_rating"": {
          ""aggregate_rating"": ""3.7"",
          ""rating_text"": ""Very Good"",
          ""rating_color"": ""5BA829"",
          ""votes"": ""34""
        },
        ""photos_url"": ""https://www.zomato.com/auckland/bentto-queen-street/photos#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""menu_url"": ""https://www.zomato.com/auckland/bentto-queen-street/menu#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""featured_image"": ""https://b.zmtcdn.com/data/pictures/2/7001352/f77be37f79fd6dc1ff3fe4b8415e1172_featured_v2.jpg"",
        ""has_online_delivery"": 0,
        ""is_delivering_now"": 0,
        ""deeplink"": ""zomato://r/7001352"",
        ""events_url"": ""https://www.zomato.com/auckland/bentto-queen-street/events#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""establishment_types"": []
      }
    },
    {
      ""restaurant"": {
        ""R"": {
          ""res_id"": 7006732
        },
        ""apikey"": ""13ad8f24c1e8ba215d919ac0899dff61"",
        ""id"": ""7006732"",
        ""name"": ""Tank Juice Bar"",
        ""url"": ""https://www.zomato.com/auckland/tank-juice-bar-queen-street?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""location"": {
          ""address"": ""290 Queen Street, Auckland CBD, Auckland"",
          ""locality"": ""Queen Street"",
          ""city"": ""Auckland"",
          ""city_id"": 70,
          ""latitude"": ""-36.8506020000"",
          ""longitude"": ""174.7648460000"",
          ""zipcode"": """",
          ""country_id"": 148
        },
        ""cuisines"": ""Healthy Food, Juices"",
        ""average_cost_for_two"": 35,
        ""price_range"": 2,
        ""currency"": ""NZ$"",
        ""offers"": [],
        ""thumb"": ""https://b.zmtcdn.com/data/pictures/2/7006732/0d6a36d8be9c2b1247d96de5eaeddcc7_featured_v2.png"",
        ""user_rating"": {
          ""aggregate_rating"": ""3.5"",
          ""rating_text"": ""Good"",
          ""rating_color"": ""9ACD32"",
          ""votes"": ""13""
        },
        ""photos_url"": ""https://www.zomato.com/auckland/tank-juice-bar-queen-street/photos#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""menu_url"": ""https://www.zomato.com/auckland/tank-juice-bar-queen-street/menu#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""featured_image"": ""https://b.zmtcdn.com/data/pictures/2/7006732/0d6a36d8be9c2b1247d96de5eaeddcc7_featured_v2.png"",
        ""has_online_delivery"": 0,
        ""is_delivering_now"": 0,
        ""deeplink"": ""zomato://r/7006732"",
        ""events_url"": ""https://www.zomato.com/auckland/tank-juice-bar-queen-street/events#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""establishment_types"": []
      }
    },
    {
      ""restaurant"": {
        ""R"": {
          ""res_id"": 7009349
        },
        ""apikey"": ""13ad8f24c1e8ba215d919ac0899dff61"",
        ""id"": ""7009349"",
        ""name"": ""Achos"",
        ""url"": ""https://www.zomato.com/achos-food-truck?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""location"": {
          ""address"": ""Location Varies, Queen Street, Auckland Auckland CBD"",
          ""locality"": ""Queen Street"",
          ""city"": ""Auckland"",
          ""city_id"": 70,
          ""latitude"": ""0.0000000000"",
          ""longitude"": ""0.0000000000"",
          ""zipcode"": """",
          ""country_id"": 148
        },
        ""cuisines"": ""Asian"",
        ""average_cost_for_two"": 35,
        ""price_range"": 2,
        ""currency"": ""NZ$"",
        ""offers"": [],
        ""thumb"": """",
        ""user_rating"": {
          ""aggregate_rating"": ""0"",
          ""rating_text"": ""Not rated"",
          ""rating_color"": ""CBCBC8"",
          ""votes"": ""2""
        },
        ""photos_url"": ""https://www.zomato.com/achos-food-truck/photos#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""menu_url"": ""https://www.zomato.com/achos-food-truck/menu#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""featured_image"": """",
        ""has_online_delivery"": 0,
        ""is_delivering_now"": 0,
        ""deeplink"": ""zomato://r/7009349"",
        ""events_url"": ""https://www.zomato.com/achos-food-truck/events#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""establishment_types"": []
      }
    },
    {
      ""restaurant"": {
        ""R"": {
          ""res_id"": 18319164
        },
        ""apikey"": ""13ad8f24c1e8ba215d919ac0899dff61"",
        ""id"": ""18319164"",
        ""name"": ""Downtown Kebab"",
        ""url"": ""https://www.zomato.com/auckland/downtown-kebab-queen-street?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""location"": {
          ""address"": ""2, Queen Street, Auckland"",
          ""locality"": ""Queen Street"",
          ""city"": ""Auckland"",
          ""city_id"": 70,
          ""latitude"": ""0.0000000000"",
          ""longitude"": ""0.0000000000"",
          ""zipcode"": """",
          ""country_id"": 148
        },
        ""cuisines"": ""Turkish, Mexican"",
        ""average_cost_for_two"": 30,
        ""price_range"": 2,
        ""currency"": ""NZ$"",
        ""offers"": [],
        ""thumb"": ""https://b.zmtcdn.com/data/pictures/chains/6/18319136/617da002e7be86fa9d1d40c9722a04d3_featured_v2.jpg"",
        ""user_rating"": {
          ""aggregate_rating"": ""0"",
          ""rating_text"": ""Not rated"",
          ""rating_color"": ""CBCBC8"",
          ""votes"": ""0""
        },
        ""photos_url"": ""https://www.zomato.com/auckland/downtown-kebab-queen-street/photos#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""menu_url"": ""https://www.zomato.com/auckland/downtown-kebab-queen-street/menu#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""featured_image"": ""https://b.zmtcdn.com/data/pictures/chains/6/18319136/617da002e7be86fa9d1d40c9722a04d3_featured_v2.jpg"",
        ""has_online_delivery"": 0,
        ""is_delivering_now"": 0,
        ""deeplink"": ""zomato://r/18319164"",
        ""events_url"": ""https://www.zomato.com/auckland/downtown-kebab-queen-street/events#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""establishment_types"": []
      }
    },
    {
      ""restaurant"": {
        ""R"": {
          ""res_id"": 7000524
        },
        ""apikey"": ""13ad8f24c1e8ba215d919ac0899dff61"",
        ""id"": ""7000524"",
        ""name"": ""Burger King"",
        ""url"": ""https://www.zomato.com/auckland/burger-king-1-queen-street?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""location"": {
          ""address"": ""Sky City Metro, 291-297 Queen Street, Auckland CBD, Auckland"",
          ""locality"": ""Queen Street"",
          ""city"": ""Auckland"",
          ""city_id"": 70,
          ""latitude"": ""0.0000000000"",
          ""longitude"": ""174.7639640000"",
          ""zipcode"": """",
          ""country_id"": 148
        },
        ""cuisines"": ""Fast Food"",
        ""average_cost_for_two"": 20,
        ""price_range"": 1,
        ""currency"": ""NZ$"",
        ""offers"": [],
        ""thumb"": """",
        ""user_rating"": {
          ""aggregate_rating"": ""2.5"",
          ""rating_text"": ""Average"",
          ""rating_color"": ""FFBA00"",
          ""votes"": ""16""
        },
        ""photos_url"": ""https://www.zomato.com/auckland/burger-king-1-queen-street/photos#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""menu_url"": ""https://www.zomato.com/auckland/burger-king-1-queen-street/menu#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""featured_image"": """",
        ""has_online_delivery"": 0,
        ""is_delivering_now"": 0,
        ""deeplink"": ""zomato://r/7000524"",
        ""events_url"": ""https://www.zomato.com/auckland/burger-king-1-queen-street/events#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""establishment_types"": []
      }
    },
    {
      ""restaurant"": {
        ""R"": {
          ""res_id"": 7000365
        },
        ""apikey"": ""13ad8f24c1e8ba215d919ac0899dff61"",
        ""id"": ""7000365"",
        ""name"": ""The Gateau House"",
        ""url"": ""https://www.zomato.com/auckland/the-gateau-house-queen-street?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""location"": {
          ""address"": ""332 Queen Street, Auckland CBD, Auckland"",
          ""locality"": ""Queen Street"",
          ""city"": ""Auckland"",
          ""city_id"": 70,
          ""latitude"": ""-36.8513030000"",
          ""longitude"": ""174.7644280000"",
          ""zipcode"": """",
          ""country_id"": 148
        },
        ""cuisines"": ""Desserts, Coffee and Tea"",
        ""average_cost_for_two"": 30,
        ""price_range"": 2,
        ""currency"": ""NZ$"",
        ""offers"": [],
        ""thumb"": ""https://b.zmtcdn.com/data/pictures/5/7000365/6c6a2697268f6b6827e9be807cf1c893_featured_v2.jpg"",
        ""user_rating"": {
          ""aggregate_rating"": ""4.1"",
          ""rating_text"": ""Excellent"",
          ""rating_color"": ""3F7E00"",
          ""votes"": ""96""
        },
        ""photos_url"": ""https://www.zomato.com/auckland/the-gateau-house-queen-street/photos#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""menu_url"": ""https://www.zomato.com/auckland/the-gateau-house-queen-street/menu#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""featured_image"": ""https://b.zmtcdn.com/data/pictures/5/7000365/6c6a2697268f6b6827e9be807cf1c893_featured_v2.jpg"",
        ""has_online_delivery"": 0,
        ""is_delivering_now"": 0,
        ""deeplink"": ""zomato://r/7000365"",
        ""events_url"": ""https://www.zomato.com/auckland/the-gateau-house-queen-street/events#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""establishment_types"": []
      }
    },
    {
      ""restaurant"": {
        ""R"": {
          ""res_id"": 7000130
        },
        ""apikey"": ""13ad8f24c1e8ba215d919ac0899dff61"",
        ""id"": ""7000130"",
        ""name"": ""Wendy's"",
        ""url"": ""https://www.zomato.com/auckland/wendys-queen-street?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""location"": {
          ""address"": ""290 Queen Street, Auckland CBD, Auckland"",
          ""locality"": ""Queen Street"",
          ""city"": ""Auckland"",
          ""city_id"": 70,
          ""latitude"": ""-36.8505000000"",
          ""longitude"": ""174.7643333333"",
          ""zipcode"": """",
          ""country_id"": 148
        },
        ""cuisines"": ""Fast Food"",
        ""average_cost_for_two"": 30,
        ""price_range"": 2,
        ""currency"": ""NZ$"",
        ""offers"": [],
        ""thumb"": ""https://b.zmtcdn.com/data/pictures/0/7000130/fe65be25a26939329a398aacfe4166ed_featured_v2.jpg"",
        ""user_rating"": {
          ""aggregate_rating"": ""3.6"",
          ""rating_text"": ""Very Good"",
          ""rating_color"": ""5BA829"",
          ""votes"": ""32""
        },
        ""photos_url"": ""https://www.zomato.com/auckland/wendys-queen-street/photos#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""menu_url"": ""https://www.zomato.com/auckland/wendys-queen-street/menu#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""featured_image"": ""https://b.zmtcdn.com/data/pictures/0/7000130/fe65be25a26939329a398aacfe4166ed_featured_v2.jpg"",
        ""has_online_delivery"": 0,
        ""is_delivering_now"": 0,
        ""deeplink"": ""zomato://r/7000130"",
        ""events_url"": ""https://www.zomato.com/auckland/wendys-queen-street/events#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""establishment_types"": []
      }
    },
    {
      ""restaurant"": {
        ""R"": {
          ""res_id"": 7000162
        },
        ""apikey"": ""13ad8f24c1e8ba215d919ac0899dff61"",
        ""id"": ""7000162"",
        ""name"": ""Giapo"",
        ""url"": ""https://www.zomato.com/auckland/giapo-queen-street?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""location"": {
          ""address"": ""279 CBD, Queen Street, Auckland"",
          ""locality"": ""Queen Street"",
          ""city"": ""Auckland"",
          ""city_id"": 70,
          ""latitude"": ""-36.8513333333"",
          ""longitude"": ""174.7645000000"",
          ""zipcode"": """",
          ""country_id"": 148
        },
        ""cuisines"": ""Ice Cream, Desserts"",
        ""average_cost_for_two"": 20,
        ""price_range"": 1,
        ""currency"": ""NZ$"",
        ""offers"": [],
        ""thumb"": ""https://b.zmtcdn.com/data/pictures/2/7000162/e5baac0e83438ccf6627e4f2e43844c1_featured_v2.jpg"",
        ""user_rating"": {
          ""aggregate_rating"": ""4.6"",
          ""rating_text"": ""Legendary"",
          ""rating_color"": ""305D02"",
          ""votes"": ""573""
        },
        ""photos_url"": ""https://www.zomato.com/auckland/giapo-queen-street/photos#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""menu_url"": ""https://www.zomato.com/auckland/giapo-queen-street/menu#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""featured_image"": ""https://b.zmtcdn.com/data/pictures/2/7000162/e5baac0e83438ccf6627e4f2e43844c1_featured_v2.jpg"",
        ""has_online_delivery"": 0,
        ""is_delivering_now"": 0,
        ""deeplink"": ""zomato://r/7000162"",
        ""events_url"": ""https://www.zomato.com/auckland/giapo-queen-street/events#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""establishment_types"": []
      }
    },
    {
      ""restaurant"": {
        ""R"": {
          ""res_id"": 7005702
        },
        ""apikey"": ""13ad8f24c1e8ba215d919ac0899dff61"",
        ""id"": ""7005702"",
        ""name"": ""YB Sushi"",
        ""url"": ""https://www.zomato.com/auckland/yb-sushi-queen-street?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""location"": {
          ""address"": ""235 Queen Street, Auckland CBD, Auckland"",
          ""locality"": ""Queen Street"",
          ""city"": ""Auckland"",
          ""city_id"": 70,
          ""latitude"": ""-36.8512280000"",
          ""longitude"": ""174.7641570000"",
          ""zipcode"": """",
          ""country_id"": 148
        },
        ""cuisines"": ""Sushi, Japanese"",
        ""average_cost_for_two"": 25,
        ""price_range"": 1,
        ""currency"": ""NZ$"",
        ""offers"": [],
        ""thumb"": ""https://b.zmtcdn.com/data/pictures/2/7005702/09bd2f033f505bf04be8b19f43f8d294_featured_v2.jpg"",
        ""user_rating"": {
          ""aggregate_rating"": ""3.6"",
          ""rating_text"": ""Very Good"",
          ""rating_color"": ""5BA829"",
          ""votes"": ""20""
        },
        ""photos_url"": ""https://www.zomato.com/auckland/yb-sushi-queen-street/photos#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""menu_url"": ""https://www.zomato.com/auckland/yb-sushi-queen-street/menu#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""featured_image"": ""https://b.zmtcdn.com/data/pictures/2/7005702/09bd2f033f505bf04be8b19f43f8d294_featured_v2.jpg"",
        ""has_online_delivery"": 0,
        ""is_delivering_now"": 0,
        ""deeplink"": ""zomato://r/7005702"",
        ""events_url"": ""https://www.zomato.com/auckland/yb-sushi-queen-street/events#tabtop?utm_source=api_basic_user&utm_medium=api&utm_campaign=v2.1"",
        ""establishment_types"": []
      }
    }
  ]
}";
#endregion

        [TestMethod]
        public void GivenZomatoResponseAndEmotionsAndLatLonGetsRestaurantID ()
        {
            SuperSecretSauceService service = new SuperSecretSauceService();
            EmotionMessageService emotionService = new EmotionMessageService();
            var zomatoResponse = JsonConvert.DeserializeObject<ZomatoResponse>(rawResponse);
            var emotions = new Emotion[] {
            new Emotion { Scores = new Scores { Anger = 1 } },
             new Emotion { Scores = new Scores { Happiness = 1 }
             } };
            
            PAssert.IsTrue(() => (service.GetBestRestaurantID
            (zomatoResponse, emotions, -36.850900f, 174.764517f) != null));

            PAssert.IsTrue(() => (emotionService.getEmotionMessageService
            (emotions) == "2 people look 50% hangry! Cure it with:"));

            var noEmotions = new Emotion[] { };
            PAssert.IsTrue(() => (emotionService.getEmotionMessageService
            (noEmotions).Contains("no face")));
        }

        [TestMethod]
        public void GivenDifferentEmotionsGetsDiffeerentRestaurantID()
        {
            SuperSecretSauceService service = new SuperSecretSauceService();
            EmotionMessageService emotionService = new EmotionMessageService();
            var zomatoResponse = JsonConvert.DeserializeObject<ZomatoResponse>(rawResponse);
            var emotionAngry = new Emotion[] {
            new Emotion { Scores = new Scores { Anger = 1 } } };
            var emotionHappy = new Emotion[] {
            new Emotion { Scores = new Scores { Happiness = 1 } } };

            var HappyID = service.GetBestRestaurantID(zomatoResponse, emotionHappy, -36.850900f, 174.764517f);
            var AngryID = service.GetBestRestaurantID(zomatoResponse, emotionAngry, -36.850900f, 174.764517f);

            PAssert.IsTrue(() => (HappyID != AngryID));
        }
    }
}
