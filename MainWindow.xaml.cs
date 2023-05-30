using Music_WPF.Data.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Music_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<User> users = new List<User>();

        public MainWindow()
        {
            InitializeComponent();
            users = new List<User>();
            GetUsers();
        }

        public void GetUsers()
        {
            if(File.Exists(App.dbPath))
            {
                using (SQLiteConnection connection = new SQLiteConnection(App.dbPath))
                {
                    connection.CreateTable<User>();
                    try
                    {
                        users = connection.Table<User>().ToList();
                    }
                    catch
                    {
                        MessageBox.Show("No user found", "Message", MessageBoxButton.OK);
                    }
                }
            }
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
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

            using(SQLiteConnection connection = new SQLiteConnection(App.dbPath))
            {
                if(connection.Table<User>().Contains(new User(loginTextBox.Text, passwordTextBox.Text)))
                {
                    loginTextBox.Text = string.Empty;
                    passwordTextBox.Text = string.Empty;

                    Hide();
                    MusicListWindow musicListWindow = new MusicListWindow((new User(loginTextBox.Text, passwordTextBox.Text)).id);
                    musicListWindow.ShowDialog();
                    Show();
                }
                else
                {
                    if(MessageBox.Show("No users in database found, may create new account?", "Message", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        loginTextBox.Text = string.Empty;
                        passwordTextBox.Text = string.Empty;
                        Hide();

                        CreateNewAccount cna = new CreateNewAccount();
                        cna.ShowDialog();
                        users.Add(cna.newUser);
                        Show();

                        MusicListWindow musicList = new MusicListWindow(cna.newUser.id);
                    }
                }
            }            
        }
    }
}