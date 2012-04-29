using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Phone.Controls;
using System.Globalization;
using System.Threading;
using System.Windows.Navigation;
using PhoneCommonStrings.Sample.Infrastructure;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows;

namespace PhoneCommonStrings.Sample
{
    public partial class SettingsPage : PhoneApplicationPage
    {
        private static CultureInfo originalCultureInfo;

        public SettingsPage()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.New)
            {
                originalCultureInfo = CultureInfo.CurrentUICulture;
            }

            base.OnNavigatedTo(e);
        }

        private void OnSave()
        {
            ApplyCultureInfo(SelectedLanguageOption.CultureInfo);

            NavigationService.GoBack();
        }

        private void OnCancel()
        {
            RollbackCultureInfo();
            NavigationService.GoBack();
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            RollbackCultureInfo();

            base.OnBackKeyPress(e);
        }

        private void RollbackCultureInfo()
        {
            ApplyCultureInfo(originalCultureInfo);
        }

        private void ApplyCultureInfo(CultureInfo cultureInfo)
        {
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            ((DynamicCommonStringsAccessor)Application.Current.Resources["PhoneCommonStrings"]).NotifyCultureChanged();
            ((SampleStringsAccessor)Application.Current.Resources["ApplicationStrings"]).NotifyCultureChanged();
        }
        
        public IList<ColorOption> ColorOptions
        {
            get { return colorOptions; }
        }

        public IList<LanguageOption> LanguageOptions
        {
            get { return languageOptions; }
        }

        private LanguageOption selectedLanguageOption;

        public LanguageOption SelectedLanguageOption
        {
            get
            {
                return selectedLanguageOption
                    ?? languageOptions.FirstOrDefault(x => x.CultureInfo.Name == Thread.CurrentThread.CurrentUICulture.Name)
                    ?? languageOptions.First(x => x.CultureInfo.Name == DefaultLanguageCode);
            }

            set
            {
                selectedLanguageOption = value;
            }
        }

        public ICommand SaveCommand
        {
            get { return new DelegateCommand(OnSave); }
        }

        public ICommand CancelCommand
        {
            get { return new DelegateCommand(OnCancel); }
        }

        private IList<ColorOption> colorOptions = new List<ColorOption>
        {
            new ColorOption("Theme", ((SolidColorBrush)Application.Current.Resources["PhoneAccentBrush"]).Color.ToString()),
            new ColorOption("Magenta", "#FFD80073"),
            new ColorOption("Purple", "#FFA200FF"),
            new ColorOption("Teal", "#FF00ABA9"),
            new ColorOption("Lime", "#FFA2C139"),
            new ColorOption("Brown", "#FFA05000"),
            new ColorOption("Pink", "#FFE671B8"),
            new ColorOption("Mango", "#FFF09609"),
            new ColorOption("Blue", "#FF1BA1E2"),
            new ColorOption("Red", "#FFE51400"),
            new ColorOption("Green", "#FF339933")
        };

        // FIXME: Not sure how to get this or 'languageOptions' at runtime
        private const string DefaultLanguageCode = "en-US";

        private IList<LanguageOption> languageOptions = new List<LanguageOption>
        {
            new LanguageOption(new CultureInfo("en-US")),
            new LanguageOption(new CultureInfo("en-GB")),
            new LanguageOption(new CultureInfo("ja-JP")),
            new LanguageOption(new CultureInfo("zh-CN")),
            new LanguageOption(new CultureInfo("zh-TW")),
            new LanguageOption(new CultureInfo("de-DE")),
            new LanguageOption(new CultureInfo("ru-RU")),
            new LanguageOption(new CultureInfo("it-IT")),
            new LanguageOption(new CultureInfo("fr-FR")),
            new LanguageOption(new CultureInfo("es-ES")),
            new LanguageOption(new CultureInfo("pt-BR")),
            new LanguageOption(new CultureInfo("hu-HU")),
            new LanguageOption(new CultureInfo("cs-CZ")),
            new LanguageOption(new CultureInfo("ko-KR")),
            new LanguageOption(new CultureInfo("da-DK")),
            new LanguageOption(new CultureInfo("nl-NL")),

        }.OrderBy(x => x.DisplayName).ToList();
    }
}