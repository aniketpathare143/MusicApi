using Microsoft.AspNetCore.Mvc;
using MusicApi.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicApi.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/tracks")] //https://localhost:44373/api/tracks?api-version=2.0
    [ApiController]
    public class TrackV2Controller : ControllerBase
    {
        static List<TrackV2> tracks = new List<TrackV2>
            {
                new TrackV2(){Id=1,Name="Track number 1",Time="2.0 Seconds"},
                new TrackV2(){Id=2,Name="Track number 2",Time="3 minutes"}
            };
      
        [HttpGet]
        public IEnumerable<TrackV2> Get()
        {
            return tracks;
        }

    }
}
