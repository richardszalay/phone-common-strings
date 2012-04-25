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
    public partial class EditItemPage : PhoneApplicationPage
    {
        public EditItemPage()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            ApplicationTitle.Text = ((string)NavigationContext.QueryString["item"]).ToUpperInvariant();
        }

        private void OnSave()
        {
            NavigationService.GoBack();
        }

        private void OnCancel()
        {
            NavigationService.GoBack();
        }

        public ICommand SaveCommand
        {
            get { return new DelegateCommand(OnSave); }
        }

        public ICommand CancelCommand
        {
            get { return new DelegateCommand(OnCancel); }
        }
    }
}