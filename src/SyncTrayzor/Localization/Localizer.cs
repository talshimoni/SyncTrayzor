﻿using SmartFormat;
using SyncTrayzor.Properties.Strings;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SyncTrayzor.Localization
{
    public static class Localizer
    {
        public static string Translate(string key, params object[] parameters)
        {
            var culture = Thread.CurrentThread.CurrentUICulture;

            var format = Resources.ResourceManager.GetString(key, culture);
            
            if (format == null)
                return "!" + key + (parameters.Length > 0 ? ":" + String.Join(",", parameters) : "") + "!";

            return Smart.Format(culture, format, parameters);
        }

        public static string F(string format, params object[] parameters)
        {
            return Smart.Format(Thread.CurrentThread.CurrentUICulture, format, parameters);
        }

        public static string OriginalTranslation(string key)
        {
            return Resources.ResourceManager.GetString(key, new CultureInfo("en-US", false));
        }
    }
}
