using System;
using System.Collections.Generic;
using System.Linq;
//using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Post_Install_Wizard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NaviFrame.Navigate(new Landing());
        }

        private void AddUsr_Click(object sender, RoutedEventArgs e)
        {
            NaviFrame.Navigate(new AddUsr());
        }

        private void DelUsr_Click(object sender, RoutedEventArgs e)
        {
            NaviFrame.Navigate(new DelUsr());
        }

        private void AdmOn_Click(object sender, RoutedEventArgs e)
        {
            RunAdmin.RunAdmin.RunAsAdmin("net.exe", "user Administrator /active:YES", false);
        }

        private void AdmOff_Click(object sender, RoutedEventArgs e)
        {
            Common.AdmOff();
        }

        private void OOBE_Click(object sender, RoutedEventArgs e)
        {
            NaviFrame.Navigate(new OOBE());
        }

        private void LT_Click(object sender, RoutedEventArgs e)
        {
            NaviFrame.Navigate(new LT());
        }

        private void WU_Click(object sender, RoutedEventArgs e)
        {
            string systemdir = Convert.ToString(Environment.GetFolderPath(Environment.SpecialFolder.System));
            System.Diagnostics.Process.Start(systemdir + "\\control.exe", "/name Microsoft.WindowsUpdate");
        }

        private void WSUS_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Use username: inst and password: inst");
            RunAdmin.RunAdmin.RunAsAdmin("cmd.exe", "/C start " + Properties.Resources.WSUSExe, false);
        }

        private void Uninst_Click(object sender, RoutedEventArgs e)
        {
            Common.Uninstall();
        }

        /*[DllImport("msi.dll", CharSet = CharSet.Unicode)]
        static extern Int32 MsiGetProductInfo(string product, string property, [Out] StringBuilder valueBuf, ref Int32 len);*/

        private void Auto_Click(object sender, RoutedEventArgs e)
        {
            NaviFrame.Navigate(new Auto());
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
