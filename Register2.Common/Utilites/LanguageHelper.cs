﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Register.Common.Utilites
{
    public class LanguageHelper
    {
        public static bool IsArabic
        {
            get { return Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName.ToLower() == "ar"; }
        }
    }
}
