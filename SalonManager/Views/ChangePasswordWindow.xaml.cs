using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SalonManager.Views
{
    /// <summary>
    /// Interaction logic for ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        public ChangePasswordWindow()
        {
            InitializeComponent();
        }

        private void ConfirmNewPassword(object sender, RoutedEventArgs e)
        {
  
            string Confirmpassword = System.Runtime.InteropServices.Marshal.PtrToStringBSTR(System.Runtime.InteropServices.Marshal.SecureStringToBSTR(this.ConfirmPassword.SecurePassword));

            string Newpassword = System.Runtime.InteropServices.Marshal.PtrToStringBSTR(System.Runtime.InteropServices.Marshal.SecureStringToBSTR(this.NewPassword.SecurePassword));

            if (!Newpassword.Equals("") && Newpassword.Equals(Confirmpassword))
            {
                SalonManager.Properties.Settings.Default.Password = Newpassword;
                SalonManager.Properties.Settings.Default.Save();
                this.Close();
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("新密碼確認錯誤", "密碼變更視窗", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
