using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Post_Install_Wizard
{
    class Common
    {
        public static void AddUsr(PasswordBox passwordBox, TextBox textBox)
        {
            char[] invalidchars = new char[9];
            invalidchars[1] = '\\';
            invalidchars[2] = '/';
            invalidchars[3] = ':';
            invalidchars[4] = '*';
            invalidchars[5] = '?';
            invalidchars[6] = '<';
            invalidchars[7] = '>';
            invalidchars[8] = '|';
            bool invalid = false;
            foreach (char invalidchars2 in invalidchars)
            {
                if (textBox.Text.Contains(invalidchars2) == true)
                {
                    invalid = true;
                }
            }
            if (invalid == true)
            {
                MessageBox.Show("Invalid characters such as '\\','/',':','*','?','<','>', and '|' detected. Please remove these");

            }
            else
            {
                if (passwordBox.Password == "")
                {
                    RunAdmin.RunAdmin.RunAsAdmin("net.exe", "user " + textBox.Text + " /add", false);
                }
                else
                {
                    RunAdmin.RunAdmin.RunAsAdmin("net.exe", "user " + textBox.Text + " " + passwordBox.Password + " /add", false);
                }
                MessageBox.Show("Done!");
            }
        }
        public static void AdmOff()
        {
            RunAdmin.RunAdmin.RunAsAdmin("net.exe", "user Administrator /active:NO", false);
        }
        public static void OOBE(ComboBox comboBox, CheckBox checkBox,ComboBoxItem Quit, ComboBoxItem Reboot, ComboBoxItem Shutdown)
        {
            string system32location = Environment.GetFolderPath(Environment.SpecialFolder.System);
            string sysnative = System.IO.Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.System)) + "\\sysnative";
            string args = " /oobe ";
            bool validselection = true;
            if (comboBox.SelectedItem == Quit)
            {
                args = args + "/quit ";
            }
            else if (comboBox.SelectedItem == Reboot)
            {
                args = args + "/reboot ";
            }
            else if (comboBox.SelectedItem == Shutdown)
            {
                args = args + "/shutdown ";
            }
            else
            {
                validselection = false;
            }

            if (checkBox.IsChecked == true)
            {
                args = args + "/generalize ";
            }

            if ((Environment.Is64BitOperatingSystem == true) && (validselection == true))
            {
                RunAdmin.RunAdmin.RunAsAdmin("cmd.exe", "/C " + sysnative + "\\sysprep\\sysprep.exe" + args, false);
            }
            else if ((Environment.Is64BitOperatingSystem == false) && (validselection == true))
            {
                RunAdmin.RunAdmin.RunAsAdmin("cmd.exe", "/C " + system32location + "\\sysprep\\sysprep.exe" + args, false);
            }
        }
        public static void Uninstall()
        {
            string uninstallerlocation = "";
            //Uninstaller package command = PS:> (Get-WmiObject -query "select * from Win32_Product where Vendor = 'Caphyon'").LocalPackage

            /*Int32 len = 512;
            System.Text.StringBuilder builder = new System.Text.StringBuilder(len);*/

            String ProgramFiles = "";
            if (Environment.Is64BitOperatingSystem == true)
            {
                ProgramFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            }
            else
            {
                ProgramFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            }
            RunAdmin.RunAdmin.RunAsAdmin("powershell.exe", "-NoLogo -NoProfile -ExecutionPolicy Bypass -Command " + ProgramFiles + "\\Team1159\\Post Install Wizard\\UninstLocation.ps1", true);


            try
            {
                String[] lines = System.IO.File.ReadAllLines(ProgramFiles + "\\Team1159\\UninstPIWiz.txt");
                uninstallerlocation = lines[0];
                RunAdmin.RunAdmin.RunAsAdmin(uninstallerlocation, "/x /quiet /qn /norestart", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
