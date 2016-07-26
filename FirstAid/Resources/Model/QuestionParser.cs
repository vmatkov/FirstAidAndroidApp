using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json.Linq;

namespace FirstAid.Resources.Model
{
    public class QuestionParser
    {
        public static List<Question> ParseJsonData(string json)
        {
            var vprasanja = new List<Question>();

            JArray JsonArray = JArray.Parse(json);
            var id = 1;

            foreach (var item in JsonArray.Children())
            {
                var itemProperties = item.Children<JProperty>(); //bValidated szDescription

                var answers = new List<string>();
                var correct = new List<int>();

                var question = itemProperties.FirstOrDefault(x => x.Name == "Question");

                var answer1 = itemProperties.FirstOrDefault(x => x.Name == "Answer1");
                if ((string)answer1.Value != "") answers.Add((string)answer1.Value);

                var answer2 = itemProperties.FirstOrDefault(x => x.Name == "Answer2");
                if ((string)answer2.Value != "") answers.Add((string)answer2.Value);

                var answer3 = itemProperties.FirstOrDefault(x => x.Name == "Answer3");
                if ((string)answer3.Value != "") answers.Add((string)answer3.Value);

                var answer4 = itemProperties.FirstOrDefault(x => x.Name == "Answer4");
                if ((string)answer4.Value != "") answers.Add((string)answer4.Value);

                var answer5 = itemProperties.FirstOrDefault(x => x.Name == "Answer5");
                if ((string)answer5.Value != "") answers.Add((string)answer5.Value);

                var answer6 = itemProperties.FirstOrDefault(x => x.Name == "Answer6");
                if ((string)answer6.Value != "") answers.Add((string)answer6.Value);

                var answer7 = itemProperties.FirstOrDefault(x => x.Name == "Answer7");
                if ((string)answer7.Value != "") answers.Add((string)answer7.Value);

                var answer8 = itemProperties.FirstOrDefault(x => x.Name == "Answer8");
                if ((string)answer8.Value != "") answers.Add((string)answer8.Value);

                var answer9 = itemProperties.FirstOrDefault(x => x.Name == "Answer9");
                if ((string)answer9.Value != "") answers.Add((string)answer9.Value);

                var correctAnswer = (string) itemProperties.FirstOrDefault(x => x.Name == "Correct").Value;
                List<string> tokens = correctAnswer.Split(';').ToList();
                for (var i = 0; i < tokens.Count; i++) correct.Add(Convert.ToInt32(tokens[i]));

                vprasanja.Add(new Question(id, (string)question.Value, answers, correct));

                id++;
            }

            return vprasanja;
        }
    }
}