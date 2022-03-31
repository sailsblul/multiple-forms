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
    public partial class FormMain : Form
    {
        public static List<string> names = new List<string>();
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormAddName frmAdd = new FormAddName();
            frmAdd.ShowDialog();
            lstNames.DataSource = null;
            lstNames.DataSource = names;
            if (names.Count != 0)
                btnEdit.Enabled = true;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            names.Add("Jeff");
            names.Add("Mark");
            names.Add("Cary");
            names.Sort();
            lstNames.DataSource = names;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            names.Remove((string)lstNames.SelectedItem);
            lstNames.DataSource = null;
            lstNames.DataSource = names;
            if (names.Count == 0)
                btnEdit.Enabled = false;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FormChangeName edit = new FormChangeName(lstNames.SelectedIndex);
            edit.ShowDialog();
            names.Sort();
            lstNames.DataSource = null;
            lstNames.DataSource = names;
        }
    }
}
