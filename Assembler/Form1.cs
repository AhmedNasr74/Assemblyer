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
using System.Text.RegularExpressions;
namespace Assembler
{
    public partial class Form1 : Form
    {
        string filePath;
        public Form1()
        {
            InitializeComponent();
        }
        private void btnbrose_Click(object sender, EventArgs e)
        {
            try
           {
                LoadData();
                if(filePath != null && filePath != "")
                {
                    ViewMIPSCode();
                    TranslateCode();
                    ViewBinaryCode();
                }
           } catch {
               Reset();
               mipsCode.Text = string.Empty;
               MessageBox.Show("There is syntax Error in Your File !!!!");
           }
        }
        private void TranslateCode()
        {
            MIPS.Translate();
        }
        private void Reset()
        {
            binary.Visible = true;
            mips.Visible = true;
            mipsCode.Focus();
            MIPS.Clear("*");
        }
        private void LoadData()
        {
            bool flag = false;
            BinaryCode.Text = string.Empty;
            mipsCode.Text = string.Empty;
            var FD = new System.Windows.Forms.OpenFileDialog();
            FD.Title = "Select Your MIPS File";
            FD.Filter = "TXT files|*.txt";
            FD.InitialDirectory = Path.GetFullPath(Environment.CurrentDirectory);
            if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                filePath = FD.FileName.ToString();
            if (filePath == null || filePath == "") return;
            FileHandler.Set(filePath, FileMode.Open);
            FileHandler.Reader.ReadLine();//skiping .data line
            while (FileHandler.Reader.Peek() != -1)
            {
                string line = FileHandler.Reader.ReadLine();
                if ( string.IsNullOrEmpty(line))
                    continue;
                if (line.Replace("\t", string.Empty).ToCharArray()[0] == '#')
                    continue;
                if (MIPS.FilterStringFromWhiteSpaces(line.ToLower()) == ".text" && !flag)
                {
                    flag = true;
                    line = FileHandler.Reader.ReadLine();
                }
                if (!flag)//Readind .date
                    MIPS.Code[".data"].Add(line);
                else if (flag)//Readint .text
                    MIPS.Code[".text"].Add(line);
            }
            FileHandler.CloseReader();
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
                if (i != MIPS.Code[".dataTranslation"].Count - 1)
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
        private void Form1_Load(object sender, EventArgs e)
        {
            MIPS.Initialize();
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
                        FileHandler.Writter.WriteLine("MEMORY("+i+") := " + MIPS.Code[".dataTranslation"][i] +c+ " ;");
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
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}