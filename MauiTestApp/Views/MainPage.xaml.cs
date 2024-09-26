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
            if (distanceLabel.Text == DistanceEnum.Distance100km.ToString())
            {
                distanceLabel.Text = DistanceEnum.Distance75km.ToString();
            }
            else
            {
                distanceLabel.Text = DistanceEnum.Distance100km.ToString();
            }
        }
    }

}
