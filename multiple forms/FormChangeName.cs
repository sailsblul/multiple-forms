using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multiple_forms
{
    public partial class FormChangeName : Form
    {
        int index;
        public FormChangeName(int index)
        {
            InitializeComponent();
            this.index = index;
            lblAsk.Text = $"New name (replacing '{FormMain.names[index]}'):";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            string newName = txtNewName.Text.Trim().ToLower();
            if (newName.Length > 0)
            {
                newName = char.ToUpper(newName[0]) + newName.Substring(1);
                if (FormMain.names.Contains(newName))
                {
                    FormAlready popup = new FormAlready();
                    popup.ShowDialog();
                }
                else
                {
                    FormMain.names[index] = newName;
                    Dispose();
                }
            }
        }
    }
}
