using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using test.Business;

namespace test
{
    /// <summary>
    /// Logique d'interaction pour backupView.xaml
    /// </summary>
    public partial class backupView : Window
    {
       
        Bbackup _bbckup = new Bbackup();
        string GlobalFile;
        public backupView()
        {
            InitializeComponent();
            form.LblEnregistrerCreer.Visibility = form.LblAnnuler.Visibility = Visibility.Collapsed;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ComboPeriode.SelectionChanged += ComboPeriode_SelectionChanged;
            DataTable dtRempliCombo = new DataTable();
            dtRempliCombo = _bbckup.GetNameDatabase();
            ComboDB.ItemsSource = dtRempliCombo.DefaultView;
        }

        private void ComboPeriode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentSelectedIndex = ComboPeriode.SelectedIndex;
            switch (currentSelectedIndex)
            {
                case 0:
                    cmbhebdo.Visibility = Visibility.Collapsed;
                    cmbMens.Visibility = Visibility.Collapsed;
                    break;

                case 1:
                    cmbhebdo.Visibility = Visibility.Visible;
                    cmbMens.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    cmbhebdo.Visibility = Visibility.Collapsed;
                    cmbMens.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void ucform_EnregistrerClick(object sender, RoutedEventArgs e)
        {
            try
            {
                
                string root = GlobalFile + @"D:\\File.exe\";
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                if (File.Exists(root))
                {
                    File.Delete(root);
                }

                string root2 = GlobalFile + @"D:\\BakupFile";
                if (!Directory.Exists(root2))
                {
                    Directory.CreateDirectory(root2);
                }
                if (File.Exists(root2))
                {
                    File.Delete(root2);
                }
                string file = root + @"Full backup.bat";
                using (FileStream fs = File.Create(file))
                {
                    Byte[] title = new UTF8Encoding(true).GetBytes("New Text File");
                    fs.Write(title, 0, title.Length);
                    byte[] author = new UTF8Encoding(true).GetBytes("Full backup");
                    fs.Write(author, 0, author.Length);
                }
                using (StreamReader sr = File.OpenText(file))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
                StreamWriter sw = new StreamWriter(file);
                sw.WriteLine("REM [-S] Specifies the instance of SQL Server.");
                sw.WriteLine(@"REM [.\instance name of the SQL Server] Specifies the instance ");
                sw.WriteLine("REM [-E] Uses a trusted connection instead of using a user name ");
                sw.WriteLine("REM [-Q] Executes a query when sqlcmd starts and then immediately exits sqlcmd. ");
                sw.WriteLine("REM @backupLocation='Destination location where backup will be kept'");
                sw.WriteLine("REM  Type of backup you want to take [F=full, D=differential, L=log]");
                sw.WriteLine("------------------------------------");
                sw.WriteLine($@"sqlcmd -S (local)\SQL2014 -E -Q ""EXEC sp_BackupDatabases @databaseName = '{ComboDB.Text}' ,  @backupLocation='{root2}\', @backupType='F'""");
                sw.WriteLine("------------------------------------");
                sw.Close();
                _bbckup.VerifyExisting();
                var currentSelectedIndex = ComboPeriode.SelectedIndex;
                string heure = cmbheure.Text;
                string minute = cmbminute.Text;
                string date = string.Concat(heure, ":", minute + ":00");
                using (TaskService ts = new TaskService("MONPC-PC"))
                {
                    TaskDefinition td = ts.NewTask();
                    td.RegistrationInfo.Description = "Does something";
                    td.Actions.Add(new ExecAction(file, null, null));
                    if (currentSelectedIndex == 0)
                    {
                        DailyTrigger daily = new DailyTrigger();
                        daily.StartBoundary = Convert.ToDateTime(date);
                        td.Triggers.Add(daily);
                    }
                    else if (currentSelectedIndex == 1)
                    {
                        var currentSelectedIndexhebdo = cmbhebdo.SelectedIndex;
                        WeeklyTrigger mTrigger = new WeeklyTrigger();
                        switch (currentSelectedIndexhebdo)
                        {
                            case 0:
                                mTrigger.DaysOfWeek = DaysOfTheWeek.Monday;
                                mTrigger.StartBoundary = Convert.ToDateTime(date);
                                td.Triggers.Add(mTrigger);
                                break;
                            case 1:
                                mTrigger.DaysOfWeek = DaysOfTheWeek.Tuesday;
                                mTrigger.StartBoundary = Convert.ToDateTime(date);
                                td.Triggers.Add(mTrigger);
                                break;
                            case 2:
                                mTrigger.DaysOfWeek = DaysOfTheWeek.Wednesday;
                                mTrigger.StartBoundary = Convert.ToDateTime(date);
                                td.Triggers.Add(mTrigger);
                                break;
                            case 3:
                                mTrigger.DaysOfWeek = DaysOfTheWeek.Thursday;
                                mTrigger.StartBoundary = Convert.ToDateTime(date);
                                td.Triggers.Add(mTrigger);
                                break;
                            case 4:
                                mTrigger.DaysOfWeek = DaysOfTheWeek.Friday;
                                mTrigger.StartBoundary = Convert.ToDateTime(date);
                                td.Triggers.Add(mTrigger);
                                break;
                            case 5:
                                mTrigger.DaysOfWeek = DaysOfTheWeek.Saturday;
                                mTrigger.StartBoundary = Convert.ToDateTime(date);
                                td.Triggers.Add(mTrigger);
                                break;
                            case 6:
                                mTrigger.DaysOfWeek = DaysOfTheWeek.Sunday;
                                mTrigger.StartBoundary = Convert.ToDateTime(date);
                                td.Triggers.Add(mTrigger);
                                break;
                        }
                    }
                    else if (currentSelectedIndex == 2)
                    {
                        MonthlyTrigger mTrigger = new MonthlyTrigger();
                        mTrigger.StartBoundary = Convert.ToDateTime(date);
                        mTrigger.DaysOfMonth = new int[] { int.Parse(cmbMens.Text) };
                        mTrigger.MonthsOfYear = MonthsOfTheYear.July | MonthsOfTheYear.December;
                        td.Triggers.Add(mTrigger);
                    }

                    ts.RootFolder.RegisterTaskDefinition($@"Save_{ComboDB.Text}_{ComboPeriode.Text}", td);
                }
                UCGeneraFi.GeneraFiMessageBox.Show("");
            }
            catch (Exception ex)
            {
                UCGeneraFi.GeneraFiMessageBox.Show(ex.Message);
            }
        }
        private void Savefile_Click(object sender, RoutedEventArgs e)
        {

            #region FolderBrowserDialog
            //using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            //{
            //    System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            //    string file = dialog.SelectedPath;
            //    if(!string.IsNullOrEmpty(file))
            //    {
            //        if (!Directory.Exists(file))
            //        {
            //            Directory.CreateDirectory(file);
            //        }
            //        if (File.Exists(file))
            //        {
            //            File.Delete(file);
            //        }
            //    }

            //    GlobalFile = file;
            //}
            #endregion

            try
            {
                Microsoft.Win32.SaveFileDialog _saveFileDialog = new Microsoft.Win32.SaveFileDialog();
                var result = _saveFileDialog.ShowDialog();
                if (result ?? false)
                {
                    if (!Directory.Exists(_saveFileDialog.FileName))
                    {
                        Directory.CreateDirectory(_saveFileDialog.FileName);
                    }
                    if (File.Exists(_saveFileDialog.FileName))
                    {
                        File.Delete(_saveFileDialog.FileName);
                    }
                }
                GlobalFile = _saveFileDialog.FileName;
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
