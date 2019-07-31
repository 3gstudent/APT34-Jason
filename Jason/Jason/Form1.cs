using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Windows.Forms;
using Jason.Properties;
using Microsoft.Exchange.WebServices.Data;

namespace Jason
{
    // Token: 0x02000002 RID: 2
    public partial class Form1 : Form
    {
        // Token: 0x06000001 RID: 1 RVA: 0x00002060 File Offset: 0x00000260
        private void RefreshGrid()
        {
            for (;;)
            {
                this.grdResult.BeginInvoke(new Action(delegate ()
                {
                    this.grdResult.Refresh();
                }));
                Thread.Sleep(1000);
            }
        }

        // Token: 0x06000002 RID: 2 RVA: 0x00002490 File Offset: 0x00000690
        private void StartDownload(int threadCount)
        {
            this.ThreadItemList = new BindingList<ThreadItem>();
            for (int i = 0; i < threadCount; i++)
            {
                this.ThreadItemList.Add(new ThreadItem(i + 1));
            }
        }

        // Token: 0x06000003 RID: 3 RVA: 0x00002085 File Offset: 0x00000285
        public Form1()
        {
            this.InitializeComponent();
            this.Init();
        }

        // Token: 0x06000004 RID: 4 RVA: 0x000020A4 File Offset: 0x000002A4
        public void RefreshList()
        {
            this.grdResult.Refresh();
        }

        // Token: 0x06000005 RID: 5 RVA: 0x000024C8 File Offset: 0x000006C8
        private void Init()
        {
            this.grdResult.DataSource = this.ThreadItemList;
            //			ServicePointManager.ServerCertificateValidationCallback = ((object <p0>, X509Certificate <p1>, X509Chain <p2>, SslPolicyErrors <p3>) => true);
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => { return true; };

            this.cmbExchangeVersion.Items.Add(new KeyValuePair<string, ExchangeVersion>("Exchange2007", ExchangeVersion.Exchange2007_SP1));
            this.cmbExchangeVersion.Items.Add(new KeyValuePair<string, ExchangeVersion>(ExchangeVersion.Exchange2007_SP1.ToString().Replace("_", " "), ExchangeVersion.Exchange2007_SP1));
            this.cmbExchangeVersion.Items.Add(new KeyValuePair<string, ExchangeVersion>("Exchange2007 SP2", ExchangeVersion.Exchange2007_SP1));
            this.cmbExchangeVersion.Items.Add(new KeyValuePair<string, ExchangeVersion>("Exchange2007 SP3", ExchangeVersion.Exchange2007_SP1));
            this.cmbExchangeVersion.Items.Add(new KeyValuePair<string, ExchangeVersion>(ExchangeVersion.Exchange2010.ToString().Replace("_", " "), ExchangeVersion.Exchange2010));
            this.cmbExchangeVersion.Items.Add(new KeyValuePair<string, ExchangeVersion>(ExchangeVersion.Exchange2010_SP1.ToString().Replace("_", " "), ExchangeVersion.Exchange2010_SP1));
            this.cmbExchangeVersion.Items.Add(new KeyValuePair<string, ExchangeVersion>(ExchangeVersion.Exchange2010_SP2.ToString().Replace("_", " "), ExchangeVersion.Exchange2010_SP2));
            this.cmbExchangeVersion.Items.Add(new KeyValuePair<string, ExchangeVersion>("Exchange2010 SP3", ExchangeVersion.Exchange2010_SP2));
            this.cmbExchangeVersion.Items.Add(new KeyValuePair<string, ExchangeVersion>(ExchangeVersion.Exchange2013.ToString().Replace("_", " "), ExchangeVersion.Exchange2013));
            this.cmbExchangeVersion.Items.Add(new KeyValuePair<string, ExchangeVersion>(ExchangeVersion.Exchange2013_SP1.ToString().Replace("_", " "), ExchangeVersion.Exchange2013_SP1));
            this.cmbExchangeVersion.DisplayMember = "Key";
            this.cmbExchangeVersion.ValueMember = "Value";
            this.cmbExchangeVersion.SelectedIndex = 0;
            this.cmbMethod.SelectedIndex = 0;
            Settings @default = Settings.Default;
            this.txtExchangeAddress.Text = @default.Address;
            this.cmbExchangeVersion.SelectedValue = (string.IsNullOrEmpty(@default.Version) ? ExchangeVersion.Exchange2007_SP1 : Enum.Parse(typeof(ExchangeVersion), @default.Version));
            this.txtUserPassFile.Text = @default.UserPassFile;
            this.txtPassword.Text = @default.PasswordFile;
            this.txtThreadCount.Text = @default.ThreadCount;
            if (!string.IsNullOrEmpty(@default.Method))
            {
                this.cmbMethod.SelectedIndex = int.Parse(@default.Method);
            }
            this.txtUsernameStart.Text = @default.UsernameStart;
            this.txtUsernameEnd.Text = @default.UsernameEnd;
            this.CurrentPath = Path.GetDirectoryName(Application.ExecutablePath);
            this.CurrentPath = this.CurrentPath.TrimEnd(new char[]
            {
                '\\'
            }) + "\\";
        }

