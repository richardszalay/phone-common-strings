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
using System.Xml.Linq;

namespace PhoneCommonStrings.Sample
{
    public partial class AboutPage : PhoneApplicationPage
    {
        public AboutPage()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        public string VersionString
        {
            get
            {
                return String.Format(PhoneCommonStrings.AboutPage.VersionLabelFormat,
                    GetApplicationVersion());
            }
        }

        private string GetApplicationVersion()
        {
            return XDocument.Load("WMAppManifest.xml")
                .Root.Element("App").Attribute("Version").Value;
        }
    }
}