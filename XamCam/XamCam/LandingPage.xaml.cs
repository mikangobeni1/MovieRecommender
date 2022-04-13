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
        public bool isVisible;
        public LandingPage()
        {
            InitializeComponent();

            isVisible = false;
            setBtnSelfieVisible();
        }
        void setBtnSelfieVisible()
        {
            btnSelfie.IsVisible = isVisible;
            lblOr.IsVisible = isVisible;
        }
        void onToggled(object sender, ToggledEventArgs e)
        {
            isVisible = !isVisible;
            setBtnSelfieVisible();
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