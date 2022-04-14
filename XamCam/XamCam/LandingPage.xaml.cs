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
    public partial class LandingPage : ContentPage
    {
        public LandingPage()
        {
            InitializeComponent();

        }

        private async void BtnSelfieProceed_Clicked(object sender, EventArgs e)
        {
            // go to page
            await Navigation.PushAsync(new SelfiePage());
        }
        private async void BtnEmojiProceed_Clicked(object sender, EventArgs e)
        {
            // go to page
            await Navigation.PushAsync(new EmojiPage());
        }
    }
}