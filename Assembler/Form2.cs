using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Assembler
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            MIPS.Initialize();
        }
        private void LoadData()
        {
            string [] lines = mipsCode.Text.Split('\n');
            bool flag = false;
            for (int i = 1; i < lines.Length; i++ )
            {
                string line = lines[i];
                if (string.IsNullOrEmpty(line))
                    continue;
                if (line.Replace("\t", string.Empty).ToCharArray()[0] == '#')
                    continue;
                if (MIPS.FilterStringFromWhiteSpaces(line.ToLower()) == ".text" && !flag)
                {
                    flag = true;
                    i++;
                    line = lines[i];
                }
                if (!flag)//Readind .date
                    MIPS.Code[".data"].Add(line);
                else if (flag)//Readint .text
                    MIPS.Code[".text"].Add(line);

            }            
        }
        private void ViewMIPSCode()
        {
            string TEMP = ".date\n";
            for (int i = 0; i < MIPS.Code[".data"].Count; i++)
                TEMP += MIPS.Code[".data"][i] + "\n";
            TEMP += ".text\n";
            for (int i = 0; i < MIPS.Code[".text"].Count; i++)
            {
                if (i != MIPS.Code[".text"].Count - 1)
                    TEMP += MIPS.Code[".text"][i] + "\n";
                else
                    TEMP += MIPS.Code[".text"][i];
            }
            mipsCode.Text = TEMP;

        }
        private void ViewBinaryCode()
        {
            string TEMP = "Translation of Data Segment\n";
            for (int i = 0; i < MIPS.Code[".dataTranslation"].Count; i++)
            {
                    TEMP += MIPS.Code[".dataTranslation"][i] + "\n";
            }
            TEMP += "Translation of Text Segment\n";
            for (int i = 0; i < MIPS.Code[".textTranslation"].Count; i++)
            {
                if (i != MIPS.Code[".textTranslation"].Count - 1)
                    TEMP += MIPS.Code[".textTranslation"][i] + "\n";
                else
                    TEMP += MIPS.Code[".textTranslation"][i];
            }
            BinaryCode.Text = TEMP;
        }
        private void btnbrose_Click(object sender, EventArgs e)
        {
            if (mipsCode.Text != "" && mipsCode.Text != null && mipsCode.Text != "Write Code Here")
            {
                try
                {
                    LoadData();
                    TranslateCode();
                    ViewBinaryCode();
                }
                catch { MessageBox.Show("There is syntax Error in Your Code !!!!"); }
            }
            else 
                mipsCode.Text = "Write Code Here";
        }
        private void TranslateCode()
        {
            MIPS.Translate();
        }
        private void save_Click(object sender, EventArgs e)
        {
            char c = '"';
            try
            {

            if (MIPS.Code[".dataTranslation"].Count > 0 && MIPS.Code[".textTranslation"].Count > 0)
            {
                var FD = new System.Windows.Forms.FolderBrowserDialog();
                FD.Description = "Select Saving Folder";
                FD.ShowDialog();
                string SavingFolder = FD.SelectedPath + '/';
                FileHandler.Set(SavingFolder + "Data Segment Translation.txt", FileMode.Create);

                for (int i = 0; i < MIPS.Code[".dataTranslation"].Count; i++)
                    FileHandler.Writter.WriteLine("MEMORY(" + i + ") := " + MIPS.Code[".dataTranslation"][i] + c + " ;");
                FileHandler.CloseWritter();
                FileHandler.Set(SavingFolder + "Text Segment Translation.txt", FileMode.Create);
                for (int i = 0; i < MIPS.Code[".textTranslation"].Count; i++)
                    FileHandler.Writter.WriteLine("MEMORY(" + i + ") := " + MIPS.Code[".textTranslation"][i] + c + " ;");
                FileHandler.CloseWritter();
            }
            else
                MessageBox.Show("Ther is no MIPS Code was Translated Yet !!!", "No Data Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch { }

        }

        private void mipsCode_Click(object sender, EventArgs e)
        {
            if (mipsCode.Text == "Write Code Here")
                mipsCode.Text = string.Empty;
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void mipsCode_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            mipsCode.Focus();
            MIPS.Clear("*");
            mipsCode.Text = "Write Code Here";
            BinaryCode.Text = "";
        }
    }
}
