using System;
using System.Windows.Threading;
using System.Windows;

namespace Utils
{
    public class WebServiceEndDetector
    {
        private DispatcherTimer _waitAnswerTimer;

        protected WebServiceEndDetector()
        {
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                _waitAnswerTimer = new DispatcherTimer();
                _waitAnswerTimer.Tick += waitEnd_Tick;
                _waitAnswerTimer.Interval = new TimeSpan(0, 0, 0, 0, 200);
            });
         }

        protected void StartTimer()
        {
            Deployment.Current.Dispatcher.BeginInvoke(() => _waitAnswerTimer.Start());
        }

        protected void StopTimer()
        {
            Deployment.Current.Dispatcher.BeginInvoke(() => _waitAnswerTimer.Stop());
        }

        //function called peridodicaly (and so the overridden function inherited)
        protected virtual void waitEnd_Tick(object sender, EventArgs e)
        {
           
        }
    }
}
