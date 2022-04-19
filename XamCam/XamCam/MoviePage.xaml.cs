using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamCam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviePage : ContentPage
    {
        public string selectedGenreIDs;
        public int age;
        public MoviePage(AgeAndEmotionGenre genreAndAgeGenre)
        {
            InitializeComponent();
            ColorTypeConverter converter = new ColorTypeConverter();
            Color backSectionBackgroundColor = (Color)(converter.ConvertFromInvariantString("#9A7245"));
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.White;
            ((NavigationPage)Application.Current.MainPage).BarTextColor = backSectionBackgroundColor;

            selectedGenreIDs = genreAndAgeGenre.emotionGenre;
            age = genreAndAgeGenre.age;

            MovieViewModel viewModel = new MovieViewModel();
            Console.WriteLine(viewModel.SuggestedMovie(selectedGenreIDs, age));
        }

    }
}