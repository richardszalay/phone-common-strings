using System.Reflection;
using System.Linq;

namespace PhoneCommonStrings
{
    /// <summary>
    /// An App.xaml Resources-friendly accessor to PhoneCommonStrings
    /// </summary>
    public class CommonStringsAccessor
    {
        private readonly ThemeColors themeColors = new ThemeColors();
        private readonly Actions actions = new Actions();
        private readonly AboutPage aboutPage = new AboutPage();
        private readonly SettingsPage settingsPage = new SettingsPage();
        private readonly Statuses statuses = new Statuses();
        
        /// <summary>
        /// Gets strings for theme colors supported by Windows Phone
        /// </summary>
        public ThemeColors ThemeColors { get { return themeColors; } }

        /// <summary>
        /// Gets strings for actions used by the application bar, 
        /// context menus, hyperlinks and buttons
        /// </summary>
        public Actions Actions { get { return actions; } }

        /// <summary>
        /// Gets strings used to build an "about" page
        /// </summary>
        public AboutPage AboutPage { get { return aboutPage; } }

        /// <summary>
        /// Gets strings used to build a "settings" page
        /// </summary>
        public SettingsPage SettingsPage { get { return settingsPage; } }

        /// <summary>
        /// Gets strings for status that represent the state of a page or activity
        /// </summary>
        public Statuses Statuses { get { return statuses; } }
    }
}
