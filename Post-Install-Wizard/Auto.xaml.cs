using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Post_Install_Wizard
{
    /// <summary>
    /// Interaction logic for Auto.xaml
    /// </summary>
    public partial class Auto : Page
    {
        public Auto()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            Common.AddUsr(Passwd,UsrName);
            Common.AdmOff();
            
            bool reboot = false, quit = false, shutdown = false;
            if(comBoxShutdown.SelectedItem == Quit)
            {
                quit = true;
            }
            else if(comBoxShutdown.SelectedItem == Reboot)
            {
                reboot = true;
            }
            else if(comBoxShutdown.SelectedItem == Shutdown)
            {
                shutdown = true;
            }
            else
            {
                MessageBox.Show("Couldn't select shutdown option");
            }

            comBoxShutdown.SelectedItem = Quit;
            Common.OOBE(comBoxShutdown, chkBoxGeneralize, Quit, Reboot, Shutdown);
            Common.Uninstall();
            if (quit == true)
            {
                MainWindow mainwin = new MainWindow();
                mainwin.Close();
            }else if(shutdown == true)
            {
                RunAdmin.RunAdmin.RunAsAdmin("shutdown.exe", "-s -t 00", false);
            }else if(reboot == true)
            {
                RunAdmin.RunAdmin.RunAsAdmin("shutdown.exe", "-r -t 00", false);
            }
            
        }
    }
}
