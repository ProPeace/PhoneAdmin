using Alarm.Droid;
using Android.App;
using Android.Content;
using Android.OS;

[assembly: Xamarin.Forms.Dependency(typeof(AlarmListener))]
namespace Alarm.Droid
{
    public class AlarmListener : IAlarmListener
    {
        public void startListening(int seconds)
        {
            var alarmIntent = new Intent(Application.Context, typeof(BackgroundReceiver));

            var pending = PendingIntent.GetBroadcast(Application.Context, 0, alarmIntent, PendingIntentFlags.UpdateCurrent);

            var alarmManager = (AlarmManager)Application.Context.GetSystemService(Context.AlarmService);
            alarmManager.Set(AlarmType.ElapsedRealtime, SystemClock.ElapsedRealtime() + seconds * 1000, pending);


            //var voiceService = new Intent(Application.Context, typeof(VoiceService));
            //Application.Context.StartService(voiceService);
        }
    }
}
