using System;
using System.Collections.Generic;
using System.Text;
using Android.App;

namespace Plugin.Openpay.Forms.Platforms.Android
{
    public static class ActivityImplementation
    {
        public static void Init(Activity activity) => OpenpayImplementation.Activity = activity ?? throw new ArgumentNullException(nameof(activity));
    }
}
