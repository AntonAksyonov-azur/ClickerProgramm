using System;
using System.Windows.Forms;
using Clicker.com.arazect.clicker.data;

namespace Clicker.com.arazect.clicker.forms
{
    public partial class AddEditForm : Form
    {
        public AddEditForm(ClickPoint item, bool isEditMode = false)
        {
            InitializeComponent();

            ApplyConfig();

            if (isEditMode)
            {
                tbName.Text = item.Name;
            }
            else
            {
                tbName.Text = String.Format(
                    "Point {0}-{1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString());
            }
            nudX.Value = item.X;
            nudY.Value = item.Y;
        }

        public new String Name;
        public int X;
        public int Y;

        private void ApplyConfig()
        {
            nudX.Maximum = FormMain.ThisProgrammConfig.NudControlsLimit.X;
            nudY.Maximum = FormMain.ThisProgrammConfig.NudControlsLimit.Y;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (tbName.TextLength > 0)
            {
                Name = tbName.Text;
                X = (int) nudX.Value;
                Y = (int) nudY.Value;

                Close();
            }
            else
            {
                MessageBox.Show(
                    "Empty names is not allowed!",
                    "Error in name field",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void tbName_MouseClick(object sender, MouseEventArgs e)
        {
            tbName.Select(0, tbName.TextLength);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}