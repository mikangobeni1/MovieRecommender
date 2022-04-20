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
        public string emotionGenre;
        public string selectedGenreIDs;
        public int age;


        public enum Genres : int
        {
            Action = 28,
            Comedy = 35,
            Drama = 18,
            Family = 10751,
            Horror = 27,
            Romance = 10749,
            ScienceFiction = 878,
            Thriller = 53,
        }

        public MoviePage(AgeEmotionGenre ageEmotionGenre)
        {
            InitializeComponent();

            age = ageEmotionGenre.age;

            ColorTypeConverter converter = new ColorTypeConverter();
            Color backSectionBackgroundColor = (Color)(converter.ConvertFromInvariantString("#9A7245"));     
            ((NavigationPage)Application.Current.MainPage).BarTextColor = backSectionBackgroundColor;



            MapGenreToID(ageEmotionGenre);

            BindingContext = new MovieViewModel(selectedGenreIDs, age);
            //MovieViewModel viewModel = new MovieViewModel();
            //Console.WriteLine(viewModel.SuggestedMovie(selectedGenreIDs, age));
        }

        public void MapGenreToID(AgeEmotionGenre ageEmotionGenre)
        {
            int genreBasedOnEmotionID;
            int genreBasedOnSelectedImageID;
            

            string genreBasedOnSelectedImage = ageEmotionGenre.genre;

            string emotion = ageEmotionGenre.emotion;
            string genreBasedOnEmotion = MapEmotionToGenre(emotion);

            switch (genreBasedOnEmotion)
            {
                case "Romance":
                    genreBasedOnEmotionID = (int)Genres.Romance;
                    break;
                case "SciFi":
                    genreBasedOnEmotionID = (int)Genres.ScienceFiction;
                    break;
                case "Comedy":
                    genreBasedOnEmotionID = (int)Genres.Comedy;
                    break;
                case "Thriller":
                    genreBasedOnEmotionID = (int)Genres.Thriller;
                    break;
                case "Drama":
                    genreBasedOnEmotionID = (int)Genres.Drama;
                    break;
                case "Horror":
                    genreBasedOnEmotionID = (int)Genres.Horror;
                    break;
                case "Action":
                    genreBasedOnEmotionID = (int)Genres.Action;
                    break;
                default:
                    genreBasedOnEmotionID = (int)Genres.Family;
                    break;
            }

            switch (genreBasedOnSelectedImage)
            {
                case "Romance":
                    genreBasedOnSelectedImageID = (int)Genres.Romance;
                    break;
                case "SciFi":
                    genreBasedOnSelectedImageID = (int)Genres.ScienceFiction;
                    break;
                case "Comedy":
                    genreBasedOnSelectedImageID = (int)Genres.Comedy;
                    break;
                case "Thriller":
                    genreBasedOnSelectedImageID = (int)Genres.Thriller;
                    break;
                case "Drama":
                    genreBasedOnSelectedImageID = (int)Genres.Drama;
                    break;
                case "Horror":
                    genreBasedOnSelectedImageID = (int)Genres.Horror;
                    break;
                case "Action":
                    genreBasedOnSelectedImageID = (int)Genres.Action;
                    break;
                default:
                    genreBasedOnSelectedImageID = (int)Genres.Family;
                    break;

            }

            selectedGenreIDs = $"{genreBasedOnEmotionID}, {genreBasedOnSelectedImageID}";
        }

        public string MapEmotionToGenre(string emotion)
        {
            switch (emotion)
            {
                case "happiness":   //Happy
                    emotionGenre = "Romance";
                    break;
                case "neutral":  // Neutral
                    emotionGenre = "SciFi";
                    break;
                case "disgust":  //Disgust
                    emotionGenre = "Comedy";
                    break;
                case "anger": //Anger
                    emotionGenre = "Thriller";
                    break;
                case "sadness":  //Sad
                    emotionGenre = "Drama";
                    break;
                case "fear":  //Fear
                    emotionGenre = "Horror";
                    break;
                case "surprise": //Surprise
                    emotionGenre = "Action";
                    break;
                default:
                    emotionGenre = "Family";
                    break;

            }
            return emotionGenre;
        }
    }
}