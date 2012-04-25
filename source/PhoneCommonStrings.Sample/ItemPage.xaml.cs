using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using PhoneCommonStrings.Sample.Infrastructure;

namespace PhoneCommonStrings.Sample
{
    public partial class ItemPage : PhoneApplicationPage
    {
        public ItemPage()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            PageTitle.Text = (string)NavigationContext.QueryString["item"];
        }

        private void OnEdit()
        {
            NavigationService.Navigate(new Uri("/EditItemPage.xaml?item=" +
                Uri.EscapeUriString(NavigationContext.QueryString["item"]), UriKind.Relative));
        }
        
        public ICommand EditCommand
        {
            get { return new DelegateCommand(OnEdit); }
        }
    }
}