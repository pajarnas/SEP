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
    public class MoviesController : ControllerBase
    {
        // GET: api/movies
        [HttpGet]
        public IEnumerable<MovieCreateRequest> Get()
        {
            return movies;
        }

        // GET api/movies/5
        [HttpGet("{id}")]
        public MovieCreateRequest Get(int id)
        {
            return movies.Where(m=>m.Id==id).SingleOrDefault();
        }

        // GET api/movies/toprated
        [HttpGet()]
        [Route("toprated")]
        public MovieCreateRequest GetTopRated()
        {
            var movieId = reviews.OrderBy(r=>r.Rating).Take(1).SingleOrDefault().MovieId;
            
            return movies.Where(m => m.Id == movieId).SingleOrDefault();
        }

        // GET api/movies/toprevenue
        [HttpGet()]
        [Route("toprevenue")]
        public MovieCreateRequest GetTopRevenue()
        {
            var movieId = reviews.OrderBy(r => r.Rating).Take(1).SingleOrDefault().MovieId;

            return movies.Where(m => m.Id == movieId).SingleOrDefault();
        }

        // GET api/movies/genre/{id}
        [HttpGet("{id}")]
        [Route("genre/{id}")]
        public MovieCreateRequest GetTopMovieByGenreId(int id)
        {
          
            return movies.Where(m => m.Generes[1].Id==id).SingleOrDefault();
        }

        // GET api/movies/{id}/reviews
        [HttpGet("{id}")]
        [Route("{id}/reviews")]
        public List<ReviewRequestModel> GetMovieReviews(int id)
        {

            return reviews.Where(r => r.MovieId == id).ToList();
        }

        private static List<MovieCreateRequest> movies;
        private static List<Genre> genres;
        private static List<ReviewRequestModel> reviews;

        static MoviesController() 
        {
            reviews = new List<ReviewRequestModel>()
            {
                new ReviewRequestModel {MovieId=1,Rating=5.6,UserId=1,ReviewText="A Review"},
                new ReviewRequestModel {MovieId=2,Rating=5.6,UserId=2,ReviewText="A Review"},
                new ReviewRequestModel {MovieId=3,Rating=8.6,UserId=3,ReviewText="A Review"},
                new ReviewRequestModel {MovieId=4,Rating=7.6,UserId=4,ReviewText="A Review"},
            };
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
            movies = new List<MovieCreateRequest>()
            {
                new MovieCreateRequest{Id=1,Generes=genres,Title="A movie1"},
                new MovieCreateRequest{Id=2,Generes=genres,Title="A movie2"},
                new MovieCreateRequest{Id=3,Generes=genres,Title="A movie3"},
                new MovieCreateRequest{Id=4,Generes=genres,Title="A movie4"},
                new MovieCreateRequest{Id=5,Generes=genres,Title="A movie5"}
            };

           
        }
    }
}
