using System;

namespace Game.Scripts.Common
{
    public sealed class Utils
    {
        public static string FormatInt(int value) =>
            $"{value:###,###,###,###,###}";


        public static string FormatFloat(float value) =>
            $"{value:###,###,###,###,#}";


        public static string SecondsToText(float value)
        {
            var span = TimeSpan.FromSeconds(value);

            var seconds = span.Seconds;
            var minutes = span.Minutes;
            var hours = span.Hours;
            var days = span.Days;

            var time = string.Empty;
            if (days > 0) time += $"{days}d:";
            if (hours > 0) time += $"{hours}h:";
            if (minutes > 0) time += $"{minutes}m:";
            if (seconds >= 0) time += $"{seconds + 1}s";

            return time;
        }
    }
}