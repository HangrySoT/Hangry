using Microsoft.ProjectOxford.Emotion.Contract;

namespace HangrySoT.Website.Services
{
    public class EmotionMessageService
    {
        public string getEmotionMessageService(Emotion[] Emotions)
        {
            int number_of_people = 0;
            string hangryMessage = "";
            //finding number of faces
            foreach (var Emotion in Emotions)
            {
                number_of_people += 1;
            }

            //no face detected
            if(number_of_people == 0)
            {
                hangryMessage = "Sorry no face is detected, try again?";
            }

            //more than one face
            if (number_of_people > 1)
            {
                hangryMessage = number_of_people.ToString() + " people look";
                double totalAnger = 0;
                double totalHappiness = 0;
                foreach (var emotion in Emotions)
                {
                    totalAnger += (double)emotion.Scores.Anger;
                    totalHappiness += (double)emotion.Scores.Happiness;
                }

                double averageAnger = totalAnger / number_of_people * 100;
                double averageHappiness = totalHappiness / number_of_people;

                if (averageHappiness >= 0.9)
                {
                    hangryMessage += " happy, let's go further to get cheaper food:";
                }
                else if (averageAnger >= 50)
                {
                    hangryMessage += " " + averageAnger.ToString() + "% hangry! Cure it with:";
                }
                else
                {
                    hangryMessage += " a bit hangry! Cure it with:";
                }
            }

            //exactly one face
            if (number_of_people == 1)
            {
                foreach(var emotion in Emotions)
                {
                    var anger = (double)emotion.Scores.Anger * 100;
                    var happiness = (double)emotion.Scores.Happiness;
                    if (happiness >= 0.9)
                    {
                        hangryMessage = "You look happy, let's go further to get cheaper food:";
                    }
                    else if (anger >= 50)
                    {
                        hangryMessage = "You look " + anger.ToString() + "% hangry! Cure it with:";
                    }
                    else
                    {
                        hangryMessage = "You look a bit hangry! Cure it with:";
                    }
                }
            }

            return hangryMessage;
        }
    }
}