using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Emotion;
using Microsoft.ProjectOxford.Emotion.Contract;

namespace HangrySoT.ApiClient.Oxford
{
    public interface IOxfordClient
    {
        Task<Emotion[]> AnalyseImage(Stream imageFileStream);
    }

    public class OxfordClient : IOxfordClient
    {
        private readonly string subscriptionKey = ConfigurationManager.AppSettings["OxfordApiKey"];
        private readonly EmotionServiceClient _emotionServiceClient;

        public OxfordClient()
        {
            _emotionServiceClient = new EmotionServiceClient(subscriptionKey);
        }

        public async Task<Emotion[]> AnalyseImage(Stream imageFileStream)
        {
            // Detect the emotions in the Stream
            var emotionResult = await _emotionServiceClient.RecognizeAsync(imageFileStream);
            return emotionResult;
        }
    }
}