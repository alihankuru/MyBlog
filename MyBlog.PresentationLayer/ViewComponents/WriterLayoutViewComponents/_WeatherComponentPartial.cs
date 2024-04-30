using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace MyBlog.PresentationLayer.ViewComponents.WriterLayoutViewComponents
{
    public class _WeatherComponentPartial:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string api = "b00c65309881071f4de42bede2c7d662";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul,tr&mode=xml&lang=tr&units=metric&APPID=" + api;

            XDocument weather = XDocument.Load(connection);

            var temp = weather.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            string firstTwoLetters = temp.Substring(0, 2);

            string weathervalue = weather.Descendants("weather").ElementAt(0).Attribute("value").Value;
            string[] words = weathervalue.Split(' ');
            string lastWord = words[words.Length - 1];
            lastWord = char.ToUpper(lastWord[0]) + lastWord.Substring(1);


            ViewBag.Temperature = firstTwoLetters+"C";
            ViewBag.Weather = lastWord;


            return View();
        }
        
    }
}
