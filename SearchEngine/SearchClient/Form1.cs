using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;
namespace SearchClient
{
    public partial class Form1 : Form
    {
        TermManager term = new TermManager();
        private static string startFolder;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            //string name = txtSearch.Text;
            //term.Create(new TermDTO
            //{
            //    ID = 1,
            //    value = name,
            //});
           
           DoSearch();
        }
        private void DoSearch()
        {
            // Modify this path as necessary.
            
            try
            {
                // Take a snapshot of the file system.
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(startFolder);
                txtBoxResult.Items.Clear();
                // This method assumes that the application has discovery permissions
                // for all folders under the specified path.
                IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories);
                string searchTerm = @txtSearch.Text;

                // Search the contents of each file.
                // A regular expression created with the RegEx class
                // could be used instead of the Contains method.
                // queryMatchingFiles is an IEnumerable<string>.
                var queryMatchingFiles =
                    from file in fileList
                    where file.Extension == ".txt"
                    let fileText = GetFileText(file.FullName)
                    where fileText.Contains(searchTerm)
                    select file.FullName;
                int count = 1;
                // Execute the query.
                txtBoxResult.Text = "The term " + searchTerm + " was found in: ";
                foreach (string filename in queryMatchingFiles)
                {
                    lblCountFiles.Text = count.ToString();
                    Refresh();
                    txtBoxResult.Items.Add(filename);
                    //System.Threading.Thread.Yield();
                    count++;
                                                        }
                                             }
            catch (Exception ex)
            {
                txtBoxResult.Text = "You must first select a folder!";
            }
          


        }

        private string GetFileText(string name)
        {
            string fileContents = String.Empty;

            // If the file has been deleted since we took 
            // the snapshot, ignore it and return the empty string.
            if (System.IO.File.Exists(name))
            {
                fileContents = System.IO.File.ReadAllText(name);
            }
            return fileContents;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
           // fbd.Description = "Custom Description";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                startFolder = fbd.SelectedPath;
            }
        }

        
    }
}
