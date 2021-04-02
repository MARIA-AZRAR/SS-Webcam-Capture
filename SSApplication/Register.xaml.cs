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
using System.Windows.Shapes;

namespace SSApplication
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        localhost.WebService1 objWebservice = new localhost.WebService1(); //creating obj of web service

        public Window1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Password != txtAgainPassword.Password)
            {
                MessageBox.Show("Passwords Don't Match");
            }

            else
            {
                int res;
                res = objWebservice.registerStudent(txtName.Text, txtUsername.Text, txtPassword.Password, txtAgainPassword.Password, txtEmail.Text,
                    txtAddress.Text, txtCNIC.Text, txtContact.Text);
                if (res == 1)
                {
                    MessageBox.Show("REGSTER SUCCESSFULLY");
                    var log = new MainWindow();
                    log.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("INVALID REGISTER");
                }
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var log = new MainWindow();
            log.Show();
            this.Hide();
        }
    }
}
