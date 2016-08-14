using System.Device.Location;
using HangrySoT.ApiClient.Models;
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

            //get number of faces and adjust costPerMetre
            int number_of_people = 0;
            //finding number of faces
            foreach (var Emotion in Emotions)
            {
                number_of_people += 1;
            }

            //no face detected

            //more than one face
            if (number_of_people > 1)
            {
                double totalAnger = 0;
                double totalHappiness = 0;
                foreach (var emotion in Emotions)
                {
                    totalAnger += (double)emotion.Scores.Anger;
                    totalHappiness += (double)emotion.Scores.Happiness;
                }

                double averageAnger = totalAnger / number_of_people * 100;
                double averageHappiness = totalHappiness / number_of_people;

                if (averageHappiness >= 0.7)
                {
                    costPerMetre = 0;
                }
                else if (averageAnger >= 25)
                {
                    costPerMetre = costPerMetre * 750;
                }
            }

            //exactly one face
            if (number_of_people == 1)
            {
                foreach (var emotion in Emotions)
                {
                    var anger = (double)emotion.Scores.Anger * 100;
                    var happiness = (double)emotion.Scores.Happiness;
                    if (happiness >= 0.7)
                    {
                        costPerMetre = 0;
                    }
                    else if (anger >= 25)
                    {
                        costPerMetre = costPerMetre * 750;
                    }
                }
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
                else if (bestRestaurantModifiedPriceRange > processedPriceRange)
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