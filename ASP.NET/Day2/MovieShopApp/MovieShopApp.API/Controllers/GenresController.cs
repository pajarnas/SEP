using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieShopApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        // GET: api/<GenresController>
        [HttpGet]
        public IEnumerable<Genre> Get()
        {
            return genres;
        }

        private static List<Genre> genres;
        static GenresController()
        {
            genres = new List<Genre>()
            {
                new Genre { Id=1, Name="Smith1"},
                new Genre { Id=2, Name="Smith2"},
                new Genre { Id=3, Name="Smith3"},
                new Genre { Id=4, Name="Smith4"},
                new Genre { Id=5, Name="Smith5"},
                new Genre { Id=6, Name="Smith6"},
                new Genre { Id=7, Name="Smith7"}
            };
        }
    }
}
