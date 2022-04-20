using Newtonsoft.Json.Linq;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamCam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelfiePage : ContentPage
    {
        public SelfiePage()
        {
            InitializeComponent();


            ColorTypeConverter converter = new ColorTypeConverter();
            Color backSectionBackgroundColor = (Color)(converter.ConvertFromInvariantString("#9A7245"));
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.White;
            ((NavigationPage)Application.Current.MainPage).BarTextColor = backSectionBackgroundColor;


            CaptureFace();
        }

        public async void CaptureFace()
        {
            try
            {

                var photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions()
                {
                    DefaultCamera = CameraDevice.Front,
                    Directory = "Xamarin",
                    SaveToAlbum = true,
                    Name = "face.jpg"
                });

                if (photo != null)
                {
                    // convert stream to bytes
                    var upfilebytes = File.ReadAllBytes(photo.Path);
                    // convert bytes to base64
                    var base64 = Convert.ToBase64String(upfilebytes);
                    // http client
                    var client = new HttpClient();
                    var formContent = new MultipartFormDataContent();
                    formContent.Headers.ContentType.MediaType = "multipart/form-data";
                    var content = new StringContent(base64);
                    formContent.Add(content, "image_base64");
                    var message = await client.PostAsync("https://api-us.faceplusplus.com/facepp/v3/detect?api_key=8g0e2SuGg1bFNU3B0WC7gZepIY0Jv9XE&api_secret=jZL-LfCyw57R5nHXmFRD-TYBtQbA4BXG&return_attributes=emotion,age,gender", formContent);
                    var result = await message.Content.ReadAsStringAsync();

                    // get results

                    JObject json = JObject.Parse(result);
                    var age = Convert.ToInt32(json["faces"][0]["attributes"]["age"]["value"]);

                    var emotion_anger = float.Parse(json["faces"][0]["attributes"]["emotion"]["anger"].ToString());
                    var emotion_disgust = float.Parse(json["faces"][0]["attributes"]["emotion"]["disgust"].ToString());
                    var emotion_fear = float.Parse(json["faces"][0]["attributes"]["emotion"]["fear"].ToString());
                    var emotion_happiness = float.Parse(json["faces"][0]["attributes"]["emotion"]["happiness"].ToString());
                    var emotion_neutral = float.Parse(json["faces"][0]["attributes"]["emotion"]["neutral"].ToString());
                    var emotion_sadness = float.Parse(json["faces"][0]["attributes"]["emotion"]["sadness"].ToString());
                    var emotion_surprise = float.Parse(json["faces"][0]["attributes"]["emotion"]["surprise"].ToString());

                    // key = emotion, value = score
                    IDictionary<string, float> emotions = new Dictionary<string, float>
                    {
                        { "anger", emotion_anger },
                        { "neutral", emotion_neutral },
                        { "disgust", emotion_disgust },
                        { "fear", emotion_fear },
                        { "happiness", emotion_happiness },
                        { "sadness", emotion_sadness },
                        { "surprise", emotion_surprise }
                    };
                    // greatest value
                    var maxEmotionValue = emotions.Values.Max();

                    // greatest key
                    var maxEmotionName = emotions.FirstOrDefault(x => x.Value == maxEmotionValue).Key;

                    var ageEmotionGenre = new AgeEmotionGenre
                    {
                        emotion = maxEmotionName,
                        age = age,
                    };

                    var previousPage = Navigation.NavigationStack.LastOrDefault();
                    await Navigation.PushAsync(new GenreSelectionPage(ageEmotionGenre));
                    Navigation.RemovePage(previousPage);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Retake Biometric", "Show whole face", "Ok");
                // go back to main page
                await Navigation.PopAsync();
            }



        }

    }
}