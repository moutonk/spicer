using System;
using System.Windows.Threading;
using System.Windows;

namespace Utils
{
    public class WebServiceEndDetector
    {
        protected DispatcherTimer WaitAnswerTimer;
        protected Func<bool> ChangeView;
        protected RequestType CurrentRequestType;

        protected WebServiceEndDetector()
        {
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                WaitAnswerTimer = new DispatcherTimer();
                WaitAnswerTimer.Tick += waitEnd_Tick;
                WaitAnswerTimer.Interval = new TimeSpan(0, 0, 0, 0, 200);
            });

            ChangeView = null;
         }

        protected void StartTimer()
        {
            Deployment.Current.Dispatcher.BeginInvoke(() => WaitAnswerTimer.Start());
        }

        protected void StopTimer()
        {
            Deployment.Current.Dispatcher.BeginInvoke(() => WaitAnswerTimer.Stop());
        }

        //function called peridodicaly (and so the overridden function inherited)
        protected virtual void waitEnd_Tick(object sender, EventArgs e)
        {
           
        }
    }
}
