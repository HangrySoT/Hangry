using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Web;
using HangrySoT.ApiClient.Models;

namespace HangrySoT.Website.Services
{
    public class EmotionDetector
    {
        public double GetDistancePriceFactor(decimal anger, decimal contempt, decimal disgust, decimal fear, decimal happiness, decimal neutral, decimal sadness, decimal surprise)
        {
            
            return 0;
        }
    }
    public class SuperSecretSauceService
    {

        public string GetBestRestaurant(ZomatoResponse ZomatoResponse, double lng, double lat, double costPerMetre = 0.00244)
        {
            var userCoord = new GeoCoordinate(lat, lng);
            string bestRestaurantID = "";
            double bestRestaurantModifiedPriceRange = 0;
            double bestRestaurantDistance = 0;

            foreach (var restaurant in ZomatoResponse.restaurants)
            {

                var restaurantCoord = new GeoCoordinate(double.Parse(restaurant.restaurant.location.latitude), double.Parse(restaurant.restaurant.location.longitude));
                double distance = userCoord.GetDistanceTo(restaurantCoord);
                double pricePerPerson = restaurant.restaurant.average_cost_for_two / 2;
                double processedPriceRange = (pricePerPerson + distance * costPerMetre) * 2;
                if(bestRestaurantID == "")
                {
                    bestRestaurantID = restaurant.restaurant.id;
                    bestRestaurantModifiedPriceRange = processedPriceRange;
                    bestRestaurantDistance = distance;
                }
                else if (bestRestaurantModifiedPriceRange > processedPriceRange && distance < bestRestaurantDistance)
                {
                    bestRestaurantID = restaurant.restaurant.id;
                    bestRestaurantModifiedPriceRange = processedPriceRange;
                    bestRestaurantDistance = distance;
                }
            }
            return bestRestaurantID;

        }
    }

}