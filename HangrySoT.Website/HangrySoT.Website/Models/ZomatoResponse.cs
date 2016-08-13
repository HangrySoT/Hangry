using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HangrySoT.Website.Models
{

    public class ZomatoResponse
    {
        public string results_found { get; set; }
        public string results_start { get; set; }
        public string results_shown { get; set; }
        public Restaurant[] restaurants { get; set; }
    }

    public class Restaurant
    {
        public string id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public Location location { get; set; }
        public string average_cost_for_two { get; set; }
        public string price_range { get; set; }
        public string currency { get; set; }
        public string thumb { get; set; }
        public string featured_image { get; set; }
        public string photos_url { get; set; }
        public string menu_url { get; set; }
        public string events_url { get; set; }
        public User_Rating user_rating { get; set; }
        public string has_online_delivery { get; set; }
        public string is_delivering_now { get; set; }
        public string deeplink { get; set; }
        public string cuisines { get; set; }
        public string all_reviews_count { get; set; }
        public string photo_count { get; set; }
        public string phone_numbers { get; set; }
        public Photo[] photos { get; set; }
        public All_Reviews[] all_reviews { get; set; }
    }

    public class Location
    {
        public string address { get; set; }
        public string locality { get; set; }
        public string city { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        public string zipcode { get; set; }
        public string country_id { get; set; }
    }

    public class User_Rating
    {
        public string aggregate_rating { get; set; }
        public string rating_text { get; set; }
        public string rating_color { get; set; }
        public string votes { get; set; }
    }

    public class Photo
    {
        public string id { get; set; }
        public string url { get; set; }
        public string thumb_url { get; set; }
        public User user { get; set; }
        public string res_id { get; set; }
        public string caption { get; set; }
        public string timestamp { get; set; }
        public string friendly_time { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string comments_count { get; set; }
        public string likes_count { get; set; }
    }

    public class User
    {
        public string name { get; set; }
        public string zomato_handle { get; set; }
        public string foodie_level { get; set; }
        public string foodie_level_num { get; set; }
        public string foodie_color { get; set; }
        public string profile_url { get; set; }
        public string profile_deeplink { get; set; }
        public string profile_image { get; set; }
    }

    public class All_Reviews
    {
        public string rating { get; set; }
        public string review_text { get; set; }
        public string id { get; set; }
        public string rating_color { get; set; }
        public string review_time_friendly { get; set; }
        public string rating_text { get; set; }
        public string timestamp { get; set; }
        public string likes { get; set; }
        public User user { get; set; }
        public string comments_count { get; set; }
    }

}