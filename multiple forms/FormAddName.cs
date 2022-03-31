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
    public partial class FormAddName : Form
    {
        public FormAddName()
        {
            InitializeComponent();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void FormAddName_Load(object sender, EventArgs e)
        {
            lstNames.DataSource = FormMain.names;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string newName = txtName.Text.Trim().ToLower();
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
                    FormMain.names.Add(newName);
                    FormMain.names.Sort();
                    lstNames.DataSource = null;
                    lstNames.DataSource = FormMain.names;
                }
            }
            txtName.Clear();
        }
    }
}
