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
    /// Interaction logic for LT.xaml
    /// </summary>
    public partial class LT : Page
    {
        public LT()
        {
            InitializeComponent();
        }

        private void VBS_Click(object sender, RoutedEventArgs e)
        {
            string system32 = Convert.ToString(System.IO.Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.System)));
            //Try catch because can crash program if deploymentshare is down
            try
            {
                RunAdmin.RunAdmin.RunAsAdmin("cscript.exe", "//B //NoLogo " + Properties.Resources.LTScriptLocation,false);
            }
            catch (Exception)
            {
                MessageBox.Show("DeploymentShare not accessible. Please try again later.");
            }
        }

        private void EXE_Click(object sender, RoutedEventArgs e)
        {
            //Try catch because can crash program if exe not found or network share is down
            try
            {
                RunAdmin.RunAdmin.RunAsAdmin(Properties.Resources.LTExeLocation, "",false);
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot run application. Network Share could be down or file may not be there.");
            }
        }
    }
}
