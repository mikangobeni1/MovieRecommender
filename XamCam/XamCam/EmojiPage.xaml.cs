using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamCam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmojiPage : ContentPage
    {
        String emotion;
        public EmojiPage()
        {

           
            InitializeComponent();

            ColorTypeConverter converter = new ColorTypeConverter();
            Color backSectionBackgroundColor = (Color)(converter.ConvertFromInvariantString("#9A7245"));
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.White;
            ((NavigationPage)Application.Current.MainPage).BarTextColor = backSectionBackgroundColor;

            f_anger.IsVisible = false;
            f_disgust.IsVisible = false;
            f_fear.IsVisible = false;
            f_happiness.IsVisible = false;
            f_neutral.IsVisible = false;
            f_sadness.IsVisible = false;
            f_surprised.IsVisible = false;

            btnEmojiProceed.IsVisible = false;

            emotion = "";

        }

        // image buttons
        void onHappiness(object sender, EventArgs args)
        {
            happiness();
            btnEmojiProceed.IsVisible = true;
        }

        void happiness()
        {
            f_happiness.IsVisible = true;
            emotion = "happiness";

            f_fear.IsVisible = false;
            f_surprised.IsVisible = false;
            f_neutral.IsVisible = false;
            f_disgust.IsVisible = false;
            f_anger.IsVisible = false;
            f_sadness.IsVisible = false;
        }
        void onFear(object sender, EventArgs args)
        {
            fear();
            btnEmojiProceed.IsVisible = true;

        }

        void fear()
        {
            f_fear.IsVisible = true;
            emotion = "fear";

            f_happiness.IsVisible = false;
            f_surprised.IsVisible = false;
            f_neutral.IsVisible = false;
            f_disgust.IsVisible = false;
            f_anger.IsVisible = false;
            f_sadness.IsVisible = false;
        }
        void onSurprised(object sender, EventArgs args)
        {
            surprise();
            btnEmojiProceed.IsVisible = true;

        }
        void surprise()
        {
            f_surprised.IsVisible = true;
            emotion = "surprise";

            f_fear.IsVisible = false;
            f_happiness.IsVisible = false;
            f_neutral.IsVisible = false;
            f_disgust.IsVisible = false;
            f_anger.IsVisible = false;
            f_sadness.IsVisible = false;
        }

        void onNeutral(object sender, EventArgs args)
        {
            neutral();
            btnEmojiProceed.IsVisible = true;

        }
        void neutral()
        {
            f_neutral.IsVisible = true;
            emotion = "neutral";

            f_fear.IsVisible = false;
            f_happiness.IsVisible = false;
            f_surprised.IsVisible = false;
            f_disgust.IsVisible = false;
            f_anger.IsVisible = false;
            f_sadness.IsVisible = false;
        }

        void onDisgust(object sender, EventArgs args)
        {
            disgust();
            btnEmojiProceed.IsVisible = true;

        }
        void disgust()
        {
            f_disgust.IsVisible = true;
            emotion = "disgust";

            f_fear.IsVisible = false;
            f_happiness.IsVisible = false;
            f_surprised.IsVisible = false;
            f_neutral.IsVisible = false;
            f_anger.IsVisible = false;
            f_sadness.IsVisible = false;
        }
        void onAnger(object sender, EventArgs args)
        {
            anger();
            btnEmojiProceed.IsVisible = true;

        }
        void anger()
        {
            f_anger.IsVisible = true;
            emotion = "anger";

            f_fear.IsVisible = false;
            f_happiness.IsVisible = false;
            f_surprised.IsVisible = false;
            f_neutral.IsVisible = false;
            f_disgust.IsVisible = false;
            f_sadness.IsVisible = false;
        }

        void onSadness(object sender, EventArgs args)
        {
            sadness();
            btnEmojiProceed.IsVisible = true;

        }
        void sadness()
        {
            f_sadness.IsVisible = true;
            emotion = "sadness";

            f_fear.IsVisible = false;
            f_happiness.IsVisible = false;
            f_surprised.IsVisible = false;
            f_neutral.IsVisible = false;
            f_disgust.IsVisible = false;
            f_anger.IsVisible = false;
        }

        private async void BtnEmojiProceed_Clicked(object sender, EventArgs e)
        {
            if (emotion.Equals(""))
            {
                // go to page
                await DisplayAlert("", "Choose emotion", "Ok");
            }
            else
            {
                // go to page
                await DisplayAlert("", "Emotion is: " + emotion, "Ok");
            }


        }

        float countInterval;
        private void BtnRandom_Clicked(object sender, EventArgs e)
        {
            btnRandomise.IsVisible = false;
            Random random = new Random();
            countInterval = 0.1F;
            int mainCounter = 0;
            int counter = 0;

            // pick random number
            int dice = random.Next(30, 50); //random number between 1 and 7.
            
            // interact with UI elements
            Device.StartTimer(TimeSpan.FromSeconds(countInterval), () =>
                    {
                        if (mainCounter <= dice)
                        {
                            Console.WriteLine("1st half");

                            Device.BeginInvokeOnMainThread(() =>
                            {

                                switch (counter)
                                {
                                    case 1:
                                        {
                                            disgust();
                                            break;
                                        }
                                    case 2:
                                        {
                                            anger();
                                            break;
                                        }
                                    case 3:
                                        {
                                            neutral();
                                            break;
                                        }
                                    case 4:
                                        {
                                            sadness();
                                            break;
                                        }
                                    case 5:
                                        {
                                            surprise();
                                            break;
                                        }
                                    case 6:
                                        {
                                            fear();
                                            break;
                                        }
                                    default:
                                        {
                                            happiness();
                                            break;
                                        }
                                }
                                if (counter == 7) counter = 1;
                                else { counter++; }
                                mainCounter++;
                            });
                            return true;
                        }
                        else
                        {
                            btnRandomise.IsVisible = true;
                            btnEmojiProceed.IsVisible = true;
                            return false;
               
                        }
                    });
        }
    }
}