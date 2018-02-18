using CorradLogFileHelper.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CorradLogFileHelper
{
    public partial class Form1 : Form
    {
        NetworkCredential oNetworkCredential = new NetworkCredential()
        {
            Domain = "192.168.12.120",
            UserName = "MDECDOMAIN" + "\\" + "appadmin",
            Password = "Mdec@cyber1215"
        };
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            try
            {
                //DownloadFile("192.168.12.120", "appadmin", "Mdec@cyber1215", @"D:\iislogs\", "", @"C:\Users\nakirareizo");
                using (new RemoteAccessHelper.NetworkConnection(@"\\" + "192.168.12.120", oNetworkCredential))
                {
                    string CorradLogFolder = @"\\192.168.12.120\D$\iislogs\";
                    string temppath = @"C:\Users\nakirareizo\CorradLogFile";
                    bool overwrite = false;
                    String[] sFolderNames = Directory.GetDirectories(CorradLogFolder);
                    foreach (String sFolderName in sFolderNames)
                    {
                        string LatestFile = getLatestLogFile(sFolderName);
                        FileInfo file = new FileInfo(sFolderName + LatestFile);
                        string LogPath = "";
                        recursivelyCopyContents(sFolderName + "\\" + LatestFile, overwrite, temppath, out LogPath);
                        if (LogPath != "")
                            ReadLogFile(LogPath);
                        //string[] sarrZipFiles = Directory.GetFiles(sFolderName, "*.log");
                        //foreach (String sFile in sarrZipFiles)
                        //{
                        //    FileInfo TheFile = new FileInfo(sFile);
                        //}
                        //if (CopyFiles(false, "192.168.12.120", sFolderName, @"C:\Users\nakirareizo\CorradLogFile"))
                        //    ReadLogFile(sFolderName, LatestFile);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void ReadLogFile(string LogFile)
        {
            ArrayList LogLine = new ArrayList();
            using (System.IO.StreamReader sr = new System.IO.StreamReader(LogFile))
            {
                String line;
                while ((line = sr.ReadLine()) != null)
                {

                    LogLine.Add(line);

                }
            }
            DataTable dtLog = new DataTable();
            dtLog.Columns.Add("IP");
            dtLog.Columns.Add("DateCalled");
            dtLog.Columns.Add("TimeCalled");
            dtLog.Columns.Add("APIParam");
            foreach (string item in LogLine)
            {
                //0: Requestor IP
                //2: Date Called
                //3: Time Called
                //14: API Name &Parameter
                string[] strLine = item.Split(',');
                DataRow dr = dtLog.NewRow();

                dr[0] = strLine[0].ToString();
                dr[1] = strLine[2].ToString();
                dr[2] = strLine[3].ToString();
                dr[3] = strLine[14].ToString();
                dtLog.Rows.Add(dr);

            }
            BindToGridView(dtLog);
        }

        private void BindToGridView(DataTable dtLog)
        {
            dgLogFile.DataSource = dtLog;
        }

        private string getLatestLogFile(string directory)
        {
            string latestfile = "";
            DirectoryInfo Direc = new DirectoryInfo(directory);

            FileInfo[] FoldersArr = Direc.GetFiles();

            if (FoldersArr.Length > 0)
            {
                DateTime MostRecent = FoldersArr[1].LastWriteTime;
                FileInfo RecentFolder;

                foreach (FileInfo f in FoldersArr)
                {
                    if (MostRecent.CompareTo(f.LastWriteTime) < 0)
                    {
                        MostRecent = f.LastWriteTime;
                        RecentFolder = f;
                        latestfile = RecentFolder.ToString();
                    }
                }


            }
            return latestfile;

        }

        private void recursivelyCopyContents(string sourceLogFile, bool overwrite, string destDirName, out string LogPath)
        {
            LogPath = "";
            try
            {
                FileInfo file = new FileInfo(sourceLogFile);
                string temppath = Path.Combine(destDirName, file.Name);

                string info = "Copying " + file.Name + " -> " + temppath;


                if (!overwrite && File.Exists(temppath))
                {
                    // Not overwriting - so show it already exists
                    LogPath = temppath;
                    MessageBox.Show(info + " (already exists)");
                }
                else
                {
                    file.CopyTo(temppath, overwrite);
                    LogPath = temppath;
                    //MessageBox.Show(info + " OK");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem encountered during copy : " + ex.Message);
            }
        }
    }
}
