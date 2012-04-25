using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace PhoneCommonStrings.Sample
{
    public class ColorOption
    {
        public ColorOption(string name, string color)
        {
            this.Name = name;
            this.Color = color;
        }

        public string Name { get; private set; }
        public string Color { get; private set; }

        public string DisplayName
        {
            get
            {
                return PhoneCommonStrings.ThemeColors.ResourceManager.GetString(Name);
            }
        }
    }
}
