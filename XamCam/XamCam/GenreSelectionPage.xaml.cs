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
                    buttonImage1 = "Comedyf.jpg";
                    buttonImage2 = "Romancef.png";
                    break;
                case "neutral":
                    buttonImage1 = "SciFif.jpg";
                    buttonImage2 = "Familyf.jpg";
                    break;
                case "disgust":
                    buttonImage1 = "Action.png";
                    buttonImage2 = "Comedyf.jpg";
                    break;
                case "anger":
                    buttonImage1 = "Actionf.jpg";
                    buttonImage2 = "Comedyf.jpg";
                    break;
                case "sadness":
                    buttonImage1 = "Romancef.png";
                    buttonImage2 = "dramaf.jpg";
                    break;
                case "fear":
                    buttonImage1 = "Horrorf.jpg";
                    buttonImage2 = "Romancef.png";
                    break;
                case "surprise":
                    buttonImage1 = "Comedyf.jpg";
                    buttonImage2 = "Romancef.png";
                    break;
                default:
                    buttonImage1 = "Comedyf.jpg";
                    buttonImage2 = "Familyf.jpg";
                    break;

            }

            Label header = new Label
            {
                Text = "Your detected emotion is " + detectedEmotion,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                TextColor = Color.Black,
            };

            Label headerPick = new Label
            {
                Text = "Choose 1",
                FontSize = 16,
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
                WidthRequest = 200,
                CornerRadius = 10
            };

            imageButton1.Clicked += (sender, args) => DetermineGenre(buttonImage1);

            ImageButton imageButton2 = new ImageButton
            {
                Source = buttonImage2,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Aspect = Aspect.Fill,
                WidthRequest = 200,
                HeightRequest = 200,
                CornerRadius = 10

            };
            imageButton2.Clicked += (sender, args) => DetermineGenre(buttonImage2);

            Label moreGenres = new Label
            {
                Text = "Did we get it wrong ?",
                FontSize = 16,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                TextColor = Color.Black,
            };
            ColorTypeConverter newConverter = new ColorTypeConverter();
            Color btnBackGroundColor = (Color)(newConverter.ConvertFromInvariantString("#F1F1F1"));
            Color btnTextColor = (Color)(newConverter.ConvertFromInvariantString("#000000"));

            Button defaultGenreButton = new Button
            {
                BackgroundColor = Color.Silver,
                TextColor = btnTextColor,
                CornerRadius = 10,
                WidthRequest = 300,
                Text = "Other options",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };
            defaultGenreButton.Clicked += (sender, args) => NavigateToGenreImages();

            Content = new StackLayout
            {
                Children = { header, headerPick, imageButton1, imageButton2, moreGenres, defaultGenreButton }
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
                default:
                    selectedGenre = "SciFi";
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