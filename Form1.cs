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
namespace Nodepad
{
    public partial class Form1 : Form
    {
       

        public Form1()
        {
            InitializeComponent();
        }
        Boolean status;

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (status)
            {
                DialogResult dr = MessageBox.Show("Dosyayı kaydetmek ister misiniz?","Kaydet", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    SaveFile(sender, e);
                    richTextBox1.Clear();
                    this.Text = "Untitled";
                    status = false;
                    undoToolStripMenuItem1.Enabled = false;
                    redoToolStripMenuItem.Enabled = false;
                    richTextBox1.WordWrap = false;
                }
                else if (dr == DialogResult.No)
                {
                    richTextBox1.Clear();
                    this.Text = "Untitled";
                }
                else
                {
                    return;
                }
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            undoToolStripMenuItem1.Enabled = true;
            redoToolStripMenuItem.Enabled = true;
            status = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            status = false;
            undoToolStripMenuItem1.Enabled = false;
            redoToolStripMenuItem.Enabled = false;
            richTextBox1.WordWrap = false;
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (status)
            {
                DialogResult dr = MessageBox.Show("Kaydetmek ister misiniz?","Kayıt", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    SaveFile(sender, e);
                }
                status = false;
                undoToolStripMenuItem1.Enabled = false;
                redoToolStripMenuItem.Enabled = false;
                richTextBox1.WordWrap = false;
            }
            this.Close();
            Application.Exit();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanRedo)
            {
                richTextBox1.Redo();
            }
        }

        private void undoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanUndo)
            {
                richTextBox1.Undo();
            }
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFile(sender, e);
        }

        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void selectAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.WordWrap = true;
        }

        protected void SaveFile(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Save file";
            saveFileDialog1.FileName = "Text Document";
            saveFileDialog1.Filter = "TEXT|*.txt|DOC|*.doc|DOCX|*.docx|RICH TEXT FILE|*.rtf|ALL FILES|*.*";
            saveFileDialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (this.Text != "Untitled")
                {
                    richTextBox1.SaveFile(this.Text, RichTextBoxStreamType.PlainText);
                    this.Text = saveFileDialog1.FileName;
                }
                else if (this.Text == "Untitled")
                {
                    saveFileDialog1.Title = "Save";
                    saveFileDialog1.Filter = "Text Document|*.txt";
                    saveFileDialog1.DefaultExt = "txt";
                    saveFileDialog1.ShowDialog();
                    richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                    this.Text = saveFileDialog1.FileName;
                }
            }
        }

        private void saveAsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Save As";
            saveFileDialog1.Filter = "Text Document|*.txt";
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.ShowDialog();
            richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            this.Text = saveFileDialog1.FileName;
        }



       
        protected void OpenFile(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Open File";
            openFileDialog1.Filter = " TEXT|*.txt|DOC|*.doc|DOCX|*.docx|RICH TEXT FILE|*.rtf|ALL FILES|*.*";
            openFileDialog1.FileName = string.Empty;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName == string.Empty)
                {
                    return;
                }
                else 
                {
                    string str;
                    str = openFileDialog1.FileName;
                    richTextBox1.LoadFile(str, RichTextBoxStreamType.PlainText);
                    this.Text = openFileDialog1.FileName;

                }
            }
        }

   

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = fontDialog1.ShowDialog();
            if (dr == DialogResult.OK)
                richTextBox1.Font = fontDialog1.Font;
            

        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = colorDialog1.ShowDialog();
            if (dr == DialogResult.OK)
                richTextBox1.ForeColor = colorDialog1.Color;
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFile(sender, e);
        }

      
    }
}


      