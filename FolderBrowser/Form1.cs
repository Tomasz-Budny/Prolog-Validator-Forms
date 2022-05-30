using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderBrowser{
    
    public partial class Form1 : Form
    {
        FolderBrowserDialog fdb_source;
        FolderBrowserDialog fdb_export;
        public Form1()
        {
            InitializeComponent();
            fdb_source = new FolderBrowserDialog() { Description = "Select your directory, containing the files for check" };
            fdb_export = new FolderBrowserDialog() { Description = "Select your directory, where the results will be exported" };
        }        
        private void button_explore_source_code_Click(object sender, EventArgs e)
        {            
            if (fdb_source.ShowDialog() == DialogResult.OK)
            {
                webBrowser1.Url = new Uri(fdb_source.SelectedPath);
                text_Path_soruce_code.Text = fdb_source.SelectedPath;
            }
            
        }

        private void button_explore_export_code_Click(object sender, EventArgs e)
        {            
            
            if (fdb_export.ShowDialog() == DialogResult.OK)
            {
               webBrowser2.Url = new Uri(fdb_export.SelectedPath);
               text_Path_export_location.Text = fdb_export.SelectedPath;
            }
            
        }

        private void button_do_tyłu_export_code_Click(object sender, EventArgs e)
        {            
                if (webBrowser2.CanGoBack)
                {
                    webBrowser2.GoBack();
                    text_Path_export_location.Text = fdb_export.SelectedPath;
                }
        }

        private void button_do_przodu_export_code_Click(object sender, EventArgs e)
        {
            
                if (webBrowser2.CanGoForward)
                {
                    webBrowser2.GoForward();
                    text_Path_export_location.Text = fdb_export.SelectedPath;
                }
        }

        private void button_do_tyłu_source_code_Click(object sender, EventArgs e)
        {
            
        }

        private void button_do_przodu_source_code_Click(object sender, EventArgs e)
        {
            
        }
    }
}
