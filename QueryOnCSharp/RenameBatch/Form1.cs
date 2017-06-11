using RainyTool.ClassLib.FileHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RainyTool.WinForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            Text = "Batch Rename";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(
            Object i_sender, 
            EventArgs i_eventArguments
            )
        {
            if (folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbFolder.Text = folderBrowser.SelectedPath;
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void btnListFiles_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbFolder.Text))
            {
                var searchPattern = GetSearchPattern();

                var files = FileManager.GetAllFilesInDirectory(tbFolder.Text, searchPattern);

                foreach (var file in files)
                {
                    fileBox.Items.Add(file);

                    //var fileInfo = new FileInfo(file);
                    //fileBox.Items.Add("File name：" + fileInfo.Name);
                    //fileBox.Items.Add("File full name: " + fileInfo.FullName);
                    //fileBox.Items.Add("File directory:" + fileInfo.Directory);
                    //fileBox.Items.Add("" + fileInfo.t)

                    //break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var src = @"001+8+¬F¦¦¬--»-O{+-+·¦²-T¦+www.Ysts8.com}.mp3";

            var matchPattern = @"(\d{3}).+";

            var regex = new Regex(matchPattern);

            if (regex.IsMatch(src))
            {
                var result = regex.Replace(src, "$1.mp3");

                MessageBox.Show(result);
            }
        }

        private String GetSearchPattern()
        {
            const String FileExtensionPrepending = "*.";

            var result = "*";

            var fileExtension = tbFileExtension.Text;

            if (String.IsNullOrEmpty(fileExtension))
            {
                return result;
            }

            if (fileExtension.StartsWith("."))
            {
                if (fileExtension.Equals(".*"))
                {
                    return result;
                }
                else
                {
                    result = String.Concat(result, fileExtension);
                }
            }
            else
            {
                var dotIndex = fileExtension.IndexOf(".");

                if (dotIndex > 0)
                {
                    result = String.Concat(result, fileExtension.Substring(dotIndex));
                }
                else
                {
                    result = FileExtensionPrepending + fileExtension;
                }
            }

            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbFolder.Text))
            {
                var path = tbFolder.Text;

                var searchPattern = GetSearchPattern();

                var rawFiles = FileManager.GetAllFilesInDirectory(path, searchPattern);

                RenameFileArgument renameFileArugment = new RenameFileArgument();
                renameFileArugment.Files = rawFiles;
                renameFileArugment.MatchPattern = tbMatchPattern.Text;
                renameFileArugment.ReplacePattern = tbReplacePattern.Text;
                renameFileArugment.ContinueIfFailed = cbContinue.Checked;
;
                renameFileArugment.Action = ShowProgress;

                FileManager.RenameFileNameByBatch(renameFileArugment);
            }
        }

        private void ShowProgress(
            String i_sourceFileName,
            String i_targetFileName,
            Int32 i_currentIndex,
            Int32 i_totalFileNumber
            )
        {
            fileBox.Items.Add(String.Format("progress:{0}/{1}, file name:{2} -> {3}", i_currentIndex, i_totalFileNumber, i_sourceFileName, i_targetFileName));
        }

        private void fileBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbFolder_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
