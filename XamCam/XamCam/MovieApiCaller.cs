using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace XamCam
{
    public class MovieApiCaller
    {
        HttpClient client = new HttpClient();
        private readonly string baseURL = "https://api.themoviedb.org/3";
        private readonly string imageBaseURL = "https://image.tmdb.org/t/p/original";

        public static string selectedMovieID;
        public ObservableCollection<Movies> suggestedMovie { get; private set; }
        public ObservableCollection<Movies> similarMovies { get; private set; }

        public MovieApiCaller() { }

        // Find Genre based on emotion passed
        //private string EmotionToGenre()
        //{

        //    //var selfieResults = new SelfiePage();
        //    //var emotionAndAge = selfieResults.CaptureFace();
        //    var emoticon = new EmojiPage();


        //    return genre;
        //}

        public async Task<string> GetSuggestedMovie()
        {
            
            string genres = "35, 27";
            int age = 17;

            string showAdultContent = age > 18 ? "true" : "false";

            string response = await client.GetStringAsync($"{baseURL}/discover/movie?api_key=34728b95f5f9dfc0f413206f25ffd212&language=en-US&sort_by=vote_count.desc&page=1&with_genres={genres}&include_adult={showAdultContent}");

            JObject jsonRes = JObject.Parse(response);

            int responseLength = jsonRes["results"].Count();
            int randomIndex = new Random().Next(1, responseLength);
            var randomlySelectedMovie = jsonRes["results"][randomIndex];
            //Console.WriteLine((int)randomlySelectedMovie["id"])

            return (string)randomlySelectedMovie["id"];
        }

        public async Task<ObservableCollection<Movies>> GetSuggestedMovieDetail()
        {

            selectedMovieID = await GetSuggestedMovie();
            string response = await client.GetStringAsync($"{baseURL}/movie/{selectedMovieID}?api_key=34728b95f5f9dfc0f413206f25ffd212&language=en-US");
            JObject jsonRes = JObject.Parse(response);
            suggestedMovie = new ObservableCollection<Movies>();
            suggestedMovie.Add(new Movies
            {
                id = (string)jsonRes["id"],
                title = (string)jsonRes["title"],
                image = $"{imageBaseURL}{jsonRes["poster_path"]}",
                runtime = (int)jsonRes["runtime"],
            });

            return suggestedMovie;
        }

        public async Task<ObservableCollection<Movies>> GetSimilarMovies(string id)
        {
            string response = await client.GetStringAsync($"{baseURL}/movie/{id}/similar?api_key=34728b95f5f9dfc0f413206f25ffd212&language=en-us&page=1");
            JObject jsonres = JObject.Parse(response);
            var result = jsonres["results"];
            similarMovies = new ObservableCollection<Movies>();

            foreach (var movie in result)
            {
                similarMovies.Add(new Movies
                {
                    id = (string)movie["id"],
                    title = (string)movie["title"],
                    image = $"{imageBaseURL}{movie["poster_path"]}",
                    runtime = 0,
                });
            }

            return similarMovies;
        }


    }

}
