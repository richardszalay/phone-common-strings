using Microsoft.Phone.Controls;
using System.Windows;
using System;
using System.Windows.Input;
using PhoneCommonStrings.Sample.Infrastructure;
using System.Windows.Navigation;
using Microsoft.Phone.Shell;
using System.Windows.Threading;
using Microsoft.Phone.Reactive;

namespace PhoneCommonStrings.Sample
{
    public partial class MainPage : PhoneApplicationPage
    {
        private readonly TimeSpan DataLoadDelay = TimeSpan.FromSeconds(1);

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        private void LoadData()
        {
            LoadingTextBlock.Visibility = Visibility.Visible;
            ItemsListBox.Visibility = Visibility.Collapsed;

            SystemTray.SetProgressIndicator(this, new ProgressIndicator
                {
                    IsVisible = true,
                    IsIndeterminate = true,
                    Text = PhoneCommonStrings.Statuses.LoadingLabel
                });

            Scheduler.Dispatcher.Schedule(() =>
                {
                    SystemTray.SetProgressIndicator(this, new ProgressIndicator
                    {
                        IsVisible = false
                    });

                    LoadingTextBlock.Visibility = Visibility.Collapsed;
                    ItemsListBox.Visibility = Visibility.Visible;

                }, DataLoadDelay);
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.New)
            {
                LoadData();
            }

            base.OnNavigatedTo(e);
        }

        private void ListItem_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var tappedValue = (string)ItemsListBox.SelectedValue;

            string itemPageUriString = "/PhoneCommonStrings.Sample;component/ItemPage.xaml?item=" + 
                Uri.EscapeUriString(tappedValue);

            NavigationService.Navigate(new Uri(itemPageUriString, UriKind.Relative));
        }

        public ICommand RefreshCommand
        {
            get { return new DelegateCommand(LoadData); }
        }

        public ICommand GoToSettingsPageCommand
        {
            get { return new DelegateCommand(OnGoToSettingsPage); }
        }

        private void OnGoToSettingsPage()
        {
            NavigationService.Navigate(new Uri("/PhoneCommonStrings.Sample;component/SettingsPage.xaml", UriKind.Relative));
        }

        public ICommand GoToAboutPageCommand
        {
            get { return new DelegateCommand(OnGoToAboutPage); }
        }

        private void OnGoToAboutPage()
        {
            NavigationService.Navigate(new Uri("/PhoneCommonStrings.Sample;component/AboutPage.xaml", UriKind.Relative));
        }
    }
}