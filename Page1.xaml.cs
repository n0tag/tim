    using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App3
{
    [DesignTimeVisible(true)]
    public partial class Page1 : ContentPage
    {
        Stopwatch stopwatch;

        public Page1()
        {
            InitializeComponent();
            stopwatch = new Stopwatch();
            lblStopwatch.Text = "00:00:0000000";
        }

        private void bntStart_Clicked(object sender, EventArgs e)
        {
            if (!stopwatch.IsRunning)
            {
                stopwatch.Start();
                Device.StartTimer(TimeSpan.FromMilliseconds(2), () =>
                {
                    lblStopwatch.Text = stopwatch.Elapsed.ToString();
                    if (stopwatch.IsRunning)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                );
            }
        }
        private void bntStop_Clicked(object sender, EventArgs e)
        {
            if (stopwatch.IsRunning)
                bntStart.Text = "Resume";
            else
                bntStart.Text = "Start";
            stopwatch.Stop();
        }
        private void bntReset_Clicked(object sender, EventArgs e)
        {

            lblStopwatch.Text = "00:00:0000000";


            bntStart.Text = "Start";
            stopwatch.Reset();

        }

        private void Settings_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new Page2());
        }

    }
}
