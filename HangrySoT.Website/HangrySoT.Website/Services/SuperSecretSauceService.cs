using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Web;
using HangrySoT.ApiClient.Models;
using Microsoft.ProjectOxford.Emotion;
using Microsoft.ProjectOxford.Emotion.Contract;

namespace HangrySoT.Website.Services
{
    public class SuperSecretSauceService
    {

        public string GetBestRestaurantID(ZomatoResponse ZomatoResponse, Emotion[] Emotions, double lat, double lng)
        {
            double costPerMetre = 0.00244;
            var userCoord = new GeoCoordinate(lat, lng);
            string bestRestaurantID = "";
            double bestRestaurantModifiedPriceRange = 0;
            double bestRestaurantDistance = 0;
            //string bestRestaurantAddress = "";
            var firstEmotion = Emotions.First();
            var anger = firstEmotion.Scores.Anger;
            var happiness = firstEmotion.Scores.Happiness;
            string hangryMessage;
            if(happiness >= 0.9)
            {
                costPerMetre = costPerMetre / 2;
                hangryMessage = "Looks like you're having a good day, let's go further to get better food:";
            }
            else
            {
                costPerMetre = costPerMetre * 2;
                hangryMessage = "You look pretty hangry! Cure it with:";
            }

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