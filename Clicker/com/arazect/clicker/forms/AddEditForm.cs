using System;
using System.Windows.Forms;
using Clicker.com.arazect.clicker.data;

namespace Clicker.com.arazect.clicker.forms
{
    public partial class AddEditForm : Form
    {
        public AddEditForm(ClickPoint item)
        {
            InitializeComponent();

            ApplyConfig();

            if (item != default(ClickPoint))
            {
                tbName.Text = item.Name;
                nudX.Value = item.X;
                nudY.Value = item.Y;
            }
        }

        public new String Name;
        public int X;
        public int Y;

        private void ApplyConfig()
        {
            nudX.Maximum = FormMain.ThisProrammConfig.NudControlsLimit.X;
            nudY.Minimum = FormMain.ThisProrammConfig.NudControlsLimit.Y;
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