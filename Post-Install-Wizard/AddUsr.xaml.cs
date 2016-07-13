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
using RunAdmin;

namespace Post_Install_Wizard
{
    /// <summary>
    /// Interaction logic for AddUsr.xaml
    /// </summary>
    public partial class AddUsr : Page
    {
        public AddUsr()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Common.AddUsr(passwordBox,textBox);
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           /* char[] invalidchars = new char[9];
            invalidchars[1] = '\\';
            invalidchars[2] = '/';
            invalidchars[3] = ':';
            invalidchars[4] = '*';
            invalidchars[5] = '?';
            invalidchars[6] = '<';
            invalidchars[7] = '>';
            invalidchars[8] = '|';


            foreach (char invalidchars2 in invalidchars)
            {
                if (textBox.Text.Contains(invalidchars2) == true)
                {
                    
                }
            }                Unused code         */
        }
    }
}
