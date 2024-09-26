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
            distanceMultiBindingLabel.Text = distanceMultiBindingLabel.Text == DistanceEnum.Distance75km.ToString()
                ? DistanceEnum.Distance100km.ToString()
                : DistanceEnum.Distance75km.ToString();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            distanceBindingLabel.Text = distanceBindingLabel.Text == DistanceEnum.Distance75km.ToString()
                ? DistanceEnum.Distance100km.ToString()
                : DistanceEnum.Distance75km.ToString();
        }
    }

}
