using System;
using System.Globalization;

namespace Sublime_Backend_Assessment.Utility
{
    public static class CommonExtention
    {
        public static double DateParser(this string dateString)
        {
            var milisecondTimeStamp = dateString.Substring(6).TrimEnd(')', '/');
            double ticks = double.Parse(milisecondTimeStamp);
            return ticks;
        }

        public static string DateFormater(this double dateTicks, string format = "yyyy/MM/dd")
        {
            CultureInfo provider = CultureInfo.CurrentUICulture;
            TimeSpan time = TimeSpan.FromMilliseconds(dateTicks);
            DateTime converredDate = new DateTime(1970, 1, 1) + time;
            return converredDate.ToString(format, provider);
        }

        public static string DurationFormater(this string duration, string format = @"hh\:mm\:ss")
        {
            int timeSpan = int.Parse(duration);
            return DurationFormater(timeSpan, format);
        }

        public static string DurationFormater(this int duration, string format = @"hh\:mm\:ss")
        {
            TimeSpan time = TimeSpan.FromSeconds(duration);
            return time.ToString(format);
        }
    }
}