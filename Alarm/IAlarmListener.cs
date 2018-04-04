using System;
namespace Alarm
{
    public interface IAlarmListener
    {
        void startListening(int seconds);
    }
}
