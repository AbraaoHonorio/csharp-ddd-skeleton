using System.Text.RegularExpressions;

namespace XPTO.Core.Domain
{
    public class AssertionConcern : Notifiable
    {
        public void IsEquals(object object1, object object2, string message)
        {
            if (object1.Equals(object2))
            {
                AddNotification(message);
            }
        }

        public void IsDifferent(object object1, object object2, string message)
        {
            if (!object1.Equals(object2))
            {
                AddNotification(message);
            }
        }

        public void BeDifferent(string pattern, string value, string message)
        {
            var regex = new Regex(pattern);

            if (!regex.IsMatch(value))
            {
                AddNotification(message);
            }
        }

        public void ValidateLength(string value, int maximum, string message)
        {
            var length = value.Trim().Length;
            if (length > maximum)
            {
                AddNotification(message);
            }
        }

        public void ValidateLength(string value, int minimum, int maximum, string message)
        {
            var length = value.Trim().Length;
            if (length < minimum || length > maximum)
            {
                AddNotification(message);
            }
        }

        public void ValidateIfMinor(double value, double valueMinimum, string message)
        {
            if (value < valueMinimum)
                AddNotification(message);
        }

        public void ValidateIfMinor(decimal value, decimal valueMinimum, string message)
        {
            if (value < valueMinimum)
                AddNotification(message);
        }

        public void ValidateIfMinor(int value, int valueMinimum, string message)
        {
            if (value < valueMinimum)
                AddNotification(message);
        }

        protected void IsEmpty(string value, string message)
        {
            if (value == null || value.Trim().Length == 0)
                AddNotification(message);
        }
    }
}