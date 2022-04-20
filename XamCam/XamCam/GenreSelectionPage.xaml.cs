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
        string buttonImage1 = "";
        string buttonImage2 = "";
        public string selectedGenre = "";
        string detectedEmotion; 
        int age;

        public GenreSelectionPage(AgeEmotionGenre ageEmotionGenre)
        {


            InitializeComponent();

            

            ColorTypeConverter converter = new ColorTypeConverter();
            Color backSectionBackgroundColor = (Color)(converter.ConvertFromInvariantString("#9A7245"));
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.White;
            ((NavigationPage)Application.Current.MainPage).BarTextColor = backSectionBackgroundColor;
            detectedEmotion = ageEmotionGenre.emotion;
            age = ageEmotionGenre.age;

            switch (detectedEmotion)
            {
                case "happiness":
                    buttonImage1 = "Comedy.png";
                    buttonImage2 = "Romance.png";
                    break;
                case "neutral":
                    buttonImage1 = "SciFi.png";
                    buttonImage2 = "Family.png";
                    break;
                case "disgust":
                    buttonImage1 = "Action.png";
                    buttonImage2 = "Comedy.png";
                    break;
                case "anger":
                    buttonImage1 = "Action.png";
                    buttonImage2 = "Comedy.png";
                    break;
                case "sadness":
                    buttonImage1 = "Romance.png";
                    buttonImage2 = "drama.png";
                    break;
                case "fear":
                    buttonImage1 = "Horror.png";
                    buttonImage2 = "Romance.png";
                    break;
                case "surprise":
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
                Text = "Not Feeling it?",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };
            defaultGenreButton.Clicked += (sender, args) => NavigateToGenreImages();
            // Add in correct page here


            Content = new StackLayout
            {
                Children = { header, imageButton1, imageButton2, moreGenres, defaultGenreButton }
            };
        }

      
        public async void DetermineGenre(String genre)
        {
            switch (genre)
            {
                case "Action.png":
                    selectedGenre = "Action";
                    break;
                case "Comedy.png":
                    selectedGenre = "Comedy";
                    break;
                case "drama.png":
                    selectedGenre = "Drama";
                    break;
                case "Family.png":
                    selectedGenre = "Family";
                    break;
                case "Horror.png":
                    selectedGenre = "Horror";
                    break;
                case "Romance.png":
                    selectedGenre = "Romance";
                    break;
                case "SciFi.png":
                    selectedGenre = "SciFi";
                    break;
                default:
                    NavigateToGenreImages();
                    break;

            }

            var ageEmotionGenre = new AgeEmotionGenre
            {
                emotion = detectedEmotion,
                genre = selectedGenre,
                age = age,
            };

            await Navigation.PushAsync(new MoviePage(ageEmotionGenre));
        }

        public async void NavigateToGenreImages()
        {
            var ageEmotionGenre = new AgeEmotionGenre
            {
                emotion = detectedEmotion,
                age = age,
            };

            await Navigation.PushAsync(new GenreImages(ageEmotionGenre));
        }
    }
}