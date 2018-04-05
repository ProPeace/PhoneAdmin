using System;
using Android.App;
using Android.App.Admin;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using static Android.App.KeyguardManager;
using static Android.OS.PowerManager;

namespace Alarm.Droid
{
    [Activity(Label = "AlarmActivity", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class AlarmActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Intent.AddFlags(Android.Content.ActivityFlags.ClearTop);

            DevicePolicyManager devicePolicyManager = (DevicePolicyManager)GetSystemService(DevicePolicyService);

            ActivityManager activityManager = (ActivityManager)GetSystemService(ActivityService);
            var compName = new ComponentName(this, Java.Lang.Class.FromType(typeof(DeviceAdminLock)).Name);

            Intent intent = new Intent(DevicePolicyManager.ActionAddDeviceAdmin);
            intent.PutExtra(DevicePolicyManager.ExtraDeviceAdmin,compName);
            intent.PutExtra(DevicePolicyManager.ExtraAddExplanation,"Additional text explaining why this needs to be added.");
            StartActivityForResult(intent, 1);

            devicePolicyManager.SetKeyguardDisabled(compName, true);

            //bool active = devicePolicyManager.IsAdminActive(compName);
            //if (active) {
            //    // if available then lock
            //    devicePolicyManager.RemoveActiveAdmin(compName);
            //}

            //KeyguardManager km = (KeyguardManager)GetSystemService(KeyguardService);
            //KeyguardLock kl = km.NewKeyguardLock(PackageName);
            //kl.DisableKeyguard();   // WORKS ONLY IN SERVICE ?

            //PowerManager pm = (PowerManager)GetSystemService(PowerService);
            //WakeLock wakeLock = pm.NewWakeLock(WakeLockFlags.Full
            //                                   | WakeLockFlags.AcquireCausesWakeup
            //                                   | WakeLockFlags.OnAfterRelease, "MyWakeLock");
            //wakeLock.Acquire();

            var time = DateTime.Now.ToShortTimeString();

            var textView = new TextView(this)
            {
                Text = time,
                LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent)
            };

            var webView = new WebView(this);
            webView.SetWebViewClient(new WebViewClient());
            webView.Settings.JavaScriptEnabled = true;
            webView.LoadUrl("http://youtube.com");

            //SetContentView(textView);
            SetContentView(webView);

        }

        public override void OnAttachedToWindow()
        {
            Window.AddFlags(WindowManagerFlags.ShowWhenLocked |
                            WindowManagerFlags.KeepScreenOn |
                            WindowManagerFlags.DismissKeyguard |
                            WindowManagerFlags.TurnScreenOn);
        }
    }
}
