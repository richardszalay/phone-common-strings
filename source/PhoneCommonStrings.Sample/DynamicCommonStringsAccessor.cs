using System;
using System.Linq;
using System.ComponentModel;
using System.Reflection;

namespace PhoneCommonStrings.Sample
{
    /// <summary>
    /// Subclasses CommonStringsAccessor to add a firable INotifyProprtyChange to 
    /// support changing the language at runtime (required for the sample)
    /// </summary>
    public class DynamicCommonStringsAccessor : CommonStringsAccessor, INotifyPropertyChanged
    {
        public void NotifyCultureChanged()
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                var propertyNames = this.GetType()
                    .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Select(property => property.Name);

                foreach (string propertyName in propertyNames)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
