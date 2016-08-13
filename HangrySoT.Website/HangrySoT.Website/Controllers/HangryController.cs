﻿using HangrySoT.ApiClient.Oxford;
using Microsoft.ProjectOxford.Emotion.Contract;
using System;
using System.Collections.Generic;
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

            //Response.TransmitFile(Server.MapPath(nameAndLocation));
            return Content(strb.ToString(),"text/plain");
        }
    }
}