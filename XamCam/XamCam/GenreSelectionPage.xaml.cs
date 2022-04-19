using Newtonsoft.Json.Linq;
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
    public partial class GenreSelectionPage : ContentPage
    {
        String buttonImage1 = "";
        String buttonImage2 = "";
        public String SelectedGenre = ""; // check if this is okay
        public String EmotionGenre = "";
        String detectedEmotion; //Need to use actual variable for emotion
        int age;

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

        public GenreSelectionPage(AgeAndEmotionGenre ageAndEmotionGenre)
        {

            InitializeComponent();
            ColorTypeConverter converter = new ColorTypeConverter();
            Color backSectionBackgroundColor = (Color)(converter.ConvertFromInvariantString("#9A7245"));
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.White;
            ((NavigationPage)Application.Current.MainPage).BarTextColor = backSectionBackgroundColor;

            detectedEmotion = ageAndEmotionGenre.emotionGenre;
            age = ageAndEmotionGenre.age;

            switch (detectedEmotion)
            {
                case "happiness":   //Happy
                    buttonImage1 = "Comedy.png";
                    buttonImage2 = "Romance.png";
                    break;
                case "neutral":  // Neutral
                    buttonImage1 = "SciFi.png";
                    buttonImage2 = "Family.png";
                    break;
                case "disgust":  //Disgust
                    buttonImage1 = "Action.png";
                    buttonImage2 = "Comedy.png";
                    break;
                case "anger": //Anger
                    buttonImage1 = "Action.png";
                    buttonImage2 = "Comedy.png";
                    break;
                case "sadness":  //Sad
                    buttonImage1 = "Romance.png";
                    buttonImage2 = "drama.png";
                    break;
                case "fear":  //Fear
                    buttonImage1 = "Horror.png";
                    buttonImage2 = "Romance.png";
                    break;
                case "surprise": //Surprise
                    buttonImage1 = "Comedy.png";
                    buttonImage2 = "Romance.png";
                    break;
                default:
                    buttonImage1 = "Comedy.png";
                    buttonImage2 = "Family.png";
                    break;

            }

            Label header = new Label
            {
                Text = "Based on your emotions we believe these images represent want you want to watch",
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                TextColor = Color.Black,
            };

            ImageButton imageButton1 = new ImageButton
            {
                Source = buttonImage1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Aspect = Aspect.Fill,
                HeightRequest = 200,
                WidthRequest = 200

            };
            imageButton1.Clicked += (sender, args) => DetermineGenre(buttonImage1);

            ImageButton imageButton2 = new ImageButton
            {
                Source = buttonImage2,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Aspect = Aspect.Fill,
                WidthRequest = 200,
                HeightRequest = 200

            };
            imageButton2.Clicked += (sender, args) => DetermineGenre(buttonImage2);

            Label moreGenres = new Label
            {
                Text = "Did we get it wrong ?",
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                TextColor = Color.Black,
            };

            Button defaultGenreButton = new Button
            {
                Text = "Make an assumption",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };
            defaultGenreButton.Clicked += (sender, args) => DetermineGenre(null);
            // Add in correct page here


            Content = new StackLayout
            {
                Children = { header, imageButton1, imageButton2, moreGenres, defaultGenreButton }
            };
        }

      
        public void DetermineGenre(String genre)
        {
            switch (genre)
            {
                case "Action.png":
                    SelectedGenre = "Action";
                    DisplayAlert(genre, SelectedGenre, "close");
                    break;
                case "Comedy.png":
                    SelectedGenre = "Comedy";
                    DisplayAlert(genre, SelectedGenre, "close");
                    break;
                case "drama.png":
                    SelectedGenre = "Drama";
                    DisplayAlert(genre, SelectedGenre, "close");
                    break;
                case "Family.png":
                    SelectedGenre = "Family";
                    DisplayAlert(genre, SelectedGenre, "close");
                    break;
                case "Horror.png":
                    SelectedGenre = "Horror";
                    DisplayAlert(genre, SelectedGenre, "close");
                    break;
                case "Romance.png":
                    SelectedGenre = "Romance";
                    DisplayAlert(genre, SelectedGenre, "close");
                    break;
                case "SciFi.png":
                    SelectedGenre = "Sci-Fi";
                    DisplayAlert(genre, SelectedGenre, "close");
                    break;
                default:
                    DisplayAlert("Nothing", "Unknown", "close");
                    break;

            }

            switch (detectedEmotion)
            {
                case "happiness":   //Happy
                    EmotionGenre = "Romance";
                    break;
                case "neutral":  // Neutral
                    EmotionGenre = "SciFi";
                    break;
                case "disgust":  //Disgust
                    EmotionGenre = "Comedy";
                    break;
                case "anger": //Anger
                    EmotionGenre = "Thriller";
                    break;
                case "sadness":  //Sad
                    EmotionGenre = "Drama";
                    break;
                case "fear":  //Fear
                    EmotionGenre = "Horror";
                    break;
                case "surprise": //Surprise
                    EmotionGenre = "Action";
                    break;
                default:
                    EmotionGenre = "Family";
                    break;

            }

            MapGenreToID(EmotionGenre, SelectedGenre, age);
        }

        public async void MapGenreToID(string genreBasedOnEmotion, string genreBasedOnSelectedImage, int UserAge)
        {
            int genreBasedOnEmotionID;
            int genreBasedOnSelectedImageID;

            switch (genreBasedOnEmotion)
            {
                case "Romance":   //Happy
                    genreBasedOnEmotionID = (int)Genres.Romance;
                    break;
                case "SciFi":  // Neutral
                    genreBasedOnEmotionID = (int)Genres.ScienceFiction;
                    break;
                case "Comedy":  //Disgust
                    genreBasedOnEmotionID = (int)Genres.Comedy;
                    break;
                case "Thriller": //Anger
                    genreBasedOnEmotionID = (int)Genres.Thriller;
                    break;
                case "Drama":  //Sad
                    genreBasedOnEmotionID = (int)Genres.Drama;
                    break;
                case "Horror":  //Fear
                    genreBasedOnEmotionID = (int)Genres.Horror;
                    break;
                case "Action": //Surprise
                    genreBasedOnEmotionID = (int)Genres.Action;
                    break;
                default:
                    genreBasedOnEmotionID = (int)Genres.Family;
                    break;

            }

            switch (genreBasedOnSelectedImage)
            {
                case "Romance":   //Happy
                    genreBasedOnSelectedImageID = (int)Genres.Romance;
                    break;
                case "SciFi":  // Neutral
                    genreBasedOnSelectedImageID = (int)Genres.ScienceFiction;
                    break;
                case "Comedy":  //Disgust
                    genreBasedOnSelectedImageID = (int)Genres.Comedy;
                    break;
                case "Thriller": //Anger
                    genreBasedOnSelectedImageID = (int)Genres.Thriller;
                    break;
                case "Drama":  //Sad
                    genreBasedOnSelectedImageID = (int)Genres.Drama;
                    break;
                case "Horror":  //Fear
                    genreBasedOnSelectedImageID = (int)Genres.Horror;
                    break;
                case "Action": //Surprise
                    genreBasedOnSelectedImageID = (int)Genres.Action;
                    break;
                default:
                    genreBasedOnSelectedImageID = (int)Genres.Family;
                    break;

            }

            var ageAndEmotionGenre = new AgeAndEmotionGenre
            {
                emotionGenre = $"{genreBasedOnEmotionID}, {genreBasedOnSelectedImageID}",
                age = age,
            };

            await Navigation.PushAsync(new MoviePage(ageAndEmotionGenre));
        }
    }
}