using Microsoft.AspNetCore.Mvc;
using MusicApi.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/tracks")] //https://localhost:44373/api/tracks?api-version=1.0
    [ApiController]
    public class TrackV1Controller : ControllerBase
    {
        static List<TrackV1> tracks = new List<TrackV1>
            {
                new TrackV1(){Id=1,Name="Track number 1"},
                new TrackV1(){Id=2,Name="Track number 2"}
            };
      
        [HttpGet]
        public IEnumerable<TrackV1> Get()
        {
            return tracks;
        }

    }
}
