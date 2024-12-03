using Microsoft.AspNetCore.Mvc;
using route_optimizer.api.dto;

namespace route_optimizer.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DijkstraController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<DijkstraController> _logger;

        public DijkstraController(ILogger<DijkstraController> logger)
        {
            _logger = logger;
        }

        //[HttpGet("GetPath")]
        //public IEnumerable<WeatherForecast> GetOPtimizePath()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        [HttpGet("GetShortestPath")]
        public IEnumerable<WeatherForecast> GetShortestPath(string fromNode, string toNode)
        {
            //
            //write a method to return shorest path
            ShortestPathData shortestPath = new ShortestPathData();



            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

    }
}
