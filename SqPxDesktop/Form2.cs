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
namespace SqPxDesktop
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        RichTextBox rtb = new RichTextBox();
        
        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private RichTextBox GetRichTextBox()
        {
            RichTextBox rtb = null;
            TabPage tp = tabControl1.SelectedTab;
            if (tp != null)
            {
                rtb = tp.Controls[0] as RichTextBox;
            }
            return rtb;
        }

        private void takeAnotherNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage tp = new TabPage("Untitled Note");
            RichTextBox rtb = new RichTextBox();
            rtb.BorderStyle = BorderStyle.None;
            
            rtb.Dock = DockStyle.Fill; 
            tp.Controls.Add(rtb); 
            tabControl1.TabPages.Add(tp);
            rtb.Focus();
        }

     

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Cut();
        }

        private void openAnExistingNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    string filename = openFileDialog1.FileName;//copies the path of the file into a variable
                    string readfiletext = File.ReadAllText(filename);//reads all the text from the opened file
                    TabPage tp = new TabPage(filename); //creates a new tab page
                    RichTextBox rtb = new RichTextBox(); //creates a new richtext box object
                    rtb.Dock = DockStyle.Fill; //docks rich text box 
                    rtb.BorderStyle = BorderStyle.None;
                    tp.Controls.Add(rtb); // adds rich text box to the tab page
                    tabControl1.TabPages.Add(tp); //adds the tab pages to tab control
                    rtb.Focus();
                    rtb.Text = readfiletext;
                }
            }
        }

        private void saveMyNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "*.txt(Text file)|*.txt";
            
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                rtb.SaveFile(savefile.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRichTextBox().SelectAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            TabPage tp = new TabPage("Untitled Note");
            RichTextBox rtb = new RichTextBox();
            rtb.BorderStyle = BorderStyle.None;

            rtb.Dock = DockStyle.Fill;
            tp.Controls.Add(rtb);
            tabControl1.TabPages.Add(tp);
            rtb.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            Stream myStream;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    string filename = openFileDialog1.FileName;//copies the path of the file into a variable
                    string readfiletext = File.ReadAllText(filename);//reads all the text from the opened file
                    TabPage tp = new TabPage(openFileDialog1.SafeFileName); //creates a new tab page
                    RichTextBox rtb = new RichTextBox(); //creates a new richtext box object
                    rtb.Dock = DockStyle.Fill; //docks rich text box 
                    rtb.BorderStyle = BorderStyle.None;
                    tp.Controls.Add(rtb); // adds rich text box to the tab page
                    tabControl1.TabPages.Add(tp); //adds the tab pages to tab control
                    rtb.Focus();
                    rtb.Text = readfiletext;
                }
            }
        }
    }
}
