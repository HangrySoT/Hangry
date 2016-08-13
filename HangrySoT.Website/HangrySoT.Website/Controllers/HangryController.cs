using HangrySoT.ApiClient.Oxford;
using HangrySoT.ApiClient.Zomato;
using Microsoft.ProjectOxford.Emotion.Contract;
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
        public HttpPostedFileBase image { get; set; }       

    }

    public class HangryController : Controller
    {
        // GET: Hangry
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Index(HangryInputModel model)
        {
            //string nameAndLocation = "~/UploadedFiles/" + model.image.FileName;
            //model.image.SaveAs(Server.MapPath(nameAndLocation));

            var filestream = model.image.InputStream;

            var oxfordClient = new OxfordClient();
            var emotions = await oxfordClient.AnalyseImage(filestream);
            
            var zomatoClient = new ZomatoClient();
            var zomData = await zomatoClient.SearchByLatLon();

            StringBuilder strb = new StringBuilder();

            Scores scores;
            int faceNo = 0;

            foreach (var face in emotions)
            {
                faceNo++;
                scores = face.Scores;
                strb.Append("Face " + faceNo + "\n");
                strb.Append("Anger: " + face.Scores.Anger + "\n");
                strb.Append("Happiness: " + scores.Happiness + "\n");
                strb.Append("Contempt: " + scores.Contempt + "\n");
                strb.Append("Sadness: " + scores.Sadness + "\n");
                strb.Append("Surprise: " + scores.Surprise + "\n");
                strb.Append("Fear: " + scores.Fear + "\n");
                strb.Append("\n\n");
            }

            strb.Append("Current Location:\n");
            strb.Append("Latitude: " + model.lat + "\n");
            strb.Append("Longitude: " + model.lon + "\n");

            strb.Append("\n\n");
            strb.Append("Restaurants:\n");
            foreach (var foodShop in zomData.restaurants.Take(3))
            {
                strb.Append("Name: " + foodShop.restaurant.name +"\n");
                strb.Append("Address: " + foodShop.restaurant.location.address + "\n");
                strb.Append("\n\n");
            }

            return Content(strb.ToString(),"text/plain");
        }
    }
}