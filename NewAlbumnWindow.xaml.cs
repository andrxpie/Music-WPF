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
    /// Interaction logic for NewAlbumnWindow.xaml
    /// </summary>
    public partial class NewAlbumnWindow : Window
    {
        public MusicAlbumn albumn;
        public User user;

        public NewAlbumnWindow(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void AddBnt_Click(object sender, RoutedEventArgs e)
        {
            if(nameTextBox.Text == string.Empty)
            {
                MessageBox.Show("Name is empty", "Message", MessageBoxButton.OK);
                return;
            }

            if(authorTextBox.Text == string.Empty)
            {
                MessageBox.Show("Author is empty", "Message", MessageBoxButton.OK);
                return;
            }

            if(yearTextBox.Text == string.Empty)
            {
                MessageBox.Show("Year is empty", "Message", MessageBoxButton.OK);
                return;
            }

            albumn = new MusicAlbumn(nameTextBox.Text, authorTextBox.Text, Convert.ToInt32(yearTextBox.Text), Convert.ToInt32(user.id));
            Close();
        }

        private void CancleBnt_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
