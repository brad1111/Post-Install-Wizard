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
    /// Interaction logic for OOBE.xaml
    /// </summary>
    public partial class OOBE : Page
    {
        public OOBE()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Common.OOBE(comboBox, checkBox, Quit, Reboot, Shutdown);
            
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void comboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
