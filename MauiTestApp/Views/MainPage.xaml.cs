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


        private void Binding_Button_Clicked(object sender, EventArgs e)
        {
            //distanceBindingLabel.Text = distanceBindingLabel.Text == DistanceEnum.Distance75km.ToString()
            //    ? DistanceEnum.Distance100km.ToString()
            //    : DistanceEnum.Distance75km.ToString();
            distanceBindingLabel.Text = distanceBindingLabel.Text == ((int)DistanceEnum.Distance75km).ToString()
                ? ((int)DistanceEnum.Distance100km).ToString()
                : ((int)DistanceEnum.Distance75km).ToString();
        }

        private void MultiBinding_Button_Clicked(object sender, EventArgs e)
        {
            //distanceBindingLabel.Text = distanceBindingLabel.Text == DistanceEnum.Distance75km.ToString()
            //    ? DistanceEnum.Distance100km.ToString()
            //    : DistanceEnum.Distance75km.ToString();
            distanceMultiBindingLabel.Text = distanceMultiBindingLabel.Text == ((int)DistanceEnum.Distance75km).ToString()
                ? ((int)DistanceEnum.Distance100km).ToString()
                : ((int)DistanceEnum.Distance75km).ToString();
        }
    }

}
