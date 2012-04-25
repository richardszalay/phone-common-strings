using System;
using System.Linq;
using System.ComponentModel;
using System.Reflection;

namespace PhoneCommonStrings.Sample
{
    public class SampleStringsAccessor : INotifyPropertyChanged
    {
        private SampleStrings sampleStrings = new SampleStrings();

        public SampleStrings SampleStrings { get { return sampleStrings; } }

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
