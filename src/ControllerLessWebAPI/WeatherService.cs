using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ControllerLessWebAPI
{
    public class WeatherService
    {
        public static async Task Get(HttpContext context)
        {
            string[] summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            var rng = new Random();
            var returnData = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = summaries[rng.Next(summaries.Length)]
                })
                .ToArray();
            var jsonData = JsonSerializer.Serialize(returnData);

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(jsonData);
        }
    }
}