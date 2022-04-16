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
        IDictionary<string, Image> movies_time;
        IDictionary<string, Image> movies_filmType;
        public GenreImages()
        {
            InitializeComponent();

            genre_action.Opacity = 1.0F;
            genre_comedy.Opacity = 1.0F;
            genre_family.Opacity = 1.0F;
            genre_horror.Opacity = 1.0F;
            genre_romance.Opacity = 1.0F;
            genre_scifi.Opacity = 1.0F;

            // key = genre, value = Image reference
             movies_genres = new Dictionary<string, Image>
                    {
                        { "comedy", genre_comedy },
                        { "action", genre_action },
                        { "family", genre_family },
                        { "horror", genre_horror },
                        { "romance", genre_romance },
                        { "scifi", genre_scifi },
                    };
            // key = time, value = Image reference
            movies_time = new Dictionary<string, Image>
            {
                { "1900-1950", yearsOLD_family },
                { "1950-2010", yearsNEUTRAL_family },
                { "2010-2050", yearsNEW_family },
            };

            // key = film type, value = Image reference
            movies_filmType = new Dictionary<string, Image>
            {
                { "movie", imgMovie },
                { "series", imgSoap },
            };

        }

        string genre = "";
        string time = "";
        string filmType = "";

        private void completionCheck()
        {

            if (!genre.Equals("") && !time.Equals("") && !filmType.Equals(""))
            {
                btnProceedWithGenres.IsVisible = true;
            }
        }
        private async void genre_clicked(object sender, EventArgs e)
        {
       
            var imageSender = (Image)sender;

            foreach (KeyValuePair<string, Image> entry in movies_genres)
            {
                if (entry.Value != imageSender)
                {
                    entry.Value.Opacity = 1.0F;
                }
                else
                {
                    entry.Value.Opacity = 0.3F;
                    genre = entry.Key;
                }
            }

            completionCheck();
        }

        private async void time_clicked(object sender, EventArgs e)
        {

            var imageSender = (Image)sender;

            foreach (KeyValuePair<string, Image> entry in movies_time)
            {
                if (entry.Value != imageSender)
                {
                    entry.Value.Opacity = 1.0F;
                }
                else
                {
                    entry.Value.Opacity = 0.3F;
                    time = entry.Key;
                }
            }
            completionCheck();
        }

        private async void filmType_clicked(object sender, EventArgs e)
        {

            var imageSender = (Image)sender;

            foreach (KeyValuePair<string, Image> entry in movies_filmType)
            {
                if (entry.Value != imageSender)
                {
                    entry.Value.Opacity = 1.0F;
                }
                else
                {
                    entry.Value.Opacity = 0.3F;
                    filmType = entry.Key;
                }
            }
            completionCheck();
        }

        void Handle_Scrolled(object sender, ScrolledEventArgs e)
        {
            var x = scroller.ScrollX;
            var y = scroller.ScrollY;

            if (y <= 5)
            {
                fab.IsVisible = true;
                // go up
                fab.Source = ImageSource.FromFile("downarrow.png");
            }
            else if (y >= 330)
            {
                fab.IsVisible = true;
                // go down
                fab.Source = ImageSource.FromFile("uparrow.png");
            }
            else
            {
                // middle
                fab.IsVisible = false;
            }

            Console.WriteLine(x + "," + y);

        }

        private async void onNeutral(object sender, EventArgs e)
        {

        }
        private async void onSadness(object sender, EventArgs e)
        {

        }
        private async void BtnGenreProceed_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("", "Clicked", "ok");
        }

    }
}