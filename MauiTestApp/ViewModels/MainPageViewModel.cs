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
        public ICommand InvalidateCommand { get; private set; }

        private bool _invalidation = false;
        public bool Invalidation
        {
            get { return _invalidation; }
            set
            {
                var result = SetTransientProperty(ref _invalidation, value, OnPropertyChanged);
                return;
            }
        }

        private DistanceEnum _selectedDistance = DistanceEnum.Distance20km;
        public DistanceEnum SelectedDistance
        {
            get { return _selectedDistance; }
            set
            {
                var result = SetTransientProperty(ref _selectedDistance, value, OnPropertyChanged);
                return;
            }
        }

        private IList<DistanceEnum> _selectableDistances = new List<DistanceEnum>() { DistanceEnum.Distance5km,
            DistanceEnum.Distance10km,
            DistanceEnum.Distance20km,
            DistanceEnum.Distance30km,
            DistanceEnum.Distance50km,
            DistanceEnum.Distance75km,
            DistanceEnum.Distance100km };

        public IList<DistanceEnum> SelectableDistances
        {
            get { return _selectableDistances; }
            internal set => SetTransientProperty(ref _selectableDistances, value, OnPropertyChanged);
        }

        public MainPageViewModel()
        {
            Set20Command = new Command(() => SelectedDistance = DistanceEnum.Distance20km);
            Set50Command = new Command(() => SelectedDistance = DistanceEnum.Distance50km);
            InvalidateCommand = new Command(() => Invalidation = !Invalidation);
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public static bool SetTransientProperty<T>(ref T backingStore, T value, Action<string> raisePropertyChanged, [CallerMemberName] string propertyName = "")
        {
            if (Equals(backingStore, value))
            {
                return false;
            }

            backingStore = value;
            raisePropertyChanged?.Invoke(propertyName);
            return true;
        }
    }
}
