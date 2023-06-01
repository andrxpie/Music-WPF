using Music_WPF.Data.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                if(users.Count != 0) {
                    if(connection.Table<User>().Where(x => x.login == loginTextBox.Text).FirstOrDefault() != null)
                    {
                        if(connection.Table<User>().Where(x => x.login == loginTextBox.Text).FirstOrDefault().password == passwordTextBox.Text)
                        {
                            Hide();

                            User user = connection.Table<User>().Where(x => x.login == loginTextBox.Text).FirstOrDefault();
                            AlbumnsWindow musicListWindow = new AlbumnsWindow(user);
                            musicListWindow.ShowDialog();
                            
                            loginTextBox.Text = string.Empty;
                            passwordTextBox.Text = string.Empty;

                            Show();
                        }
                        else
                        {
                            passwordTextBox.Text = string.Empty;
                            MessageBox.Show("Wrong password", "Message", MessageBoxButton.OK);
                        }
                    }
                    else
                    {
                        if(MessageBox.Show("Login not found in database, may create new account?", "Message", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            connection.Insert(new User(loginTextBox.Text, passwordTextBox.Text, users.Count));
                            GetUsers();

                            Hide();
                            AlbumnsWindow albumnsWindow = new AlbumnsWindow(users.Where(x => x.login == loginTextBox.Text).First());
                            albumnsWindow.ShowDialog();
                            Show();

                            loginTextBox.Text = string.Empty;
                            passwordTextBox.Text = string.Empty;
                        }
                        else
                        {
                            loginTextBox.Text = string.Empty;
                            passwordTextBox.Text = string.Empty;
                        }
                    }
                }
                else
                {
                    if(MessageBox.Show("No users found in database, may create new?", "Message", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        connection.Insert(new User(loginTextBox.Text, passwordTextBox.Text, users.Count));
                        GetUsers();

                        Hide();
                        AlbumnsWindow albumnsWindow = new AlbumnsWindow(users.Where(x => x.login == loginTextBox.Text).First());
                        albumnsWindow.ShowDialog();
                        Show();

                        loginTextBox.Text = string.Empty;
                        passwordTextBox.Text = string.Empty;
                    }
                    else
                    {
                        loginTextBox.Text = string.Empty;
                        passwordTextBox.Text = string.Empty;
                    }
                }
            }            
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}