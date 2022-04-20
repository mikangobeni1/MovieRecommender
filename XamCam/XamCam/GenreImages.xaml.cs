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
    public partial class GenreImages : ContentPage
    {
        IDictionary<string, Image> movies_genres;

        string selectedGenre;
        int userAge;
        string emotion;
        public GenreImages(AgeEmotionGenre ageEmotion)
        {
            InitializeComponent();

            userAge = ageEmotion.age;
            emotion = ageEmotion.emotion;

            genre_action.Opacity = 1.0F;
            genre_comedy.Opacity = 1.0F;
            genre_family.Opacity = 1.0F;
            genre_horror.Opacity = 1.0F;
            genre_romance.Opacity = 1.0F;
            genre_scifi.Opacity = 1.0F;

            // key = selectedGenre, value = Image reference
            movies_genres = new Dictionary<string, Image>
                    {
                        { "Comedy", genre_comedy },
                        { "Action", genre_action },
                        { "Family", genre_family },
                        { "Horror", genre_horror },
                        { "Romance", genre_romance },
                        { "SciFi", genre_scifi },
                    };
        }
        private void BackNav_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void Proceed_Clicked()
        {

            if (!selectedGenre.Equals(null))
            {
                btnProceedWithGenres.IsVisible = true;
            }
        }

        private void Genre_Clicked(object sender, EventArgs e)
        {

            var imageSender = (Image)sender;

            foreach (KeyValuePair<string, Image> entry in movies_genres)
            {
                if (entry.Value != imageSender)
                {
                    entry.Value.Opacity = 0.25F;
                }
                else
                {
                    entry.Value.Opacity = 1F;
                    selectedGenre = entry.Key;
                }
            }

            Proceed_Clicked();
        }
        private async void Proceed_Clicked(object sender, EventArgs e)
        {
            var ageEmotionGenre = new AgeEmotionGenre
            {
                emotion = emotion,
                genre = selectedGenre,
                age = userAge
,
            };
            
            await Navigation.PushAsync(new MoviePage(ageEmotionGenre));

        }

    }
}