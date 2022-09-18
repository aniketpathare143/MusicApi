using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OldSongsController : ControllerBase
    {
        public static List<Song> Songs = new List<Song>() //Made this static which will allow to share single copy of this list throughout the controller.
        {
            new Song(){Id=1,Title="Willow",Language="English"},
            new Song(){Id=2,Title="Pillow",Language="hindi"}
        };

        [HttpGet]
        public IEnumerable<Song> Get()
        {
            return Songs;
        }

        [HttpPost]
        public void Post([FromBody]Song song)  //Getting Post data from postman so need to tell api that song object
                                               //data will come from postman body so used [FromBody] tag.
        {
            Songs.Add(song);           
        }

        [HttpPut("{id}")] //To serve the request kind of path - " https://localhost:44373/api/songs/1"
        public void Put(int id,[FromBody] Song song) 
        {
            Songs[id] = song; //Update specific song by id
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {           
            Song song = Songs.FirstOrDefault(s => s.Id==id);
            if(song!= null)
            {
                Songs.Remove(song);
            }

            //Songs.RemoveAt(id);
        }
    }
}
