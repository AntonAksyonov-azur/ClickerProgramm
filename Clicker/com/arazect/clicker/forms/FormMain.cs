using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Clicker.com.arazect.clicker.data;

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
            timer.Interval = (int) nudTimertInterval.Value;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _clicksLeft = (int) nudRepeatCount.Value;
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
                    nudRepeatCount.Value - _clicksLeft,
                    nudRepeatCount.Value);
        }

        private void ApplyConfig()
        {
            Location = ThisProgrammConfig.WindowPoint;
            nudX.Maximum = ThisProgrammConfig.NudControlsLimit.X;
            nudY.Maximum = ThisProgrammConfig.NudControlsLimit.Y;

            nudTimertInterval.Value = ThisProgrammConfig.TimerInterval;
            nudRepeatCount.Value = ThisProgrammConfig.RepeatCount;
        }

        #region List and Data Binding

        private void RefreshListBoxDataBinding()
        {
            lbCoordinates.DataSource = null;
            lbCoordinates.DataSource = ThisProgrammConfig.ClickPoints;
            lbCoordinates.SelectedIndex = ThisProgrammConfig.ClickPoints.Count - 1;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var d = new AddEditForm(
                new ClickPoint {X = (int) nudX.Value, Y = (int) nudY.Value}))
            {
                if (d.ShowDialog() == DialogResult.OK)
                {
                    ThisProgrammConfig.ClickPoints.Add(
                        new ClickPoint
                        {
                            Name = d.Name,
                            X = d.X,
                            Y = d.Y
                        });

                    RefreshListBoxDataBinding();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lbCoordinates.SelectedIndex != -1)
            {
                var selectedItem = (ClickPoint) lbCoordinates.SelectedItem;
                using (var d = new AddEditForm(selectedItem, true))
                {
                    var id = ThisProgrammConfig.ClickPoints
                        .FindIndex(a => a == selectedItem);

                    if (d.ShowDialog() == DialogResult.OK)
                    {
                        ThisProgrammConfig.ClickPoints[id] =
                            new ClickPoint
                            {
                                Name = d.Name,
                                X = d.X,
                                Y = d.Y
                            };
                    }

                    RefreshListBoxDataBinding();
                    lbCoordinates.SelectedIndex = id;
                }
            }
            else
            {
                MessageBox.Show(
                    "You must select item in list first!",
                    "Error in selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lbCoordinates.SelectedIndex != -1)
            {
                ThisProgrammConfig.ClickPoints.Remove(
                    (ClickPoint) lbCoordinates.SelectedItem);
                RefreshListBoxDataBinding();
            }
            else
            {
                MessageBox.Show(
                    "You must select item in list first!",
                    "Error in selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void lbCoordinates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbCoordinates.SelectedIndex != -1)
            {
                var selectedItem = (ClickPoint) lbCoordinates.SelectedItem;
                nudX.Value = selectedItem.X;
                nudY.Value = selectedItem.Y;
            }
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
            ThisProgrammConfig.WindowPoint = Location;
            ThisProgrammConfig.TimerInterval = (int) nudTimertInterval.Value;
            ThisProgrammConfig.RepeatCount = (int) nudRepeatCount.Value;

            ConfigurationLoader.SaveConfiguration(ThisProgrammConfig, "config.xml");
        }
    }
}