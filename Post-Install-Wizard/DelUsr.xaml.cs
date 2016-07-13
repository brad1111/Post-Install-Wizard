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
using System.Management;

namespace Post_Install_Wizard
{
    /// <summary>
    /// Interaction logic for DelUsr.xaml
    /// </summary>
    public partial class DelUsr : Page
    {
        public DelUsr()
        {
            InitializeComponent();
            
            refresh();
            
        }
        void refresh()
        {
            textBlock.Text = "User Accounts:\n";
            SelectQuery query = new SelectQuery("Win32_UserAccount");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            foreach (ManagementObject envVar in searcher.Get())
            {
                textBlock.Text = textBlock.Text + envVar["Name"] + "\n";

            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            bool Valid = false;

            refresh();

            SelectQuery query = new SelectQuery("Win32_UserAccount");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            foreach(ManagementObject envVar in searcher.Get())
            {
               if (Convert.ToString(envVar["Name"]) == textBox.Text)
                {
                    Valid = true;
                }
            }
            if (Valid == true)
            {
                RunAdmin.RunAdmin.RunAsAdmin("net.exe","user " + textBox.Text + " /del",false);
                MessageBox.Show("Done!");
            }else
            {
                MessageBox.Show("Name not found");
            }
            refresh();
        }
    }
}
