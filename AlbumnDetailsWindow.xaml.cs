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
    /// Interaction logic for AlbumnDetailsWindow.xaml
    /// </summary>
    public partial class AlbumnDetailsWindow : Window
    {
        MusicAlbumn albumn;
        public AlbumnDetailsWindow(MusicAlbumn albumn)
        {
            InitializeComponent();
            this.albumn = albumn;
            nameTextBox.Text = albumn.name;
            authorTextBox.Text = albumn.author;
            yearTextBox.Text = Convert.ToString(albumn.year);
        }

        private void DeleteBnt_Click(object sender, RoutedEventArgs e)
        {
            using(SQLiteConnection connection = new SQLiteConnection(App.dbPath))
            {
                connection.Delete(albumn);
            }

            Close();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.dbPath))
            {

                connection.Delete(albumn);
                albumn.name = nameTextBox.Text;
                albumn.author = authorTextBox.Text;
                albumn.year = Convert.ToInt32(yearTextBox.Text);
                connection.Insert(albumn);
            }
            
            Close();
        }
    }
}