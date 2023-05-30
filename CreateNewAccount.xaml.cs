using Music_WPF.Data.Models;
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

namespace Music_WPF
{
    /// <summary>
    /// Interaction logic for CreateNewAccount.xaml
    /// </summary>
    public partial class CreateNewAccount : Window
    {
        public User newUser;

        public CreateNewAccount()
        {
            InitializeComponent();
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            if(loginTextBox.Text == string.Empty)
            {
                MessageBox.Show("Login is empty", "Message", MessageBoxButton.OK);
                return;
            }

            if(passwordTextBox.Text == string.Empty)
            {
                MessageBox.Show("Password is empty", "Message", MessageBoxButton.OK);
                return;
            }

            newUser = new User(loginTextBox.Text, passwordTextBox.Text);
            Close();
        }
    }
}
