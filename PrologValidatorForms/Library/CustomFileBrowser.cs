using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace PrologValidatorForms.Library
{
    partial class Eksplorator : UserControl
    {
        List<string> backwardPaths = new List<string>();
        List<string> forwardPaths = new List<string>();
        string presentPath;
        PathsManager pm = new PathsManager();

        public string PresentPath
        {
            get { return presentPath; }
        }

        public Eksplorator()
        {
            InitializeComponent();
            RefreshList(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
        }

        private void RefreshList(string path)
        {
            DisableNavButtons();

            textBox.Text = path;
            listView.Items.Clear();
            presentPath = path;
            pm.Clear();

            try
            {
                foreach (string item in Directory.GetDirectories(path))
                {
                    pm.Add(item, PathListTypes.Directory);

                    DirectoryInfo fi = new DirectoryInfo(item);
                    ListViewItem listItem = new ListViewItem(fi.Name.Split('.')[0], 0);
                    listItem.SubItems.Add(fi.CreationTime.ToString());
                    listItem.SubItems.Add("folder");
                    listItem.SubItems.Add("-");
                    listView.Items.Add(listItem);
                }

                foreach (string item in Directory.GetFiles(path))
                {
                    pm.Add(item, PathListTypes.File);

                    imageList.Images.Add(System.Drawing.Icon.ExtractAssociatedIcon(item));
                    FileInfo fi = new FileInfo(item);
                    ListViewItem listItem = new ListViewItem(fi.Name.Split('.')[0], imageList.Images.Count - 1);
                    listItem.SubItems.Add(fi.CreationTime.ToString());
                    listItem.SubItems.Add(fi.Extension.ToString());
                    string convertedNumber = Library.SizeConverter.ConvertSize(fi.Length);
                    listItem.SubItems.Add(convertedNumber);
                    listView.Items.Add(listItem);
                }
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show($"Ścieżka: {path} nie istnieje!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);

                string prevPath = backwardPaths[backwardPaths.Count - 1];
                backwardPaths.RemoveAt(backwardPaths.Count - 1);
                RefreshList(prevPath);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Błąd: {e.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);

                string prevPath = backwardPaths[backwardPaths.Count - 1];
                backwardPaths.RemoveAt(backwardPaths.Count - 1);
                RefreshList(prevPath);
            }


            for (int i = 0; i < listView.Columns.Count - 1; i++)
            {
                listView.Columns[i].Width = -1;
            }
            listView.Columns[3].Width = -2;

        }

        private void DisableNavButtons()
        {
            if(backwardPaths.Count == 0)
            {
                btnBackward.Enabled = false;
            }
            else
            {
                btnBackward.Enabled = true;
            }
            if (forwardPaths.Count == 0)
            {
                btnForward.Enabled = false;
            }
            else
            {
                btnForward.Enabled = true;
            }
        }

        private void ManualSearching()
        {
            if(presentPath != textBox.Text)
            {
                backwardPaths.Add(presentPath);
                forwardPaths.Clear();
                RefreshList(textBox.Text);
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            ManualSearching();
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ManualSearching();
            }
        }
        private void listView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (listView.FocusedItem != null)
                {
                    forwardPaths.Clear();
                    int index = listView.FocusedItem.Index;

                    if (pm.GetPathType(index) == PathListTypes.Directory)
                    {
                        backwardPaths.Add(presentPath);
                        RefreshList(pm.GetPath(index));
                    }
                    else if (pm.GetPathType(index) == PathListTypes.File)
                    {
                        Process.Start(pm.GetPath(index));
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBackward_Click(object sender, EventArgs e)
        {
            if (backwardPaths.Count != 0)
            {
                string path = backwardPaths[backwardPaths.Count - 1];
                backwardPaths.RemoveAt(backwardPaths.Count - 1);
                forwardPaths.Add(presentPath);
                RefreshList(path);
            }
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if (forwardPaths.Count != 0)
            {
                string path = forwardPaths[forwardPaths.Count - 1];
                forwardPaths.RemoveAt(forwardPaths.Count - 1);
                backwardPaths.Add(presentPath);
                RefreshList(path);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
