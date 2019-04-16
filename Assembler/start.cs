using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assembler
{
    public partial class start : Form
    {
        public start()
        {
            InitializeComponent();
        }

        private void next_Click(object sender, EventArgs e)
        {
            if (file.Checked == true && written.Checked == true)
                MessageBox.Show("Please Select Only One Option.");
            else if(file.Checked == true && written.Checked == false)
            {
                Form1 f = new Form1();
                f.Show();
                this.Hide();
            }
            else if (file.Checked == false && written.Checked == true)
            {
                Form2 f = new Form2();
                f.Show();
                this.Hide();
            }
        }

        private void file_CheckedChanged(object sender, EventArgs e)
        {
            if (file.Checked == true)
                written.Checked = false;
        }

        private void written_CheckedChanged(object sender, EventArgs e)
        {
            if (written.Checked == true)
                file.Checked = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void start_Load(object sender, EventArgs e)
        {
        }
    }
}
