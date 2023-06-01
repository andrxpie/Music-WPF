using Music_WPF.Data.Models;
using SQLite;
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
    /// Interaction logic for MusicListWindow.xaml
    /// </summary>
    public partial class AlbumnsWindow : Window
    {
        public List<MusicAlbumn> musicAlbumns;

        public AlbumnsWindow(User currUser)
        {
            InitializeComponent();
            GetMusicAlbumns(currUser);
        }

        public void GetMusicAlbumns(User currUser)
        {
            using(SQLiteConnection connection = new SQLiteConnection(App.dbPath))
            {
                connection.CreateTable<MusicAlbumn>();

                try
                {
                    musicAlbumns = connection.Table<MusicAlbumn>().ToList();
                    albumnsListBox.ItemsSource = musicAlbumns.Where(x => x.userID == currUser.id);
                }
                catch
                {
                    MessageBox.Show("No albumns found", "Message", MessageBoxButton.OK);
                }
            }
        }

        private void LogOutBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}