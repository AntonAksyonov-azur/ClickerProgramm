using System;
using System.Threading;
using System.Windows.Forms;

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

        private delegate void LabelTextChangeDelegate();

        private delegate void TimerWindowStateCheckDelegate();

        private LabelTextChangeDelegate _changeLabelText;

        private void MouseCoordinates(object state)
        {
            for (;;)
            {
                _changeLabelText =
                    () => lCursorPosition.Text =
                        String.Format("Current mouse position x:{0} y:{1}", Cursor.Position.X, Cursor.Position.Y);
                lCursorPosition.Invoke(_changeLabelText);
            }
        }

        private void CheckWindowStateAndStopTimer(object state)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                timer.Enabled = false;
            }
        }


        private void nudRepeatInterval_ValueChanged(object sender, EventArgs e)
        {
            timer.Interval = (int) nudRepeatInterval.Value;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _clicksLeft = (int) nudRepeatTimes.Value;
            timer.Enabled = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            _clicksLeft -= 1;

            if (_clicksLeft <= 0)
            {
                timer.Enabled = false;
            }
            PerformClick();
            lCliksPerformed.Text =
                String.Format("Performed: {0}/{1}",
                    nudRepeatTimes.Value - _clicksLeft,
                    nudRepeatTimes.Value);
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetCursorPos(int x, int y);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        public const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        public const int MOUSEEVENTF_LEFTUP = 0x0004;

        private void PerformClick()
        {
            var x = (int) nudX.Value;
            var y = (int) nudY.Value;
            SetCursorPos(x, y);
            mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        }
    }
}