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

        bool consent_Popi = false;
        private async void BtnSelfieProceed_Clicked(object sender, EventArgs e)
        {


            if (!consent_Popi)
            {
                bool answer = await DisplayAlert("Popi Act", "Do you allow this app to capture your face biometrics?", "Yes", "No");
                if (answer)
                {
                    consent_Popi = true;
                    // go to page
                    await Navigation.PushAsync(new SelfiePage());
                }
                else
                {
                    await DisplayAlert("", "Choose emoticon to continue", "Cool");
                }
            }
            else
            {
                // go to page
                await Navigation.PushAsync(new SelfiePage());
            }
        }

        private async void BtnEmojiProceed_Clicked(object sender, EventArgs e)
        {
            // go to page
            await Navigation.PushAsync(new EmojiPage());
        }
    }
}