        // Token: 0x06000006 RID: 6 RVA: 0x0000281C File Offset: 0x00000A1C
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!this.IsStartDownload)
            {
                Uri exchangeUrl = null;
                int num = 0;
                ExchangeVersion value = ((KeyValuePair<string, ExchangeVersion>)this.cmbExchangeVersion.SelectedItem).Value;
                this.txtExchangeAddress.Text = this.txtExchangeAddress.Text.TrimEnd(new char[]
                {
                    '/'
                }) + "/";
                if (!Uri.TryCreate(this.txtExchangeAddress.Text, UriKind.Absolute, out exchangeUrl))
                {
                    MessageBox.Show("The entered Exchange Address is incorect");
                    return;
                }
                if (string.IsNullOrEmpty(this.txtUserPassFile.Text))
                {
                    MessageBox.Show("Please enter Username File");
                    return;
                }
                if (string.IsNullOrEmpty(this.txtPassword.Text))
                {
                    MessageBox.Show("Please enter Password File");
                    return;
                }
                if (string.IsNullOrEmpty(this.txtThreadCount.Text) || !int.TryParse(this.txtThreadCount.Text, out num))
                {
                    MessageBox.Show("Please enter number of threads correctly");
                    return;
                }
                this.IsStartDownload = true;
                Settings @default = Settings.Default;
                @default.Address = this.txtExchangeAddress.Text;
                @default.Version = value.ToString();
                @default.UserPassFile = this.txtUserPassFile.Text;
                @default.PasswordFile = this.txtPassword.Text;
                @default.ThreadCount = this.txtThreadCount.Text;
                @default.Method = this.cmbMethod.SelectedIndex.ToString();
                @default.UsernameStart = this.txtUsernameStart.Text;
                @default.UsernameEnd = this.txtUsernameEnd.Text;
                @default.Save();
                MainConfig.MainFormInstase = this;
                MainConfig.StreamPassword = new StreamReader(this.txtPassword.Text);
                string[] array = File.ReadAllLines(this.txtUserPassFile.Text);
                MainConfig.Usernames = new List<UserClass>();
                for (int i = 0; i < array.Count<string>(); i++)
                {
                    MainConfig.Usernames.Add(new UserClass(array[i]));
                }
                MainConfig.ExchangeUrl = exchangeUrl;
                MainConfig.ExchangeVersion = value;
                MainConfig.AppLocation = this.CurrentPath;
                MainConfig.ThreadCount = num;
//                MainConfig.Method = this.cmbMethod.SelectedText;
                MainConfig.Method = (string)this.cmbMethod.SelectedItem;

                MainConfig.UsernameStart = this.txtUsernameStart.Text;
                MainConfig.UsernameEnd = this.txtUsernameEnd.Text;
                this.StartTime = DateTime.Now;
                this.lblStatus.Text = num + " Threads Working";
                this.ThreadItemList = new BindingList<ThreadItem>();
                for (int j = 0; j < num; j++)
                {
                    this.ThreadItemList.Add(new ThreadItem(j + 1));
                }
                this.grdResult.DataSource = this.ThreadItemList;
                this.grdResult.Refresh();
                this.thrRefresher = new Thread(delegate ()
                {
                    this.RefreshGrid();
                });
                this.thrRefresher.Start();
                Thread.Sleep(1000);
                this.TimerMain.Enabled = true;
            }
        }

        // Token: 0x06000007 RID: 7 RVA: 0x00002B14 File Offset: 0x00000D14
        private void TimerMain_Tick(object sender, EventArgs e)
        {
            TimeSpan timeSpan = DateTime.Now - this.StartTime;
            this.lblTimer.Text = string.Format("{0:D2}:{1:D2}:{2:D2}.{3:D3}", new object[]
            {
                (int)timeSpan.TotalHours,
                timeSpan.Minutes,
                timeSpan.Seconds,
                timeSpan.Milliseconds
            });
            this.lblSuccess.Text = this.ThreadItemList.Sum((ThreadItem a) => a.pTotalSuccess).ToString();
            long num = this.ThreadItemList.Sum((ThreadItem a) => a.pTotalCheck);
            this.lblChecked.Text = num.ToString();
            long num2 = 0L;
            if (num > 0L)
            {
                num2 = (long)(timeSpan.TotalMilliseconds / (double)num);
            }
            this.lblEmailTime.Text = num2.ToString() + " ms";
            this.lblEmailTimeThread.Text = ((int)(num2 * (long)MainConfig.ThreadCount / 1000L)).ToString() + " s";
            this.lblTotalUsers.Text = MainConfig.Usernames.Count((UserClass a) => !a.IsDone).ToString();
            int num3 = (from a in this.ThreadItemList
                        where a.IsDone
                        select a).Count<ThreadItem>();
            if (num3 == this.ThreadItemList.Count<ThreadItem>())
            {
                this.lblStatus.Text = "Complete";
                for (int i = 0; i < MainConfig.ThreadCount; i++)
                {
                    string path = string.Concat(new object[]
                    {
                        MainConfig.AppLocation,
                        "out",
                        i + 1,
                        ".txt"
                    });
                    if (File.Exists(path))
                    {
                        File.AppendAllText(MainConfig.AppLocation + "out-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".txt", File.ReadAllText(path));
                        File.Delete(path);
                    }
                }
                this.TimerMain.Enabled = false;
                return;
            }
            this.lblStatus.Text = this.ThreadItemList.Count - num3 + " Threads Working";
        }

        // Token: 0x06000008 RID: 8 RVA: 0x00002DC4 File Offset: 0x00000FC4
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.txtUserPassFile.Text = openFileDialog.FileName;
            }
        }

        // Token: 0x06000009 RID: 9 RVA: 0x000020B1 File Offset: 0x000002B1
        public void GetError(Exception ex)
        {
            this.MainStatus = ex.Message;
            File.AppendAllText("log.txt", ex.ToString() + Environment.NewLine);
        }

        // Token: 0x0600000A RID: 10 RVA: 0x00002DF4 File Offset: 0x00000FF4
        private void btnPasswordOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.txtPassword.Text = openFileDialog.FileName;
            }
        }

        // Token: 0x0600000B RID: 11 RVA: 0x00002E24 File Offset: 0x00001024
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.thrRefresher != null && this.thrRefresher.IsAlive)
            {
                this.thrRefresher.Abort();
                this.thrRefresher = null;
            }
            if (this.MainThread != null && this.MainThread.IsAlive)
            {
                this.MainThread.Abort();
                this.MainThread = null;
            }
            if (this.ThreadItemList != null)
            {
                foreach (ThreadItem threadItem in this.ThreadItemList)
                {
                    if (threadItem.pThread != null && threadItem.pThread.IsAlive)
                    {
                        threadItem.pThread.Abort();
                        threadItem.pThread = null;
                    }
                }
            }
        }

        // Token: 0x0600000C RID: 12 RVA: 0x000020D9 File Offset: 0x000002D9
        private void btnGetOAB_Click(object sender, EventArgs e)
        {
        }

        // Token: 0x0600000D RID: 13 RVA: 0x000020DB File Offset: 0x000002DB
        internal static bool adAutoDiscoCallBack(string url)
        {
            return true;
        }

        // Token: 0x0600000E RID: 14 RVA: 0x00002EE8 File Offset: 0x000010E8
        private void btnGeneratePass_Click(object sender, EventArgs e)
        {
            Uri exchangeUrl = null;
            int num = 0;
            ExchangeVersion value = ((KeyValuePair<string, ExchangeVersion>)this.cmbExchangeVersion.SelectedItem).Value;
            this.txtExchangeAddress.Text = this.txtExchangeAddress.Text.TrimEnd(new char[]
            {
                '/'
            }) + "/";
            if (!Uri.TryCreate(this.txtExchangeAddress.Text, UriKind.Absolute, out exchangeUrl))
            {
                MessageBox.Show("The entered Exchange Address is incorect");
                return;
            }
            if (string.IsNullOrEmpty(this.txtUserPassFile.Text))
            {
                MessageBox.Show("Please enter Username File");
                return;
            }
            if (string.IsNullOrEmpty(this.txtPassword.Text))
            {
                MessageBox.Show("Please enter Password File");
                return;
            }
            if (!string.IsNullOrEmpty(this.txtThreadCount.Text) && int.TryParse(this.txtThreadCount.Text, out num))
            {
                this.IsStartDownload = true;
                Settings @default = Settings.Default;
                @default.Address = this.txtExchangeAddress.Text;
                @default.Version = value.ToString();
                @default.UserPassFile = this.txtUserPassFile.Text;
                @default.PasswordFile = this.txtPassword.Text;
                @default.ThreadCount = this.txtThreadCount.Text;
                @default.Method = this.cmbMethod.SelectedIndex.ToString();
                @default.UsernameStart = this.txtUsernameStart.Text;
                @default.UsernameEnd = this.txtUsernameEnd.Text;
                @default.Save();
                MainConfig.MainFormInstase = this;
                MainConfig.StreamPassword = new StreamReader(this.txtPassword.Text);
                string[] array = File.ReadAllLines(this.txtUserPassFile.Text);
                MainConfig.Usernames = new List<UserClass>();
                for (int i = 0; i < array.Count<string>(); i++)
                {
                    MainConfig.Usernames.Add(new UserClass(array[i]));
                }
                MainConfig.ExchangeUrl = exchangeUrl;
                MainConfig.ExchangeVersion = value;
                MainConfig.AppLocation = this.CurrentPath;
                MainConfig.ThreadCount = num;
                MainConfig.Method = this.cmbMethod.SelectedText;
                MainConfig.UsernameStart = this.txtUsernameStart.Text;
                MainConfig.UsernameEnd = this.txtUsernameEnd.Text;
                this.StartTime = DateTime.Now;
                this.lblStatus.Text = num + " Threads Working";
                string str = string.Empty;
                string a2 = string.Empty;
                this.StartTime = DateTime.Now;
                new ExchangeService(MainConfig.ExchangeVersion).Url = new Uri(MainConfig.ExchangeUrl, (MainConfig.Method == "EWS") ? "/ews/exchange.asmx" : "/oab");
                //				MainConfig.AppLocation + "out.txt";
                MainConfig.AppLocation = MainConfig.AppLocation + "out.txt";
                FolderView folderView = new FolderView(1, 0, OffsetBasePoint.Beginning);
                folderView.PropertySet = PropertySet.FirstClassProperties;
                folderView.Traversal = FolderTraversal.Deep;
                string text = string.Empty;
                try
                {
                    string empty = string.Empty;
                    while (ThreadItem.GetPassword(out empty))
                    {
                        try
                        {
                            if (MainConfig.Usernames.Count((UserClass a) => !a.IsDone) > 0)
                            {
                                for (int j = 0; j < MainConfig.Usernames.Count; j++)
                                {
                                    UserClass userClass = MainConfig.Usernames[j];
                                    if (!userClass.IsDone)
                                    {
                                        //										MainConfig.UsernameStart + userClass.Username + MainConfig.UsernameEnd;
                                        userClass.Username = MainConfig.UsernameStart + userClass.Username + MainConfig.UsernameEnd;
                                        str = PasswordManager.CheckUser(empty, userClass);
                                        text = text + str + Environment.NewLine;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            a2 = "Error : " + ex.Message;
                            File.AppendAllText("log.txt", ex.ToString() + Environment.NewLine);
                        }
                    }
                }
                catch (Exception ex2)
                {
                    a2 = "Error : " + ex2.Message;
                }
                if (a2 == "Working")
                {
                    a2 = "Done";
                }
                new ResultGenerate(text).Show();
                return;
            }
            MessageBox.Show("Please enter number of threads correctly");
        }

        // Token: 0x0600000F RID: 15 RVA: 0x00003304 File Offset: 0x00001504
        private void btnPassGenPerUser_Click(object sender, EventArgs e)
        {
            Uri exchangeUrl = null;
            int num = 0;
            ExchangeVersion value = ((KeyValuePair<string, ExchangeVersion>)this.cmbExchangeVersion.SelectedItem).Value;
            this.txtExchangeAddress.Text = this.txtExchangeAddress.Text.TrimEnd(new char[]
            {
                '/'
            }) + "/";
            if (!Uri.TryCreate(this.txtExchangeAddress.Text, UriKind.Absolute, out exchangeUrl))
            {
                MessageBox.Show("The entered Exchange Address is incorect");
                return;
            }
            if (string.IsNullOrEmpty(this.txtUserPassFile.Text))
            {
                MessageBox.Show("Please enter Username File");
                return;
            }
            if (string.IsNullOrEmpty(this.txtPassword.Text))
            {
                MessageBox.Show("Please enter Password File");
                return;
            }
            if (!string.IsNullOrEmpty(this.txtThreadCount.Text) && int.TryParse(this.txtThreadCount.Text, out num))
            {
                this.IsStartDownload = true;
                Settings @default = Settings.Default;
                @default.Address = this.txtExchangeAddress.Text;
                @default.Version = value.ToString();
                @default.UserPassFile = this.txtUserPassFile.Text;
                @default.PasswordFile = this.txtPassword.Text;
                @default.ThreadCount = this.txtThreadCount.Text;
                @default.Method = this.cmbMethod.SelectedIndex.ToString();
                @default.UsernameStart = this.txtUsernameStart.Text;
                @default.UsernameEnd = this.txtUsernameEnd.Text;
                @default.Save();
                MainConfig.MainFormInstase = this;
                MainConfig.StreamPassword = new StreamReader(this.txtPassword.Text);
                string[] array = File.ReadAllLines(this.txtUserPassFile.Text);
                MainConfig.Usernames = new List<UserClass>();
                for (int i = 0; i < array.Count<string>(); i++)
                {
                    MainConfig.Usernames.Add(new UserClass(array[i]));
                }
                MainConfig.ExchangeUrl = exchangeUrl;
                MainConfig.ExchangeVersion = value;
                MainConfig.AppLocation = this.CurrentPath;
                MainConfig.ThreadCount = num;
                MainConfig.Method = this.cmbMethod.SelectedText;
                MainConfig.UsernameStart = this.txtUsernameStart.Text;
                MainConfig.UsernameEnd = this.txtUsernameEnd.Text;
                this.StartTime = DateTime.Now;
                this.lblStatus.Text = num + " Threads Working";
                string str = string.Empty;
                string a2 = string.Empty;
                this.StartTime = DateTime.Now;
                new ExchangeService(MainConfig.ExchangeVersion).Url = new Uri(MainConfig.ExchangeUrl, (MainConfig.Method == "EWS") ? "/ews/exchange.asmx" : "/oab");
                //				MainConfig.AppLocation + "out.txt";
                MainConfig.AppLocation = MainConfig.AppLocation + "out.txt";
                FolderView folderView = new FolderView(1, 0, OffsetBasePoint.Beginning);
                folderView.PropertySet = PropertySet.FirstClassProperties;
                folderView.Traversal = FolderTraversal.Deep;
                try
                {
                    string text = AppDomain.CurrentDomain.BaseDirectory + "PasswordPerUser\\";
                    if (!Directory.Exists(text))
                    {
                        Directory.CreateDirectory(text);
                    }
                    string empty = string.Empty;
                    while (ThreadItem.GetPassword(out empty))
                    {
                        try
                        {
                            if (MainConfig.Usernames.Count((UserClass a) => !a.IsDone) > 0)
                            {
                                for (int j = 0; j < MainConfig.Usernames.Count; j++)
                                {
                                    UserClass userClass = MainConfig.Usernames[j];
                                    if (!userClass.IsDone)
                                    {
                                        //										MainConfig.UsernameStart + userClass.Username + MainConfig.UsernameEnd;
                                        userClass.Username = MainConfig.UsernameStart + userClass.Username + MainConfig.UsernameEnd;

                                        str = PasswordManager.CheckUser(empty, userClass);
                                        File.AppendAllText(text + userClass.Username + ".txt", str + Environment.NewLine);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            a2 = "Error : " + ex.Message;
                            File.AppendAllText("log.txt", ex.ToString() + Environment.NewLine);
                        }
                    }
                }
                catch (Exception ex2)
                {
                    a2 = "Error : " + ex2.Message;
                }
                if (a2 == "Working")
                {
                    a2 = "Done";
                }
                return;
            }
            MessageBox.Show("Please enter number of threads correctly");
        }

        // Token: 0x04000001 RID: 1
        private BindingList<ThreadItem> ThreadItemList;

        // Token: 0x04000002 RID: 2
        private Thread thrRefresher;

        // Token: 0x04000003 RID: 3
        private Thread MainThread;

        // Token: 0x04000004 RID: 4
        private DateTime StartTime;

        // Token: 0x04000005 RID: 5
        private string MainStatus = string.Empty;

        // Token: 0x04000006 RID: 6
        private bool IsStartDownload;

        // Token: 0x04000007 RID: 7
        private const string StatusDownloading = "Downloading \"{0}\" Emails : ";

        // Token: 0x04000008 RID: 8
        private string CurrentPath;
    }
}
