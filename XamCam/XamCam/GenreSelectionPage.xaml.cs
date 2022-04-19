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
        String detectedEmotion = "neutral";  //Need to use actual variable for emotion
        public GenreSelectionPage()
        {
            InitializeComponent();


            InitializeComponent();
            ColorTypeConverter converter = new ColorTypeConverter();
            Color backSectionBackgroundColor = (Color)(converter.ConvertFromInvariantString("#9A7245"));
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.White;
            ((NavigationPage)Application.Current.MainPage).BarTextColor = backSectionBackgroundColor;

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
                Text = "Not feeling it",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };
            defaultGenreButton.Clicked += async (sender, args) => await Navigation.PushAsync(new MoviePage());
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

        }
    }
}