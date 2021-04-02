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


namespace SSApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //create an object of webservice
        localhost.WebService1 objWebservice = new localhost.WebService1();

        public MainWindow()
        {
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            bool res;
            string username = txtUsername.Text;
            string password = txtPassword.Password;
            res = objWebservice.isValidLogin(username, password);
            if (res)
            {
                MessageBox.Show("LOGIN SUCCESSFULLY");
                var hm = new Home();
                hm.Show();
                this.Close();
                
            }
            else
            {
                MessageBox.Show("INVALID LOGIN CREDENTIALS");
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var reg = new Window1(); //create an instance of form 3
            reg.Show();       //show Register
            this.Close();
        }

        private void TxtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
