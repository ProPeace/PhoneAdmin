using Xamarin.Forms;

namespace Alarm
{
    public partial class AlarmPage : ContentPage
    {
        public AlarmPage()
        {
            InitializeComponent();

            DependencyService.Get<IAlarmListener>().startListening(3);

            //MessagingCenter.Subscribe<object, string>(this, "UpdateLabel", (s, e) =>
            //{
            //    Device.BeginInvokeOnMainThread(() =>
            //    {
            //        BackgroundServiceLabel.Text = e;
            //    });
            //});
        }
    }
}
