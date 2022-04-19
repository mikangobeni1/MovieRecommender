using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace XamCam
{
    public class MovieViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Movies> Movies;

        public ObservableCollection<Movies> movies
        {
            get { return Movies; }
            set { Movies = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
            }
        }

        public MovieViewModel()
        {
            movies = new ObservableCollection<Movies>();
            similarMovies();
        }

        public async Task<ObservableCollection<Movies>> SuggestedMovie(string genreId, int age)
        {
            MovieApiCaller movieApiCaller = new MovieApiCaller();

            var response = await movieApiCaller.GetSuggestedMovieDetail(genreId, age);

            return response;
        }

        private void similarMovies()
        {
            movies.Add(new XamCam.Movies
            {
                id = "0",
                title = "Spider-Man: No Way Home",
                image = "https://image.tmdb.org/t/p/original/1g0dhYtq4irTY1GPXvft6k4YLjm.jpg",
                runtime = 148
            });
            movies.Add(new XamCam.Movies
            {
                id = "0",
                title = "Spider-Man: No Way Home",
                image = "https://image.tmdb.org/t/p/original/1g0dhYtq4irTY1GPXvft6k4YLjm.jpg",
                runtime = 148
            });
            movies.Add(new XamCam.Movies
            {
                id = "0",
                title = "Spider-Man: No Way Home",
                image = "https://image.tmdb.org/t/p/original/1g0dhYtq4irTY1GPXvft6k4YLjm.jpg",
                runtime = 148
            });
        }
    }
}
