using MauiTestApp.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MauiTestApp.ViewModels
{
    class MainPageViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand Set20Command { get; private set; }
        public ICommand Set50Command { get; private set; }


        //private string _selectedDistance = DistanceEnum.Distance20km.ToString();
        //public string SelectedDistance
        //{
        //    get { return _selectedDistance; }
        //    set
        //    {
        //        _selectedDistance = value;
        //        OnPropertyChanged();
        //    }
        //}

        private int _selectedDistance = (int)DistanceEnum.Distance20km;
        public int SelectedDistance
        {
            get { return _selectedDistance; }
            set
            {
                _selectedDistance = value;
                OnPropertyChanged();
            }
        }

        public MainPageViewModel()
        {
            //Set20Command = new Command(() => SelectedDistance = DistanceEnum.Distance20km.ToString());
            //Set50Command = new Command(() => SelectedDistance = DistanceEnum.Distance50km.ToString());
            Set20Command = new Command(() => SelectedDistance = (int)DistanceEnum.Distance20km);
            Set50Command = new Command(() => SelectedDistance = (int)DistanceEnum.Distance50km);
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}
