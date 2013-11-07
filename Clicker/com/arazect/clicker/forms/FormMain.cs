using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Clicker.com.arazect.clicker.data;
using Clicker.com.arazect.data;

namespace Clicker.com.arazect.clicker.forms
{
    public partial class FormMain : Form
    {
        internal static ProgrammConfig ThisProgrammConfig;

        private int _clicksLeft = 0;
        private Point _prevCursorPosition;

        public FormMain()
        {
            InitializeComponent();
        }

        #region Parallel Threads

        private delegate void LabelTextChangeDelegate();

        private LabelTextChangeDelegate _changeLabelText;

        private void MouseCoordinates(object state)
        {
            for (;;)
            {
                if (_prevCursorPosition != Cursor.Position)
                {
                    _changeLabelText =
                        () => lCursorPosition.Text =
                            String.Format(
                                "Current mouse position x:{0} y:{1}",
                                Cursor.Position.X,
                                Cursor.Position.Y);
                    lCursorPosition.Invoke(_changeLabelText);
                }
                else
                {
                    _prevCursorPosition = Cursor.Position;
                }
                Thread.Sleep(25);
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

        private void ApplyConfig()
        {
            Location = ThisProgrammConfig.WindowPoint;
            nudX.Maximum = ThisProgrammConfig.NudControlsLimit.X;
            nudY.Maximum = ThisProgrammConfig.NudControlsLimit.Y;
        }

        #region List and Data Binding

        private void RefreshListBoxDataBinding()
        {
            lbCoordinates.DataSource = null;
            lbCoordinates.DataSource = ThisProgrammConfig.ClickPoints;
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var d = new AddEditForm(default(ClickPoint)))
            {
                if (d.ShowDialog() == DialogResult.OK)
                {
                   ThisProgrammConfig.ClickPoints.Add(new ClickPoint()
                   {
                       
                   });
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Form
        private void FormMain_Load(object sender, EventArgs e)
        {
            ThisProgrammConfig = ConfigurationLoader.LoadConfiguration<ProgrammConfig>("config.xml");
            ApplyConfig();
            RefreshListBoxDataBinding();

            ThreadPool.QueueUserWorkItem(MouseCoordinates);
            ThreadPool.QueueUserWorkItem(CheckWindowStateAndStopTimer);
        }

        #endregion

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            ThisProgrammConfig.WindowPoint = this.Location;

            ConfigurationLoader.SaveConfiguration(ThisProgrammConfig, "config.xml");
        }
    }
}