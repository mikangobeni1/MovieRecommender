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
    public partial class MoviePage : ContentPage
    {
        public MoviePage(String genreIDs, int age)
        {
            InitializeComponent();
            BindingContext = new MovieViewModel(genreIDs, age);
            ColorTypeConverter converter = new ColorTypeConverter();
            Color backSectionBackgroundColor = (Color)(converter.ConvertFromInvariantString("#9A7245"));     
            ((NavigationPage)Application.Current.MainPage).BarTextColor = backSectionBackgroundColor;
        }
    }
}