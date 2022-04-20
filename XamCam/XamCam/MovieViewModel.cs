using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace XamCam
{
    public class MovieViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Movies> Movies;
        private ObservableCollection<Movies> SuggestedMovie;

        public ObservableCollection<Movies> movies
        {
            get { return Movies; }
            set { Movies = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
            }
        }

        public ObservableCollection<Movies> suggestedMovie
        {
            get { return SuggestedMovie; }
            set { SuggestedMovie = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
            }
        }
        public MovieViewModel(String genreIDs, int age)
        {
            suggestedMovie = new ObservableCollection<Movies>();
            movies = new ObservableCollection<Movies>();
            MovieApiCaller movieApiCaller = new MovieApiCaller();
            suggestedMovie = movieApiCaller.getSuggestedMovieDetail(genreIDs, age);
            movies = movieApiCaller.getSimilarMovies(suggestedMovie[0].id);
        }
    }
}
