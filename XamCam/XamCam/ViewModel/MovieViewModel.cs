using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

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
            MovieViewModelAsync(genreIDs, age);
        }
        public async void MovieViewModelAsync(String genreIDs, int age)
        {
            
            MovieApiCaller movieApiCaller = new MovieApiCaller();
            suggestedMovie = new ObservableCollection<Movies>(await movieApiCaller.GetSuggestedMovieDetail(genreIDs, age));
            movies = new ObservableCollection<Movies>(await movieApiCaller.GetSimilarMovies(suggestedMovie[0].id));
        }
    }
}
