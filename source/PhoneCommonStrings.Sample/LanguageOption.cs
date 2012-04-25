using System;
using System.Globalization;

namespace PhoneCommonStrings.Sample
{
    public class LanguageOption
    {
        public LanguageOption(CultureInfo culture)
        {
            this.CultureInfo = culture;
        }

        public CultureInfo CultureInfo { get; private set; }

        public string DisplayName
        {
            get { return CultureInfo.NativeName; }
        }
    }
}
