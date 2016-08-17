using HangrySoT.ApiClient.Oxford;
using HangrySoT.ApiClient.Zomato;
using HangrySoT.Website.Services;
using Microsoft.ProjectOxford.Emotion.Contract;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace HangrySoT.Website.Controllers
{

    public class HangryInputModel
    {
        public double lat { get; set; }
        public double lon { get; set; }
        public bool demo { get; set; }
        public HttpPostedFileBase image { get; set; }       
    }

    public class HangryViewModel
    {
        public string hangryMessage;
        public string restName;
        public string restAddress;
        public int restDistance;
        public double restAvgPrice;
        public string restLat;
        public string restLon;
    }


    public class HangryController : Controller
    {
        [Route("")]
        public ActionResult Index(bool demo = false)
        {
            ViewBag.demo = demo;
            return View();
        }

        [Route("")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> Index(HangryInputModel model)
        {
            if (model.demo)
            {
                model.lat = -36.850900;
                model.lon = 174.764517;
            }

            var imagestream = model.image.InputStream;

            var oxfordClient = new OxfordClient();
            var zomatoClient = new ZomatoClient();
            var secretSauce = new SuperSecretSauceService();

            var emotionsTask = oxfordClient.AnalyseImage(imagestream);
            var zomDataTask = zomatoClient.SearchByLatLon(model.lat, model.lon);

            var emotions = await emotionsTask;
            var zomData = await zomDataTask;

            var restaurantId = secretSauce.GetBestRestaurantID(zomData, emotions, model.lat, model.lon);
            var chosenRestaurant = zomData.restaurants.Single(r => r.restaurant.id == restaurantId);

            StringBuilder strb = new StringBuilder();

            Scores scores;
            int faceNo = 0;

            var userCoord = new GeoCoordinate(model.lat, model.lon);
            var restCoord = new GeoCoordinate(double.Parse(chosenRestaurant.restaurant.location.latitude), double.Parse(chosenRestaurant.restaurant.location.longitude));

            EmotionMessageService emoService = new EmotionMessageService();
            var message = emoService.getEmotionMessageService(emotions);
            var viewModel = new HangryViewModel
            {
                restName = chosenRestaurant.restaurant.name,
                restAddress = chosenRestaurant.restaurant.location.address,
                restAvgPrice = chosenRestaurant.restaurant.average_cost_for_two / 2,
                restDistance = (int)userCoord.GetDistanceTo(restCoord),
                restLat = chosenRestaurant.restaurant.location.latitude.ToString(),
                restLon = chosenRestaurant.restaurant.location.longitude.ToString(),
                hangryMessage = message
            };

            //foreach (var face in emotions)
            //{
            //    faceNo++;
            //    scores = face.Scores;
            //    strb.Append("Face " + faceNo + "\n");
            //    strb.Append("Anger: " + face.Scores.Anger + "\n");
            //    strb.Append("Happiness: " + scores.Happiness + "\n");
            //    strb.Append("Contempt: " + scores.Contempt + "\n");
            //    strb.Append("Sadness: " + scores.Sadness + "\n");
            //    strb.Append("Surprise: " + scores.Surprise + "\n");
            //    strb.Append("Fear: " + scores.Fear + "\n");
            //    strb.Append("\n\n");
            //}

            //strb.Append("Current Location:\n");
            //strb.Append("Latitude: " + model.lat + "\n");
            //strb.Append("Longitude: " + model.lon + "\n");

            //strb.Append("\n\n");
            //strb.Append("Chosen Restaurant:\n");
            //strb.Append("Name: " + chosenRestaurant.restaurant.name + "\n");
            //strb.Append("Address: " + chosenRestaurant.restaurant.name + "\n");

            //return Content(strb.ToString(),"text/plain")
            return View("Results", viewModel);

        }
      
        [Route("debugResult")]
        public ActionResult debugResults()
        {

            var viewModel = new HangryViewModel
            {
                restName = "21 Viaduct Cafe - Sofitel Auckland Viaduct Harbour",
                restAddress = "Sofitel, 21 Viaduct Harbour, Viaduct Harbour, Auckland CBD, Auckland 1010",
                restAvgPrice = 25.00,
                restDistance = 134,
                restLat = "-36",
                restLon = "172",
                hangryMessage = "You look hangry af."
            };

            return View("Results", viewModel);
        }
    }
}