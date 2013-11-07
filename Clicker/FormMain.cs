using System;
using System.Threading;
using System.Windows.Forms;
using Clicker.com.arazect.clicker;

namespace Clicker
{
    public partial class FormMain : Form
    {
        private int _clicksLeft = 0;

        public FormMain()
        {
            InitializeComponent();

            ThreadPool.QueueUserWorkItem(MouseCoordinates);
            ThreadPool.QueueUserWorkItem(CheckWindowStateAndStopTimer);
        }

        #region Parallel Threads

        private delegate void LabelTextChangeDelegate();

        private LabelTextChangeDelegate _changeLabelText;

        private void MouseCoordinates(object state)
        {
            for (;;)
            {
                _changeLabelText =
                    () => lCursorPosition.Text =
                        String.Format(
                            "Current mouse position x:{0} y:{1}",
                            Cursor.Position.X,
                            Cursor.Position.Y);
                lCursorPosition.Invoke(_changeLabelText);
            }
        }

        private void CheckWindowStateAndStopTimer(object state)
        {
            for (;;)
            {
                if (WindowState == FormWindowState.Minimized)
                {
                    timer.Enabled = false;
                }
            }
        }

        #endregion

        #region UI
        private void nudRepeatInterval_ValueChanged(object sender, EventArgs e)
        {
            timer.Interval = (int) nudRepeatInterval.Value;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _clicksLeft = (int) nudRepeatTimes.Value;
            timer.Enabled = true;
        }
        #endregion

        private void timer_Tick(object sender, EventArgs e)
        {
            _clicksLeft -= 1;

            if (_clicksLeft <= 0)
            {
                timer.Enabled = false;
            }
            ClickImitation.PerformClick((int) nudX.Value, (int) nudY.Value);
            lCliksPerformed.Text =
                String.Format("Performed: {0}/{1}",
                    nudRepeatTimes.Value - _clicksLeft,
                    nudRepeatTimes.Value);
        }
    }
}