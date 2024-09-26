using MauiTestApp.Models;
using MauiTestApp.ViewModels;

namespace MauiTestApp.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            distanceLabel.Text = DistanceEnum.Distance100km.ToString();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            currentDistanceLabel.Text = ((MainPageViewModel)BindingContext).SelectedDistance.ToString();
        }
    }

}
