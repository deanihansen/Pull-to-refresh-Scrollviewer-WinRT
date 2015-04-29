using System.Diagnostics;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System;
using System.Threading.Tasks;

namespace PullToRefresh.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private RelayCommand refreshCommand;

        public MainViewModel()
        {
            LoadItems();
        }

        private void LoadItems()
        {
            Images.Add("ms-appx:///Images/1.jpg");
            Images.Add("ms-appx:///Images/2.jpg");
            Images.Add("ms-appx:///Images/3.jpg");
            Images.Add("ms-appx:///Images/4.jpg");
            Images.Add("ms-appx:///Images/1.jpg");
            Images.Add("ms-appx:///Images/2.jpg");
            Images.Add("ms-appx:///Images/3.jpg");
            Images.Add("ms-appx:///Images/4.jpg");
        }

        public const string ImagesPropertyName = "Images";

        private ObservableCollection<string> images = new ObservableCollection<string>();

        /// <summary>
        /// Sets and gets the Images property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<string> Images
        {
            get
            {
                return images;
            }

            set
            {
                if (images == value)
                {
                    return;
                }

                images = value;
                RaisePropertyChanged(ImagesPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="IsLoading" /> property's name.
        /// </summary>
        public const string IsLoadingPropertyName = "IsLoading";

        private bool isLoading = false;

        /// <summary>
        /// Sets and gets the IsLoading property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsLoading
        {
            get
            {
                return isLoading;
            }

            set
            {
                if (isLoading == value)
                {
                    return;
                }

                isLoading = value;
                RaisePropertyChanged(IsLoadingPropertyName);
            }
        }

        public RelayCommand RefreshCommand
        {
            get
            {
                return refreshCommand
                    ?? (refreshCommand = new RelayCommand(RefreshItems));
            }
        }

        private async void RefreshItems()
        {
            IsLoading = true;
            Images.Clear();
            await Task.Delay(2000);
            LoadItems();

            IsLoading = false;
        }
    }
}