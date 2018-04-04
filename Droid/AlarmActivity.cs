using System;
using Android.App;
using Android.App.Admin;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using static Android.OS.PowerManager;

namespace Alarm.Droid
{
    [Activity(Label = "AlarmActivity", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class AlarmActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Intent.AddFlags(Android.Content.ActivityFlags.ClearTop);
            //MessagingCenter.Send<object, string>(this, "UpdateLabel", time);

            DevicePolicyManager devicePolicyManager = (DevicePolicyManager)GetSystemService(DevicePolicyService);
            ActivityManager activityManager = (ActivityManager)GetSystemService(ActivityService);
            var compName = new ComponentName(this, Java.Lang.Class.FromType(typeof(DeviceAdminLock)).Name);

            Intent intent = new Intent(DevicePolicyManager.ActionAddDeviceAdmin);
            intent.PutExtra(DevicePolicyManager.ExtraDeviceAdmin,compName);
            intent.PutExtra(DevicePolicyManager.ExtraAddExplanation,"Additional text explaining why this needs to be added.");
            StartActivityForResult(intent, 1);

            bool active = devicePolicyManager.IsAdminActive(compName);
            if (active) {
                // if available then lock
                devicePolicyManager.RemoveActiveAdmin(compName);
            }

            KeyguardManager km = (KeyguardManager)GetSystemService(KeyguardService);
            KeyguardManager.KeyguardLock kl = km.NewKeyguardLock("MyKeyguardLock");
            kl.DisableKeyguard();

            PowerManager pm = (PowerManager)GetSystemService(PowerService);
            WakeLock wakeLock = pm.NewWakeLock(WakeLockFlags.Full
                                               | WakeLockFlags.AcquireCausesWakeup
                                               | WakeLockFlags.OnAfterRelease, "MyWakeLock");
            wakeLock.Acquire();

            var time = DateTime.Now.ToShortTimeString();

            var textView = new TextView(this)
            {
                Text = time,
                LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent)
            };

            SetContentView(textView);

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
